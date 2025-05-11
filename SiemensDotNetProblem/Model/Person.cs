namespace SiemensDotNetProblem.Model;

    public abstract class Person : IHasID {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        protected Person(int id, string name, string email, string phoneNumber)
        {
            ID = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public int GetID()
        {
            return ID;
        }
    }
