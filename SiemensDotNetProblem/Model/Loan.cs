using SiemensDotNetProblem;

namespace SiemensDotNetProblem.Model;

public class Loan : IHasID
{
    public int ID { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; }
    public Book Book { get; set; }
    public Member Member { get; set; }
    
    public Loan(int loanID, DateTime loanDate, DateTime dueDate, DateTime? returnDate, string status, Book book, Member member)
    {
        ID = loanID;
        LoanDate = loanDate;
        DueDate = dueDate;
        ReturnDate = returnDate;
        Status = status;
        Book = book;
        Member = member;
    }

    public int GetID()
    {
        return ID;
    }
}