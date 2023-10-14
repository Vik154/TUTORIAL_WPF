namespace StartUpMVVM.Services.Interfaces;

internal interface IWebServerService {
    bool Enabled { get; set; }

    void Start();

    void Stop();
}
