using NetworkInventory.Maui.Models;
using System.Collections.ObjectModel;
using Device = NetworkInventory.Maui.Models.Device;

namespace NetworkInventory.Maui.Views;

public partial class DevicesPage : ContentPage
{
	public DevicesPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		var devices = new ObservableCollection<Device>(DevicesRepository.GetDevices());
		DevicesList.ItemsSource = devices;
	}

	private async void DevicesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (DevicesList.SelectedItem is not null)
		{
			await Shell.Current
				.GoToAsync($"{nameof(EditDevicePage)}?Id={((Device)DevicesList.SelectedItem).Id}");
		}
	}

	private void DevicesList_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		DevicesList.SelectedItem = null;
	}

	private void AddDeviceBtn_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(AddDevicePage));
	}
}