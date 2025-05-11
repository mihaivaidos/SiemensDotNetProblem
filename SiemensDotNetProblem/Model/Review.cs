namespace SiemensDotNetProblem.Model;

public class Review : IHasID
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
        
        public Review(int reviewID, int rating, string comments, Book book, Member member)
        {
            ID = reviewID;
            Rating = rating;
            Comments = comments;
            Book = book;
            Member = member;
        }

        public int GetID()
        {
            return ID;
        }
    }