using NetworkInventory.Maui.ViewModels;

namespace NetworkInventory.Maui.Views;

public partial class DevicesPage : ContentPage
{
	private readonly DevicesViewModel _devicesViewModel;

	public DevicesPage(DevicesViewModel devicesViewModel)
	{
		InitializeComponent();
		_devicesViewModel = devicesViewModel;

		BindingContext = _devicesViewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await _devicesViewModel.LoadDevicesAsync();
	}
}