using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases;

public class ViewDevicesUseCase
{
	private readonly IDeviceRepository _devicesRepository;

	public ViewDevicesUseCase(IDeviceRepository devicesRepository)
	{
		_devicesRepository = devicesRepository;
	}

	public async Task<List<Device>> ExecuteAsync(string filterText)
	{
		return await _devicesRepository.GetDevicesAsync(filterText);
	}
}
