namespace NetworkInventory.UseCases.Interfaces
{
    public interface IEditDeviceUseCase
    {
        Task ExecuteAsync(int deviceId, CoreBusiness.Device device);
    }
}