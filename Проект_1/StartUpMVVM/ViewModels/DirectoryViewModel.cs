using StartUpMVVM.ViewModels.Base;
using System.IO;


namespace StartUpMVVM.ViewModels;


class DirectoryViewModel : ViewModel {
    private readonly DirectoryInfo _DirectoryInfo;
    public string Name => _DirectoryInfo.Name;
    public string Path => _DirectoryInfo.FullName;
    public DateTime CreationTime => _DirectoryInfo.CreationTime;

    public DirectoryViewModel(string Path) => _DirectoryInfo = new DirectoryInfo(Path);    

    public IEnumerable<DirectoryViewModel> SubDirectories => _DirectoryInfo
        .EnumerateDirectories()
        .Select(dir_info => new DirectoryViewModel(dir_info.FullName));

    public IEnumerable<FileViewModel> Files => _DirectoryInfo
        .EnumerateFiles()
        .Select(file => new FileViewModel(file.FullName));

    public IEnumerable<object> DirectoryItems => SubDirectories.Cast<object>().Concat(Files);
}


class FileViewModel : ViewModel {
    private FileInfo _FileInfo;
    public string Name => _FileInfo.Name;
    public string Path => _FileInfo.FullName;
    public DateTime CreationTime => _FileInfo.CreationTime;

    public FileViewModel(string path) => _FileInfo = new FileInfo(path);
}
