namespace SiemensDotNetProblem.Model;

    public class Book : IHasID {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public bool IsAvailable { get; set; }
        public int CopiesAvailable { get; set; }
        public List<Review> Reviews { get; set; }

        public Book(int bookID, string bookName, string authorName, bool isAvailable, int copiesAvailable)
        {
            ID = bookID;
            BookName = bookName;
            AuthorName = authorName;
            IsAvailable = isAvailable;
            CopiesAvailable = copiesAvailable;
            Reviews = new List<Review>();
        }

        public int GetID() => ID;
    }