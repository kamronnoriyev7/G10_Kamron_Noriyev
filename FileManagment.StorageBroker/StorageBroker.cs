using System.IO.Compression;
using System.Net;

namespace FileManagment.StorageBroker;

public class StorageBroker : IStorageBrokerService
{
    private IStorageBrokerService _storageBrokerService;

    private string _dataPath;

    public StorageBroker()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public async Task CreateFolder(string folderPath)
    {
        folderPath = Path.Combine(_dataPath, folderPath);
        ValidateDirectory(folderPath);
        Directory.CreateDirectory(folderPath);
    }

    public async Task UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        ValidateDirectory(filePath);
        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }
    }

    public async Task UploadFileChunks(string folderPath, Stream fileStream)
    {
        folderPath = Path.Combine(_dataPath, folderPath);
        ValidateDirectory(folderPath);

        var bytes = 1024 * 1024 * 10;
        byte[] buffer = new byte[bytes];
        int bytesRead;

        using (var fileStream1 = new FileStream(_dataPath, FileMode.Open, FileAccess.Read))
        {
            using (var newfileStream = new FileStream(_dataPath, FileMode.Create, FileAccess.Write))
            {
                while (true)
                {
                    bytesRead = await fileStream1.ReadAsync(buffer, 0, bytes);
                    if (bytesRead <= 0) break;
                    await newfileStream.WriteAsync(buffer, 0, bytesRead);
                }
            }
        }
    }


    public async Task DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        ValidateDirectory(filePath);
        File.Delete(filePath);
    }

    public async Task DeleteFolder(string folderPath)
    {
        folderPath = Path.Combine(_dataPath, folderPath);
        ValidateDirectory(folderPath);
        Directory.Delete(folderPath, true);
    }

    public async Task<Stream> DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found");
        }

        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<Stream> DownloadFolderAzZip(string folderPath)
    {
        if (Path.GetExtension(folderPath) != string.Empty)
        {
            throw new Exception("Invalid file extension");
        }

        folderPath = Path.Combine(_dataPath, folderPath);
        if (!Directory.Exists(folderPath))
        {
            throw new DirectoryNotFoundException("Folder not found");
        }

        var zipPath = folderPath + ".zip";
        ZipFile.CreateFromDirectory(folderPath, zipPath);
        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<List<string>> GetContentOfTxtFile()
    {
        var files = Directory.GetFiles(_dataPath);
        return files.ToList();
    }

    public async Task UpdateContentOfTxtFile(string filePath, string newContent)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found");
        }

        var writer = new StreamWriter(filePath);
        await writer.WriteLineAsync(newContent);
    }

    public async Task<List<string>> GetFilesInFolder(string folderPath)
    {
        folderPath = Path.Combine(_dataPath, folderPath);
        var files = Directory.GetFiles(folderPath);
        return files.ToList();
    }

    public async Task<List<string>> GetAllInFolderPath(string folderPath)
    {
        folderPath = Path.Combine(_dataPath, folderPath);
        if (!Directory.Exists(folderPath))
        {
            throw new DirectoryNotFoundException("Folder not found");
        }
        var files =  Directory.GetFiles(folderPath);
        return files.ToList();
    }

    private void ValidateDirectory(string directoryPath)
    {
        if (File.Exists(directoryPath))
        {
            throw new Exception("Folder already exists");
        }

        var root = Directory.GetParent(directoryPath);
        if (!Directory.Exists(root?.FullName))
        {
            throw new Exception("folder does not exist");
        }
    }
}