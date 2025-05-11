using SiemensDotNetProblem.Service;

namespace SiemensDotNetProblem.UI;

public class LibraryUI
{
    private readonly LibraryService _libraryService;

    public LibraryUI(LibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("=== Library Management System ===");
            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Members");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Review a book");
            Console.WriteLine("6. Delete a review");
            Console.WriteLine("7. View the reviews of a book");
            Console.WriteLine("8. Search books by title");
            Console.WriteLine("9. View member’s active loans");
            Console.WriteLine("10. View member’s loan history");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ManageBooks();
                    break;
                case "2":
                    ManageMembers();
                    break;
                case "3":
                    BorrowBook();
                    break;
                case "4":
                    ReturnBook();
                    break;
                case "5":
                    ReviewBook();
                    break;
                case "6":
                    DeleteReview();
                    break;
                case "7":
                    ViewReviewsOfBook();
                    break;
                case "8":
                    SearchBooksByTitle();
                    break;
                case "9":
                    ViewActiveLoansForMember();
                    break;
                case "10":
                    ViewLoanHistoryForMember();
                    break;
                case "0":
                    Console.WriteLine("Exiting Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void ManageBooks()
    {
        while (true)
        {
            Console.WriteLine("=== Manage Books ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    UpdateBook();
                    break;
                case "3":
                    DeleteBook();
                    break;
                case "4":
                    ViewAllBooks();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void ManageMembers()
    {
        while (true)
        {
            Console.WriteLine("=== Manage members ===");
            Console.WriteLine("1. Add member");
            Console.WriteLine("2. Update member");
            Console.WriteLine("3. Delete member");
            Console.WriteLine("4. View all members");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddMember();
                    break;
                case "2":
                    UpdateMember();
                    break;
                case "3":
                    DeleteMember();
                    break;
                case "4":
                    ViewAllMembers();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void AddBook()
    {
        Console.WriteLine("=== Add Book ===");
        Console.Write("Enter Book Name: ");
        var bookName = Console.ReadLine();
        Console.Write("Enter Author Name: ");
        var authorName = Console.ReadLine();
        Console.Write("Enter Number of Copies: ");
        var copiesAvailable = int.Parse(Console.ReadLine());

        try
        {
            _libraryService.AddBook(bookName, authorName, copiesAvailable);
            Console.WriteLine("Book added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void UpdateBook()
    {
        Console.WriteLine("=== Update Book ===");
        ViewAllBooks();
        Console.Write("Enter book ID: ");
        var bookID = int.Parse(Console.ReadLine());
        Console.Write("Enter new book name: ");
        var newBookName = Console.ReadLine();
        Console.Write("Enter new author name: ");
        var newAuthorName = Console.ReadLine();
        Console.Write("Enter new number of copies (or leave blank to keep current): ");
        var newCopies = int.TryParse(Console.ReadLine(), out var copies) ? copies : -1;

        try
        {
            _libraryService.UpdateBook(bookID, newBookName, newAuthorName, true, newCopies);
            Console.WriteLine("Book updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void DeleteBook()
    {
        Console.WriteLine("=== Delete Book ===");
        ViewAllBooks();
        Console.Write("Enter Book ID: ");
        var bookID = int.Parse(Console.ReadLine());

        try
        {
            _libraryService.DeleteBook(bookID);
            Console.WriteLine("Book deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ViewAllBooks()
    {
        Console.WriteLine("=== All Books ===");

        try
        {
            var books = _libraryService.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine(
                    $"ID: {book.ID}, Name: {book.BookName}, Author: {book.AuthorName}, Is available: {book.IsAvailable}, Copies: {book.CopiesAvailable}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
        private void AddMember()
    {
        Console.WriteLine("=== Add member ===");
        Console.Write("Enter member name: ");
        var newName = Console.ReadLine();
        Console.Write("Enter member email: ");
        var newEmail = Console.ReadLine();
        Console.Write("Enter member phone number: ");
        var newPhone = Console.ReadLine();

        try
        {
            _libraryService.AddMember(newName, newEmail, newPhone);
            Console.WriteLine("Member added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void UpdateMember()
    {
        Console.WriteLine("=== Update member ===");
        ViewAllMembers();
        Console.Write("Enter member ID: ");
        var memberID = int.Parse(Console.ReadLine());
        Console.Write("Enter new member name: ");
        var newName = Console.ReadLine();
        Console.Write("Enter new member email: ");
        var newEmail = Console.ReadLine();
        Console.Write("Enter new member phone number: ");
        var newPhone = Console.ReadLine();

        try
        {
            _libraryService.UpdateMember(memberID, newName, newEmail, newPhone);
            Console.WriteLine("Member updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void DeleteMember()
    {
        Console.WriteLine("=== Delete member ===");
        ViewAllBooks();
        Console.Write("Enter member ID: ");
        var memberID = int.Parse(Console.ReadLine());

        try
        {
            _libraryService.DeleteMember(memberID);
            Console.WriteLine("Member deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    private void ViewAllMembers()
    {
        Console.WriteLine("=== All Members ===");
        try
        {
            var members = _libraryService.GetAllMembers();
            foreach (var member in members)
            {
                Console.WriteLine(
                    $"ID: {member.ID}, Name: {member.Name}, Email: {member.Email}, Phone number: {member.PhoneNumber}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void BorrowBook()
    {
        Console.WriteLine("=== Borrow Book ===");
        ViewAllMembers();
        Console.Write("Enter Member ID: ");
        var memberID = int.Parse(Console.ReadLine());
        ViewAllBooks();
        Console.Write("Enter Book ID: ");
        var bookID = int.Parse(Console.ReadLine());

        try
        {
            _libraryService.BorrowBook(memberID, bookID);
            Console.WriteLine("Book borrowed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ReturnBook()
    {
        Console.WriteLine("=== Return Book ===");
        ViewAllMembers();
        Console.Write("Enter member ID: ");
        ViewActiveLoansForMember();
        Console.Write("Enter Loan ID: ");
        var loanID = int.Parse(Console.ReadLine());

        try
        {
            _libraryService.ReturnBook(loanID);
            Console.WriteLine("Book returned successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ReviewBook()
    {
        Console.WriteLine("=== Review Book ===");
        ViewAllMembers();
        var memberID = int.Parse(Console.ReadLine());
        ViewMemberBorrowedBooks(memberID);
        Console.Write("Enter Book ID: ");
        var bookID = int.Parse(Console.ReadLine());
        Console.Write("Enter Rating (1-5): ");
        var rating = int.Parse(Console.ReadLine());
        Console.Write("Enter Review Text: ");
        var reviewText = Console.ReadLine();

        try
        {
            _libraryService.AddReviewToBook(memberID, bookID, rating, reviewText);
            Console.WriteLine("Review added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ViewMemberBorrowedBooks(int memberID)
    {
        Console.WriteLine("=== Member Borrowed Books ===");

        try
        {
            var books = _libraryService.GetReturnedBooksByMember(memberID);
            foreach (var book in books)
            {
                Console.WriteLine(
                    $"ID: {book.ID}, Name: {book.BookName}, Author: {book.AuthorName}, Is available: {book.IsAvailable}, Copies: {book.CopiesAvailable}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void DeleteReview()
    {
        Console.WriteLine("=== Delete Review ===");
        
        var memberID = ViewMemberReviews();
        Console.Write("Enter Review ID: ");
        var reviewID = int.Parse(Console.ReadLine());
        
        try
        {
            _libraryService.DeleteReviewFromBook(reviewID, memberID);
            Console.WriteLine("Review deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private int ViewMemberReviews()
    {
        ViewAllMembers();
        Console.Write("Enter member ID: ");
        var memberID = int.Parse(Console.ReadLine());
        var reviews = _libraryService.GetReviewsByMember(memberID);
        foreach (var review in reviews)
        {
            Console.WriteLine($"ID: {review.ID}, Rating: {review.Rating}, Comments: {review.Comments}, Book name: {review.Book.BookName}, Member name: {review.Member.Name}");
        }
        return memberID;
    }

    private void SearchBooksByTitle()
    {
        Console.WriteLine("=== Search Books by Title ===");
        Console.Write("Enter partial or full book title: ");
        var title = Console.ReadLine();

        try
        {
            var books = _libraryService.SearchBook(title);
            foreach (var book in books)
            {
                Console.WriteLine(
                    $"ID: {book.ID}, Name: {book.BookName}, Author: {book.AuthorName}, Available: {book.IsAvailable}, Copies: {book.CopiesAvailable}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ViewActiveLoansForMember()
    {
        Console.WriteLine("=== Active Loans for Member ===");
        ViewAllMembers();
        Console.Write("Enter Member ID: ");
        var memberID = int.Parse(Console.ReadLine());

        try
        {
            var loans = _libraryService.GetAllActiveLoansForMember(memberID);
            foreach (var loan in loans)
            {
                Console.WriteLine(
                    $"Loan ID: {loan.ID}, Book: {loan.Book.BookName}, Borrowed: {loan.LoanDate}, Status: {loan.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ViewLoanHistoryForMember()
    {
        Console.WriteLine("=== Loan History for Member ===");
        ViewAllMembers();
        Console.Write("Enter Member ID: ");
        var memberID = int.Parse(Console.ReadLine());

        try
        {
            var loans = _libraryService.GetLoanHistoryForMember(memberID);
            foreach (var loan in loans)
            {
                Console.WriteLine(
                    $"Loan ID: {loan.ID}, Book: {loan.Book.BookName}, Borrowed: {loan.LoanDate}, Returned: {loan.ReturnDate?.ToString() ?? "Not yet"}, Status: {loan.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ViewReviewsOfBook()
    {
        Console.WriteLine("=== Reviews of Book ===");
        ViewAllBooks();
        Console.Write("Enter Book ID: ");
        var bookID = int.Parse(Console.ReadLine());
        
        try
        {
            var reviews = _libraryService.GetAllReviewsOfBook(bookID);
            foreach (var review in reviews)
            {
                Console.WriteLine($"ID: {review.ID}, Rating: {review.Rating}, Comments: {review.Comments}, Member name: {review.Member.Name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}