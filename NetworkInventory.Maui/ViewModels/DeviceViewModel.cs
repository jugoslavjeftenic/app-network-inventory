using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetworkInventory.Maui.Models;
using NetworkInventory.UseCases.Interfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.ViewModels;

public partial class DeviceViewModel : ObservableObject
{
	private Device? _device;
	private readonly IViewDeviceUseCase _viewDeviceUseCase;

	public Device? Device
	{
		get => _device;
		set
		{
			SetProperty(ref _device, value);
		}
	}

	public DeviceViewModel(IViewDeviceUseCase viewDeviceUseCase)
	{
		Device = new();
		_viewDeviceUseCase = viewDeviceUseCase;
	}

	public async Task LoadDevice(int deviceId)
	{
		Device = await _viewDeviceUseCase.ExecuteAsync(deviceId);
	}

	//[RelayCommand]
	//public void SaveDevice()
	//{
	//	if (Device is not null)
	//	{
	//		DevicesRepository.UpdateDevice(Device.Id, Device);
	//	}
	//}
}
