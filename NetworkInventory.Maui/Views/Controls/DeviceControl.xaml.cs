using System.Runtime.CompilerServices;

namespace NetworkInventory.Maui.Views.Controls;

public partial class DeviceControl : ContentView
{
	public bool IsForAdd { get; set; }
	public bool IsForEdit { get; set; }

	public DeviceControl()
	{
		InitializeComponent();
	}

	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		if (IsForAdd && IsForEdit is false)
		{
			SaveBtn.SetBinding(Button.CommandProperty, "AddDeviceCommand");
		}
		else if (IsForAdd is false && IsForEdit)
		{
			SaveBtn.SetBinding(Button.CommandProperty, "EditDeviceCommand");
		}
	}
}