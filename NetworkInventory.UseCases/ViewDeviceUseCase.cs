using NetworkInventory.UseCases.Interfaces;
using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases;

public class ViewDeviceUseCase(IDeviceRepository deviceRepository) : IViewDeviceUseCase
{
	private readonly IDeviceRepository _deviceRepository = deviceRepository;

	public async Task<Device> ExecuteAsync(int deviceId)
	{
		return await _deviceRepository.GetDeviceByIdAsync(deviceId);
	}
}
