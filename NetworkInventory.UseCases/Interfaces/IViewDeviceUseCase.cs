namespace NetworkInventory.UseCases.Interfaces
{
	public interface IViewDeviceUseCase
	{
		Task<CoreBusiness.Device> ExecuteAsync(int deviceId);
	}
}