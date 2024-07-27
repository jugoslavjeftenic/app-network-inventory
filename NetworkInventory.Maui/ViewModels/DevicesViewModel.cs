using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetworkInventory.Maui.Views;
using NetworkInventory.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.ViewModels;

public partial class DevicesViewModel(
	IViewDevicesUseCase viewDevicesUseCase,
	IDeleteDeviceUseCase deleteDeviceUseCase) : ObservableObject
{
	private readonly IViewDevicesUseCase _viewDevicesUseCase = viewDevicesUseCase;
	private readonly IDeleteDeviceUseCase _deleteDeviceUseCase = deleteDeviceUseCase;

	public ObservableCollection<Device> Devices { get; set; } = [];

	public async Task LoadDevicesAsync()
	{
		this.Devices.Clear();

		var devices = await _viewDevicesUseCase.ExecuteAsync(string.Empty);
		if (devices.Count > 0)
		{
			foreach (var device in devices)
			{
				this.Devices.Add(device);
			}
		}
	}

	[RelayCommand]
	public async Task GoToEditDevice(int deviceId)
	{
		await Shell.Current.GoToAsync($"{nameof(EditDevicePage)}?Id={deviceId}");
		await LoadDevicesAsync();
	}

	[RelayCommand]
	public async Task DeleteDevice(int deviceId)
	{
		await _deleteDeviceUseCase.ExecuteAsync(deviceId);
		await LoadDevicesAsync();
	}
}
