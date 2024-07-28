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

	//private readonly IViewDevicesUseCase _viewDevicesUseCase;
	//private readonly IDeleteDeviceUseCase _deleteDeviceUseCase;

	//public DevicesPage
	//	(IViewDevicesUseCase viewDevicesUseCase, IDeleteDeviceUseCase deleteDeviceUseCase)
	//{
	//	InitializeComponent();
	//	_viewDevicesUseCase = viewDevicesUseCase;
	//	_deleteDeviceUseCase = deleteDeviceUseCase;
	//}

	//protected override void OnAppearing()
	//{
	//	base.OnAppearing();
	//	FilterBar.Text = string.Empty;
	//	LoadDevices();
	//}

	//private async void DevicesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	//{
	//	if (DevicesList.SelectedItem is not null)
	//	{
	//		await Shell
	//			.Current
	//			.GoToAsync($"{nameof(EditDevicePage)}?Id={((Device)DevicesList.SelectedItem).Id}");
	//	}
	//}

	//private void DevicesList_ItemTapped(object sender, ItemTappedEventArgs e)
	//{
	//	DevicesList.SelectedItem = null;
	//}

	//private void AddDeviceBtn_Clicked(object sender, EventArgs e)
	//{
	//	Shell.Current.GoToAsync(nameof(AddDevicePage));
	//}

	//private async void DeleteMenuItem_Clicked(object sender, EventArgs e)
	//{
	//	var menuItem = sender as MenuItem;
	//	var device = menuItem?.CommandParameter as Device;

	//	if (device is not null)
	//	{
	//		await _deleteDeviceUseCase.ExecuteAsync(device.Id);
	//		LoadDevices();
	//	}
	//}

	//private async void LoadDevices()
	//{
	//	var devices = new ObservableCollection<Device>
	//		(await _viewDevicesUseCase.ExecuteAsync(string.Empty));
	//	DevicesList.ItemsSource = devices;
	//}

	//private async void FilterBar_TextChanged(object sender, TextChangedEventArgs e)
	//{
	//	var devices = new ObservableCollection<Device>
	//		(await _viewDevicesUseCase.ExecuteAsync(((SearchBar)sender).Text));
	//	DevicesList.ItemsSource = devices;
	//}
}