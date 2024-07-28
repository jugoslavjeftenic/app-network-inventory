using NetworkInventory.Maui.ViewModels;

namespace NetworkInventory.Maui.Views;

[QueryProperty(nameof(DeviceId), "Id")]
public partial class EditDevicePage : ContentPage
{
	private readonly DeviceViewModel _deviceViewModel;

	public EditDevicePage(DeviceViewModel deviceViewModel)
	{
		InitializeComponent();
		_deviceViewModel = deviceViewModel;

		BindingContext = _deviceViewModel;
	}

	public string DeviceId
	{
		set
		{
			if (string.IsNullOrWhiteSpace(value) is false &&
				int.TryParse(value, out int deviceId))
			{
				LoadDevice(deviceId);
			}
		}
	}

	private async void LoadDevice(int deviceId)
	{
		await _deviceViewModel.LoadDevice(deviceId);
	}
}