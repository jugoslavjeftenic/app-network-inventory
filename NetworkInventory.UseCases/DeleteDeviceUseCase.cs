using NetworkInventory.UseCases.Interfaces;
using NetworkInventory.UseCases.PluginInterfaces;

namespace NetworkInventory.UseCases;

public class DeleteDeviceUseCase(IDeviceRepository deviceRepository) : IDeleteDeviceUseCase
{
	private readonly IDeviceRepository _deviceRepository = deviceRepository;

	public async Task ExecuteAsync(int deviceId)
	{
		await _deviceRepository.DeleteDeviceAsync(deviceId);
	}
}
