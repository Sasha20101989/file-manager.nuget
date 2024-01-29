namespace File.Manager
{
    public interface IFileManager
    {
        T Read<T>(string folderPath, string fileName);

        void Save<T>(string folderPath, string fileName, T content);

        void Delete(string folderPath, string fileName);
    }
}
