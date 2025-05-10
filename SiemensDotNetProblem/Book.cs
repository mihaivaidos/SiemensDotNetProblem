namespace SiemensDotNetProblem;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }
    public int Quantity { get; set; }

    public Book(int id, string title, string author, bool isAvailable, int quantity)
    {
        Id = id;
        Title = title;
        Author = author;
        IsAvailable = isAvailable;
        Quantity = quantity;
    }
}