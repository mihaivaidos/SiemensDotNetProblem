namespace SiemensDotNetProblem.LibraryModel;

public class Loan : IHasID
{
    public int ID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Status { get; set; }
    public Book Book { get; set; }
    public Member Member { get; set; }

    public Loan(int id, DateTime startDate, DateTime endDate, DateTime returnDate, string status, Book book, Member member)
    {
        ID = id;
        StartDate = startDate;
        EndDate = endDate;
        ReturnDate = returnDate;
        Status = status;
        Book = book;
        Member = member;
    }
}