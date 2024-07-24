using NetworkInventory.UseCases.Interfaces;
using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases;

public class ViewDevicesUseCase(IDeviceRepository devicesRepository) : IViewDevicesUseCase
{
	private readonly IDeviceRepository _devicesRepository = devicesRepository;

	public async Task<List<Device>> ExecuteAsync(string filterText)
	{
		return await _devicesRepository.GetDevicesAsync(filterText);
	}
}
