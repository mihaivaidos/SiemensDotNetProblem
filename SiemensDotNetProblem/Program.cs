using SiemensDotNetProblem.Model;
using SiemensDotNetProblem.Repository;
using SiemensDotNetProblem.Service;
using SiemensDotNetProblem.UI;

namespace SiemensDotNetProblem;

class Program
{
    static void Main()
    {
        // Initialize repositories
        // var bookRepo = new FileRepository<Book>("books.json");
        // var loanRepo = new FileRepository<Loan>("loans.json");
        // var reviewRepo = new FileRepository<Review>("reviews.json");
        // var memberRepo = new FileRepository<Member>("members.json");
        var bookRepo = new InMemoryRepository<Book>();
        var loanRepo = new InMemoryRepository<Loan>();
        var reviewRepo = new InMemoryRepository<Review>();
        var memberRepo = new InMemoryRepository<Member>();

        // Initialize service
        var libraryService = new LibraryService(bookRepo, loanRepo, reviewRepo, memberRepo);
        
        // Add example objects
        AddExampleObjects(bookRepo, loanRepo, reviewRepo, memberRepo);

        // Initialize UI
        var libraryUI = new LibraryUI(libraryService);

        // Start the application
        libraryUI.Start();
    }

    private static void AddExampleObjects(IRepository<Book> bookRepo, IRepository<Loan> loanRepo, IRepository<Review> reviewRepo, IRepository<Member> memberRepo)
    {
        var member1 = new Member(1, "Alice Johnson", "alice@example.com", "0123456789");
        var member2 = new Member(2, "Bob Smith", "bob@example.com", "0987654321");
        var member3 = new Member(3, "Steve Smith", "steve@example.com", "0123456789");
        memberRepo.Add(member1);
        memberRepo.Add(member2);
        
        var book1 = new Book(1, "C# Programming", "John Doe", true,  5);
        var book2 = new Book(2, "Introduction to Algorithms", "Thomas H. Cormen", true, 3);
        var book3 = new Book(3, "Clean Code", "Robert C. Martin", true, 4);
        bookRepo.Add(book1);
        bookRepo.Add(book2);
        bookRepo.Add(book3);
    }
}