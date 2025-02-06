namespace FileManagmentService;

public class StorageService: IStorageService
{
    public async Task CreateFolder(string folderPath)
    {
        await CreateFolder(folderPath);
    }

    public async Task UploadFile(string filePath, Stream stream)
    {
        await UploadFile(filePath, stream);
    }

    public async Task UploadFileChunks(string folderPath, Stream fileStream)
    {
        await UploadFileChunks(folderPath, fileStream);
    }

    public async Task DeleteFile(string filePath)
    {
        await DeleteFile(filePath);
    }

    public async Task DeleteFolder(string folderPath)
    {
        await DeleteFolder(folderPath);
    }

    public async Task<Stream> DownloadFile(string filePath)
    {
       return await DownloadFile(filePath);
    }

    public async Task<Stream> DownloadFolderAzZip(string folderPath)
    {
       return await DownloadFolderAzZip(folderPath);
    }

    public async Task<List<string>> GetContentOfTxtFile()
    {
        return await GetContentOfTxtFile();
    }

    public async Task UpdateContentOfTxtFile(string filePath, string newContent)
    {
        await UpdateContentOfTxtFile(filePath, newContent);
    }

    public async Task<List<string>> GetAllInFolderPath(string folderPath)
    {
        return await GetAllInFolderPath(folderPath);
    }
}

