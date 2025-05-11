namespace SiemensDotNetProblem.Model;

public class Member : Person
{
    public List<Loan> Loans { get; set; }
    public List<Loan> LoanHistory { get; set; }
    
    public Member(int id, string name, string email, string phoneNumber)
        : base(id, name, email, phoneNumber)
    {
        Loans = new List<Loan>();
        LoanHistory = new List<Loan>();
    }
}