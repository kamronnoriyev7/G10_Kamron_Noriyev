namespace FileManagmentService;

public interface IStorageService
{
    Task CreateFolder(string folderPath);
    Task UploadFile(string filePath, Stream stream);
    Task UploadFileChunks(string folderPath,  Stream fileStream);
    Task DeleteFile(string filePath);
    Task DeleteFolder(string folderPath);
    Task<Stream> DownloadFile(string filePath);
    Task<Stream> DownloadFolderAzZip(string folderPath);
    Task<List<string>> GetContentOfTxtFile();
    Task UpdateContentOfTxtFile(string filePath, string newContent);
    Task<List<string>> GetAllInFolderPath(string folderPath);


}