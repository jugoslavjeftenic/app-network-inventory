using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NetworkInventory.Maui.ViewModels;
using NetworkInventory.UseCases.Interfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.Views;

[QueryProperty(nameof(DeviceId), "Id")]
public partial class EditDevicePage : ContentPage
{
	private readonly DeviceViewModel _deviceViewModel;
	//private Device? _device;
	//private readonly IViewDeviceUseCase _viewDeviceUseCase;
	//private readonly IEditDeviceUseCase _editDeviceUseCase;

	//public EditDevicePage(IViewDeviceUseCase viewDeviceUseCase, IEditDeviceUseCase editDeviceUseCase)
	//{
	//	InitializeComponent();
	//	_viewDeviceUseCase = viewDeviceUseCase;
	//	_editDeviceUseCase = editDeviceUseCase;
	//}

	public EditDevicePage(DeviceViewModel deviceViewModel)
	{
		InitializeComponent();
		_deviceViewModel = deviceViewModel;

		this.BindingContext = _deviceViewModel;
	}

	public string DeviceId
	{
		set
		{
			if (string.IsNullOrWhiteSpace(value) is false &&
				int.TryParse(value, out int deviceId))
			{
				LoadDevice(deviceId);
			}
		}
	}

	private async void LoadDevice(int deviceId)
	{
		await _deviceViewModel.LoadDevice(deviceId);
	}

	//public string DeviceId
	//{
	//	set
	//	{
	//		_device = _viewDeviceUseCase
	//			.ExecuteAsync(int.Parse(value))
	//			.GetAwaiter()
	//			.GetResult();
	//		if (_device is not null)
	//		{
	//			DeviceControl.Name = _device.Name;
	//			DeviceControl.SerialNumber = _device.SerialNumber;
	//			DeviceControl.IPv4 = _device.IPv4;
	//			DeviceControl.SubnetMask = _device.SubnetMask;
	//			DeviceControl.Gateway = _device.Gateway;
	//			DeviceControl.PreferredDNS = _device.PreferredDNS;
	//			DeviceControl.AlternateDNS = _device.AlternateDNS;
	//			DeviceControl.Vlan = _device.Vlan;
	//			DeviceControl.UpstreamDevice = _device.UpstreamDevice;
	//			DeviceControl.Location = _device.Location;
	//			DeviceControl.User = _device.User;
	//		}
	//	}
	//}

	//private async void DeviceControl_OnSave(object sender, EventArgs e)
	//{
	//	if (_device is not null)
	//	{
	//		_device.Name = DeviceControl.Name ?? "";
	//		_device.SerialNumber = DeviceControl.SerialNumber ?? "";
	//		_device.IPv4 = DeviceControl.IPv4 ?? "";
	//		_device.SubnetMask = DeviceControl.SubnetMask ?? "";
	//		_device.Gateway = DeviceControl.Gateway ?? "";
	//		_device.PreferredDNS = DeviceControl.PreferredDNS ?? "";
	//		_device.AlternateDNS = DeviceControl.AlternateDNS ?? "";
	//		_device.Vlan = DeviceControl.Vlan ?? "";
	//		_device.UpstreamDevice = DeviceControl.UpstreamDevice ?? "";
	//		_device.Location = DeviceControl.Location ?? "";
	//		_device.User = DeviceControl.User ?? "";

	//		await _editDeviceUseCase.ExecuteAsync(_device.Id, _device);
	//		await Shell.Current.GoToAsync("..");
	//	}
	//}

	//private void DeviceControl_OnCancel(object sender, EventArgs e)
	//{
	//	Shell.Current.GoToAsync("..");
	//}

	//private static void DeviceControl_OnError(object sender, string e)
	//{
	//	var toast = Toast.Make(e, ToastDuration.Short);
	//	toast.Show();
	//}
}