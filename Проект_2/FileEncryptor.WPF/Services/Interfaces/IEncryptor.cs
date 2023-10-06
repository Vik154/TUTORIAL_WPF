namespace FileEncryptor.WPF.Services.Interfaces;

// Интерфейс шифратора файлов
internal interface IEncryptor {

    // Шифрует файл по указанному пути
    void Encrypt(string SourcePath, string DestinationPath, 
                 string Password, int BufferLength = 104200);
    
    // Дешифрация файла с возвратом успешного / не успешного значения
    bool Decrypt(string SourcePath, string DestinationPath, 
                 string Password, int BufferLength = 104200);

    // Асинхронные операции шифровки / дешифровки файла
    Task EncryptAsync(string SourcePath, string DestinationPath, 
                      string Password, int BufferLength = 104200, 
                      IProgress<double>? Progress = null, 
                      CancellationToken Cancel = default);

    Task<bool> DecryptAsync(string SourcePath, string DestinationPath, 
                            string Password, int BufferLength = 104200, 
                            IProgress<double>? Progress = null, 
                            CancellationToken Cancel = default);
}
