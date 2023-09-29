using StartUpMVVM.ViewModels.Base;
using System.Diagnostics;
using System.IO;


namespace StartUpMVVM.ViewModels;


class DirectoryViewModel : ViewModel {
    private readonly DirectoryInfo _DirectoryInfo;
    public string Name => _DirectoryInfo.Name;
    public string Path => _DirectoryInfo.FullName;
    public DateTime CreationTime => _DirectoryInfo.CreationTime;

    public DirectoryViewModel(string Path) => _DirectoryInfo = new DirectoryInfo(Path);    

    public IEnumerable<DirectoryViewModel> SubDirectories {
        get {
            try {
                return _DirectoryInfo
                    .EnumerateDirectories()
                    .Select(dir_info => new DirectoryViewModel(dir_info.FullName));
            }
            catch (UnauthorizedAccessException exp) {
                Debug.WriteLine(exp.Message);
            }
            return Enumerable.Empty<DirectoryViewModel>();
        }
    }

    public IEnumerable<FileViewModel> Files {
        get {
            try {
                var files = _DirectoryInfo
                    .EnumerateFiles()
                    .Select(file => new FileViewModel(file.FullName));
                return files;
            }
            catch (UnauthorizedAccessException exp) {
                Debug.WriteLine(exp.Message);
            }
            return Enumerable.Empty<FileViewModel>();
        }
    }

    public IEnumerable<object> DirectoryItems {
        get {
            try {
                return SubDirectories.Cast<object>().Concat(Files);
            }
            catch (UnauthorizedAccessException exp) {
                Debug.WriteLine(exp.Message);
            }
            return Enumerable.Empty<object>();
        }
    }
}


class FileViewModel : ViewModel {
    private FileInfo _FileInfo;
    public string Name => _FileInfo.Name;
    public string Path => _FileInfo.FullName;
    public DateTime CreationTime => _FileInfo.CreationTime;

    public FileViewModel(string path) => _FileInfo = new FileInfo(path);
}
