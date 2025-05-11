using System.Text.Json;
using SiemensDotNetProblem.Model;

namespace SiemensDotNetProblem.Repository;

    public class FileRepository<T> : IRepository<T> where T : IHasID
    {
        private readonly string _filePath;
        
        public FileRepository(string filePath)
        {
            _filePath = filePath;
            Console.WriteLine($"File path: {_filePath}");
            CreateDirectories();
        }

        public void Add(T obj)
        {
            Console.WriteLine($"Adding object with ID: {obj.GetID()}");
            DoInFile(data => data[obj.GetID()] = obj);
        }

        public T Get(int id)
        {
            return ReadDataFromFile().GetValueOrDefault(id);
        }

        public void Update(T obj)
        {
            Console.WriteLine($"Updating object with ID: {obj.GetID()}");
            DoInFile(data => data[obj.GetID()] = obj);
        }

        public void Delete(int id)
        {
            Console.WriteLine($"Deleting object with ID: {id}");
            DoInFile(data => data.Remove(id));
        }

        public List<T> GetAll()
        {
            return ReadDataFromFile().Values.ToList();
        }
        
        private void DoInFile(Action<Dictionary<int, T>> action)
        {
            var data = ReadDataFromFile();
            action(data);
            WriteDataToFile(data);
        }
        
        private Dictionary<int, T> ReadDataFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new Dictionary<int, T>();
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<Dictionary<int, T>>(json) ?? new Dictionary<int, T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return new Dictionary<int, T>();
            }
        }

        private void WriteDataToFile(Dictionary<int, T> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
        
        private void CreateDirectories()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine($"Directories created: {directory}");
            }
        }
    }
