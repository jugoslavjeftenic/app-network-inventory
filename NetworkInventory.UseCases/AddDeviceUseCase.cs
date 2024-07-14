using NetworkInventory.UseCases.Interfaces;
using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases;

public class AddDeviceUseCase(IDeviceRepository deviceRepository) : IAddDeviceUseCase
{
	private readonly IDeviceRepository _deviceRepository = deviceRepository;

	public async Task ExecuteAsync(Device device)
	{
		await _deviceRepository.AddDeviceAsync(device);
	}
}
