using NetworkInventory.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Maui.ViewModels;

public class DevicesViewModel(IViewDevicesUseCase viewDevicesUseCase)
{
	private readonly IViewDevicesUseCase _viewDevicesUseCase = viewDevicesUseCase;

	public ObservableCollection<Device> Devices { get; set; } = [];

	public async Task LoadDevicesAsync()
	{
		Devices.Clear();

		var devices = await _viewDevicesUseCase.ExecuteAsync(string.Empty);
		if (devices.Count > 0)
		{
			foreach (var device in devices)
			{
				Devices.Add(device);
			}
		}
	}
}
