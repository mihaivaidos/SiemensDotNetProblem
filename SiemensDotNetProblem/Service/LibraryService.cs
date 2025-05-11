using SiemensDotNetProblem.Model;
using SiemensDotNetProblem.Repository;

namespace SiemensDotNetProblem.Service;

public class LibraryService
{
    private readonly IRepository<Book> _bookRepo;
    private readonly IRepository<Loan> _loanRepo;
    private readonly IRepository<Review> _reviewRepo;
    private readonly IRepository<Member> _memberRepo;

    private int _newBookID;
    private int _newLoanID;
    private int _newReviewID;
    private int _newMemberID;

    public LibraryService(IRepository<Book> bookRepo, IRepository<Loan> loanRepo, IRepository<Review> reviewRepo, IRepository<Member> memberRepo)
    {
        _bookRepo = bookRepo;
        _loanRepo = loanRepo;
        _reviewRepo = reviewRepo;
        _memberRepo = memberRepo;

        _newBookID = GetMaxId(_bookRepo);
        _newLoanID = GetMaxId(_loanRepo);
        _newReviewID = GetMaxId(_reviewRepo);
        _newMemberID = GetMaxId(_memberRepo);
    }

    private int GetMaxId<T>(IRepository<T> repository) where T : IHasID
    {
        return repository.GetAll().Select(obj => obj.GetID()).DefaultIfEmpty(0).Max();
    }

    // CRUD Methods for Books
    public void AddBook(string bookName, string authorName, int copiesAvailable)
    {
        var book = new Book(++_newBookID, bookName, authorName, true, copiesAvailable);
        _bookRepo.Add(book);
    }

    public void UpdateBook(int bookID, string? newBookName, string? newAuthorName, bool newIsAvailable, int newCopies)
    {
        var book = _bookRepo.Get(bookID);
        if (book == null) throw new Exception("Book not found.");

        book.BookName = newBookName ?? book.BookName;
        book.AuthorName = newAuthorName ?? book.AuthorName;
        book.IsAvailable = newIsAvailable;
        book.CopiesAvailable = newCopies != -1 ? newCopies : book.CopiesAvailable;

        _bookRepo.Update(book);
    }

    public void DeleteBook(int bookID)
    {
        var book = _bookRepo.Get(bookID);
        if (book == null) throw new Exception("Book not found.");

        _bookRepo.Delete(bookID);
    }

    public List<Book> GetAllBooks()
    {
        return _bookRepo.GetAll();
    }
    
    public void AddMember(string name, string email, string phoneNumber)
    {
        var member = new Member(++_newMemberID, name, email, phoneNumber);
        _memberRepo.Add(member);
    }

    public void UpdateMember(int memberID, string name, string email, string phoneNumber)
    {
        var member = _memberRepo.Get(memberID);
        if (member == null) throw new Exception("Member not found.");
        member.Name = name;
        member.Email = email;
        member.PhoneNumber = phoneNumber;
        _memberRepo.Update(member);
    }

    public void DeleteMember(int memberID)
    {
        var member = _memberRepo.Get(memberID);
        if (member == null) throw new Exception("Member not found.");
        
        _memberRepo.Delete(memberID);
    }

    public List<Member> GetAllMembers()
    {
        return _memberRepo.GetAll();
    }
    
    public List<Review> GetReviewsByMember(int memberID)
    {
        var allReviews = _reviewRepo.GetAll();
        return allReviews.Where(r => r.Member.ID == memberID).ToList();
    }

    // Borrowing and Returning Books
    public void BorrowBook(int memberID, int bookID)
    {
        var book = _bookRepo.Get(bookID);
        var member = _memberRepo.Get(memberID);

        if (book == null) throw new Exception("Book not found.");
        if (member == null) throw new Exception("Member not found.");

        if (CheckMemberHasOverdueLoans(memberID)) throw new Exception("Cannot borrow books with overdue loans.");

        if (book.IsAvailable && book.CopiesAvailable > 0)
        {
            CreateLoan(book, member);
        }
        else
        {
            throw new Exception("Book is not available for borrowing.");
        }
    }

