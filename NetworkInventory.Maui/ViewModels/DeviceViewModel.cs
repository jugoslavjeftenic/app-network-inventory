using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetworkInventory.Maui.Views;
using NetworkInventory.UseCases.Interfaces;
using System.Diagnostics;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.ViewModels;

public partial class DeviceViewModel : ObservableObject
{
	private Device? _device;
	private readonly IViewDeviceUseCase _viewDeviceUseCase;
	private readonly IEditDeviceUseCase _editDeviceUseCase;

	public Device? Device
	{
		get => _device;
		set
		{
			SetProperty(ref _device, value);
		}
	}

	public DeviceViewModel(IViewDeviceUseCase viewDeviceUseCase,
		IEditDeviceUseCase editDeviceUseCase)
	{
		Device = new();
		_viewDeviceUseCase = viewDeviceUseCase;
		_editDeviceUseCase = editDeviceUseCase;
	}

	public async Task LoadDevice(int deviceId)
	{
		this.Device = await _viewDeviceUseCase.ExecuteAsync(deviceId);
	}

	[RelayCommand]
	public async Task EditDevice()
	{
		if (Device is not null)
		{
			await _editDeviceUseCase.ExecuteAsync(Device.Id, Device);
			//await Shell.Current.GoToAsync($"{nameof(DevicesPage)}");
			await Shell.Current.GoToAsync("..");
		}
	}

	[RelayCommand]
	public async Task BackToDevices()
	{
		//await Shell.Current.GoToAsync($"{nameof(DevicesPage)}");
		await Shell.Current.GoToAsync("..");
	}
}
