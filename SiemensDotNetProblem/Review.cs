namespace SiemensDotNetProblem;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public Book Book { get; set; }
    public Member Member { get; set; }

    public Review(int id, int rating, string description, Book book, Member member)
    {
        Id = id;
        Rating = rating;
        Description = description;
        Book = book;
        Member = member;
    }
}