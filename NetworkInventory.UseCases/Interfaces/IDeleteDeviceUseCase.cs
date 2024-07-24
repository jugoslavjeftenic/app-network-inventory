namespace NetworkInventory.UseCases.Interfaces;

public interface IDeleteDeviceUseCase
{
	Task ExecuteAsync(int deviceId);
}