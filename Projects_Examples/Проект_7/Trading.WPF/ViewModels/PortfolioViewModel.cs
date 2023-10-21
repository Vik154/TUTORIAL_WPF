using Trading.WPF.State.Assets;

namespace Trading.WPF.ViewModels;

public class PortfolioViewModel : BaseViewModel {
    public AssetListingViewModel AssetListingViewModel { get; }

    public PortfolioViewModel(AssetStore assetStore) {
        AssetListingViewModel = new AssetListingViewModel(assetStore);
    }

    public override void Dispose() {
        AssetListingViewModel.Dispose();

        base.Dispose();
    }
}
