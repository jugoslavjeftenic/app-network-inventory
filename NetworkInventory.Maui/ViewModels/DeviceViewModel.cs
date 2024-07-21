using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetworkInventory.Maui.Models;
using Device = NetworkInventory.Maui.Models.Device;

namespace NetworkInventory.Maui.ViewModels;

public partial class DeviceViewModel : ObservableObject
{
	private Device? _device;
	public Device? Device
	{
		get => _device;
		set
		{
			SetProperty(ref _device, value);
		}
	}

	public DeviceViewModel()
	{
		Device = new();
	}

	public void LoadDevice(int deviceId)
	{
		Device = DevicesRepository.GetDeviceById(deviceId);
	}

	[RelayCommand]
	public void SaveDevice()
	{
		if (Device is not null)
		{
			DevicesRepository.UpdateDevice(Device.Id, Device);
		}
	}
}