    private void CreateLoan(Book book, Member member)
    {
        var loan = new Loan(++_newLoanID, DateTime.Now, CalculateDueDate(), null, "ACTIVE", book, member);
        _loanRepo.Add(loan);

        book.CopiesAvailable--;
        if (book.CopiesAvailable < 1) book.IsAvailable = false;

        member.Loans.Add(loan);
        member.LoanHistory.Add(loan);

        _bookRepo.Update(book);
        _memberRepo.Update(member);
        _loanRepo.Update(loan);
    }
    
    public void ReturnBook(int loanID)
    {
        var loan = _loanRepo.Get(loanID);
        if (loan == null) throw new Exception("Loan not found.");

        var book = loan.Book;
        if (loan.Status != "ACTIVE") throw new Exception("Loan is not active and cannot be returned.");

        RemoveLoan(loan);
    }

    private void RemoveLoan(Loan loan)
    {
        loan.Status = "RETURNED";
        loan.ReturnDate = DateTime.Now;

        var book = loan.Book;
        book.CopiesAvailable++;
        if (book.CopiesAvailable > 0) book.IsAvailable = true;

        var member = loan.Member;
        member.Loans.Remove(loan);

        _memberRepo.Update(member);
        _bookRepo.Update(book);
        _loanRepo.Update(loan);
    }

    // Reviews
    public void AddReviewToBook(int memberID, int bookID, int rating, string reviewText)
    {
        var member = _memberRepo.Get(memberID);
        var book = _bookRepo.Get(bookID);

        if (book == null) throw new Exception("Book not found.");
        if (member == null) throw new Exception("Member not found.");

        bool hasBorrowed = member.LoanHistory.Any(loan => loan.Book.ID == bookID && loan.Status == "RETURNED");
        if (!hasBorrowed) throw new Exception("Member must borrow and return the book before adding a review.");

        var review = new Review(++_newReviewID, rating, reviewText, book, member);
        book.Reviews.Add(review);
        _reviewRepo.Add(review);
        _bookRepo.Update(book);
    }

    public List<Review> GetAllReviewsOfBook(int bookID)
    {
        var book = _bookRepo.Get(bookID);
        if (book == null) throw new Exception("Book not found.");

        return book.Reviews;
    }

    public List<Book> GetReturnedBooksByMember(int memberID)
    {
        var loans = _loanRepo.GetAll();
        return loans
            .Where(loan => loan.Member.ID == memberID && loan.Status == "RETURNED")
            .Select(loan => loan.Book)
            .Distinct()
            .ToList();
    }

    public void DeleteReviewFromBook(int reviewID, int memberID)
    {
        var review = _reviewRepo.Get(reviewID);
        if (review == null) throw new Exception("Review not found.");
        if (review.Member.ID != memberID) throw new Exception("Member does not belong to this review.");

        var book = review.Book;
        book.Reviews.Remove(review);
        _bookRepo.Update(book);
        _reviewRepo.Delete(reviewID);
    }
    
    public bool CheckMemberHasOverdueLoans(int memberID)
    {
        var member = _memberRepo.Get(memberID);
        if (member == null) throw new Exception("Member not found.");

        return member.Loans.Any(loan => loan.DueDate < DateTime.Now);
    }

    public DateTime CalculateDueDate()
    {
        return DateTime.Now.AddDays(14); // Default loan period is 14 days
    }

    public List<Loan> GetAllActiveLoansForMember(int memberID)
    {
        var member = _memberRepo.Get(memberID);
        if (member == null) throw new Exception("Member not found.");
        //return member.LoanHistory.Where(loan => loan.Status == "ACTIVE").ToList();
        return _loanRepo.GetAll()
            .Where(loan => loan.Member.ID == memberID && loan.Status == "ACTIVE")
            .ToList();
    }

    public List<Loan> GetLoanHistoryForMember(int memberID)
    {
        var member = _memberRepo.Get(memberID);
        if (member == null) throw new Exception("Member not found.");
        return _loanRepo.GetAll()
            .Where(loan => loan.Member.ID == memberID)
            .ToList();
    }
    
    public List<Book> SearchBook(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return GetAllBooksSortedByTitle();
        }

        return _bookRepo.GetAll()
            .Where(book => book.BookName.ToLower().Contains(title.ToLower()))
            .ToList();
    }

    public List<Book> GetAllBooksSortedByTitle()
    {
        return _bookRepo.GetAll()
            .OrderBy(book => book.BookName)
            .ToList();
    }
    
}