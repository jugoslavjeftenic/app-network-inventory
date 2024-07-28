using NetworkInventory.Maui.ViewModels;

namespace NetworkInventory.Maui.Views;

public partial class AddDevicePage : ContentPage
{
	private readonly DeviceViewModel _deviceViewModel;

	public AddDevicePage(DeviceViewModel deviceViewModel)
	{
		InitializeComponent();
		_deviceViewModel = deviceViewModel;

		BindingContext = _deviceViewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		_deviceViewModel.Device = new CoreBusiness.Device();
	}
}