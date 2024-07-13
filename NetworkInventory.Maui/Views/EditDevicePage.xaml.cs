using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NetworkInventory.UseCases.Interfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.Views;

[QueryProperty(nameof(DeviceId), "Id")]
public partial class EditDevicePage : ContentPage
{
	private Device? _device;
	private readonly IViewDeviceUseCase _viewDeviceUseCase;

	public EditDevicePage(IViewDeviceUseCase viewDeviceUseCase)
	{
		InitializeComponent();
		_viewDeviceUseCase = viewDeviceUseCase;
	}

	public string DeviceId
	{
		set
		{
			_device = _viewDeviceUseCase
				.ExecuteAsync(int.Parse(value))
				.GetAwaiter()
				.GetResult();
			if (_device is not null)
			{
				DeviceControl.Name = _device.Name;
				DeviceControl.SerialNumber = _device.SerialNumber;
				DeviceControl.IPv4 = _device.IPv4;
				DeviceControl.SubnetMask = _device.SubnetMask;
				DeviceControl.Gateway = _device.Gateway;
				DeviceControl.PreferredDNS = _device.PreferredDNS;
				DeviceControl.AlternateDNS = _device.AlternateDNS;
				DeviceControl.Vlan = _device.Vlan;
				DeviceControl.UpstreamDevice = _device.UpstreamDevice;
				DeviceControl.Location = _device.Location;
				DeviceControl.User = _device.User;
			}
		}
	}

	private void DeviceControl_OnSave(object sender, EventArgs e)
	{
		if (_device is not null)
		{
			_device.Name = DeviceControl.Name ?? "";
			_device.SerialNumber = DeviceControl.SerialNumber ?? "";
			_device.IPv4 = DeviceControl.IPv4 ?? "";
			_device.SubnetMask = DeviceControl.SubnetMask ?? "";
			_device.Gateway = DeviceControl.Gateway ?? "";
			_device.PreferredDNS = DeviceControl.PreferredDNS ?? "";
			_device.AlternateDNS = DeviceControl.AlternateDNS ?? "";
			_device.Vlan = DeviceControl.Vlan ?? "";
			_device.UpstreamDevice = DeviceControl.UpstreamDevice ?? "";
			_device.Location = DeviceControl.Location ?? "";
			_device.User = DeviceControl.User ?? "";

			//DevicesRepository.UpdateDevice(_device.Id, _device);
			Shell.Current.GoToAsync("..");
		}
	}

	private void DeviceControl_OnCancel(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	private static void DeviceControl_OnError(object sender, string e)
	{
		var toast = Toast.Make(e, ToastDuration.Short);
		toast.Show();
	}
}