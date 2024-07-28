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

	private string _filterText = "";
	public string FilterText
	{
		get { return _filterText; }
		set
		{
			_filterText = value;
			LoadDevicesAsync(_filterText).ConfigureAwait(true);
		}
	}

	public async Task LoadDevicesAsync(string filterText = "")
	{
		Devices.Clear();

		var devices = await _viewDevicesUseCase.ExecuteAsync(filterText);
		if (devices.Count > 0)
		{
			foreach (var device in devices)
			{
				Devices.Add(device);
			}
		}
	}

	[RelayCommand]
	public async Task GoToAddDevice()
	{
		await Shell.Current.GoToAsync($"{nameof(AddDevicePage)}");
		await LoadDevicesAsync();
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
