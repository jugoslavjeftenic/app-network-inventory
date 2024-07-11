namespace NetworkInventory.UseCases.Interfaces;

public interface IViewDevicesUseCase
{
	Task<List<CoreBusiness.Device>> ExecuteAsync(string filterText);
}