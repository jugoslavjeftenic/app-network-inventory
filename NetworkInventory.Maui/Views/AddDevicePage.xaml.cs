namespace NetworkInventory.Maui.Views;

public partial class AddDevicePage : ContentPage
{
	public AddDevicePage()
	{
		InitializeComponent();
	}

	private void CancelBtn_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}
}