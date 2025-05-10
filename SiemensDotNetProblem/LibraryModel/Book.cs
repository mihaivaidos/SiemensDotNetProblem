namespace SiemensDotNetProblem.LibraryModel;

public class Book : IHasID
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }
    public int Quantity { get; set; }

    public Book(int id, string title, string author, bool isAvailable, int quantity)
    {
        ID = id;
        Title = title;
        Author = author;
        IsAvailable = isAvailable;
        Quantity = quantity;
    }
}