using Shiny;
using Shiny.BluetoothLE;

namespace BluetoothMauiTest1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void HandleScanAndConnectClicked(object sender, EventArgs e)
    {
        // Obtain IBleManager instance
        Shiny.BluetoothLE.IBleManager bleManager = MauiProgram.BleManager;
        // Request access - this works
        var access = await bleManager.RequestAccessAsync();
        // ...this never gets hit
        if(access == AccessState.Available)
        {

        }
    }
}
