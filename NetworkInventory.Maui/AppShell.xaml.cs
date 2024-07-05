using NetworkInventory.Maui.Views;

namespace NetworkInventory.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DevicesPage), typeof(DevicesPage));
		Routing.RegisterRoute(nameof(AddDevicePage), typeof(AddDevicePage));
		Routing.RegisterRoute(nameof(EditDevicePage), typeof(EditDevicePage));
	}
}
