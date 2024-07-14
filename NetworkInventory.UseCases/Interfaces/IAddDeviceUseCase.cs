namespace NetworkInventory.UseCases.Interfaces
{
    public interface IAddDeviceUseCase
    {
        Task ExecuteAsync(CoreBusiness.Device device);
    }
}