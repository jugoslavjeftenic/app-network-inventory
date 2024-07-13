using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NetworkInventory.Maui.Models;
using Device = NetworkInventory.Maui.Models.Device;

namespace NetworkInventory.Maui.Views;

public partial class AddDevicePage : ContentPage
{
	public AddDevicePage()
	{
		InitializeComponent();
	}

	private void DeviceControl_OnSave(object sender, EventArgs e)
	{
		DevicesRepository.AddDevice(new Device()
		{
			Name = DeviceControl.Name,
			SerialNumber = DeviceControl.SerialNumber,
			IPv4 = DeviceControl.IPv4,
			SubnetMask = DeviceControl.SubnetMask,
			PreferredDNS = DeviceControl.PreferredDNS,
			AlternateDNS = DeviceControl.AlternateDNS,
			Vlan = DeviceControl.Vlan,
			UpstreamDevice = DeviceControl.UpstreamDevice,
			Location = DeviceControl.Location,
			User = DeviceControl.User,
		});

		Shell.Current.GoToAsync("..");
	}

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