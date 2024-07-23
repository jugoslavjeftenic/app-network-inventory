using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NetworkInventory.UseCases.Interfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.Views;

public partial class AddDevicePage : ContentPage
{
	private readonly IAddDeviceUseCase _addDeviceUseCase;

	public AddDevicePage(IAddDeviceUseCase addDeviceUseCase)
	{
		InitializeComponent();
		_addDeviceUseCase = addDeviceUseCase;
	}

	//private async void DeviceControl_OnSave(object sender, EventArgs e)
	//{
	//	await _addDeviceUseCase.ExecuteAsync(new Device
	//	{
	//		Name = DeviceControl.Name ?? "",
	//		SerialNumber = DeviceControl.SerialNumber ?? "",
	//		IPv4 = DeviceControl.IPv4 ?? "",
	//		SubnetMask = DeviceControl.SubnetMask ?? "",
	//		Gateway = DeviceControl.Gateway ?? "",
	//		PreferredDNS = DeviceControl.PreferredDNS ?? "",
	//		AlternateDNS = DeviceControl.AlternateDNS ?? "",
	//		Vlan = DeviceControl.Vlan ?? "",
	//		UpstreamDevice = DeviceControl.UpstreamDevice ?? "",
	//		Location = DeviceControl.Location ?? "",
	//		User = DeviceControl.User ?? "",
	//	});

	//	await Shell.Current.GoToAsync("..");
	//}

	private void DeviceControl_OnCancel(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	private void DeviceControl_OnError(object sender, string e)
	{
		var toast = Toast.Make(e, ToastDuration.Short);
		toast.Show();
	}
}