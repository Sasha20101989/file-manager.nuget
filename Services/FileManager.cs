using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace File.Manager
{
    public class FileManager : IFileManager
    {
        public T Read<T>(string folderPath, string fileName)
        {
            string path = Path.Combine(folderPath, fileName);
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default;
        }

        public void Save<T>(string folderPath, string fileName, T content)
        {
            if (!Directory.Exists(folderPath))
            {
                _ = Directory.CreateDirectory(folderPath);
            }

            string fileContent = JsonConvert.SerializeObject(content);
            System.IO.File.WriteAllText(Path.Combine(folderPath, fileName), fileContent, Encoding.UTF8);
        }

        public void Delete(string folderPath, string fileName)
        {
            if (fileName != null && System.IO.File.Exists(Path.Combine(folderPath, fileName)))
            {
                System.IO.File.Delete(Path.Combine(folderPath, fileName));
            }
        }
    }
}
