namespace SiemensDotNetProblem;

public class Member
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
    public List<Loan> Loans { get; set; }
    public List<Loan> LoanHistory { get; set; }
    
    public Member(int id, string name, string email, bool isAdmin)
    {
        Id = id;
        Name = name;
        Email = email;
        IsAdmin = isAdmin;
        Loans = new List<Loan>();
        LoanHistory = new List<Loan>();
    }

}