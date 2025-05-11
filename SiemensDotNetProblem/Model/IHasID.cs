namespace SiemensDotNetProblem.Model;

public interface IHasID
{
    int ID { get; set; }

    public int GetID();

}