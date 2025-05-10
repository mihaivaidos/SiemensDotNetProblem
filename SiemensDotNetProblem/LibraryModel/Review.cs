namespace SiemensDotNetProblem.LibraryModel;

public class Review : IHasID
{
    public int ID { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public Book Book { get; set; }
    public Member Member { get; set; }

    public Review(int id, int rating, string description, Book book, Member member)
    {
        ID = id;
        Rating = rating;
        Description = description;
        Book = book;
        Member = member;
    }
}