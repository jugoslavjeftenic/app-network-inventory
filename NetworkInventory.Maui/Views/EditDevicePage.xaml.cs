using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NetworkInventory.Maui.Models;
using Device = NetworkInventory.Maui.Models.Device;

namespace NetworkInventory.Maui.Views;

[QueryProperty(nameof(DeviceId), "Id")]
public partial class EditDevicePage : ContentPage
{
	private Device? _device;

	public EditDevicePage()
	{
		InitializeComponent();
	}

	public string DeviceId
	{
		set
		{
			_device = DevicesRepository.GetDeviceById(int.Parse(value));
			if (_device is not null)
			{
				EntryName.Text = _device.Name;

				var Ipv4Octets = _device.IPv4.Split('.');
				EntryIPv4Octet0.Text = Ipv4Octets[0];
				EntryIPv4Octet1.Text = Ipv4Octets[1];
				EntryIPv4Octet2.Text = Ipv4Octets[2];
				EntryIPv4Octet3.Text = Ipv4Octets[3];

				var subnetMaskOctets = _device.SubnetMask.Split('.');
				EntrySubnetMaskOctet0.Text = subnetMaskOctets[0];
				EntrySubnetMaskOctet1.Text = subnetMaskOctets[1];
				EntrySubnetMaskOctet2.Text = subnetMaskOctets[2];
				EntrySubnetMaskOctet3.Text = subnetMaskOctets[3];

				EntryLocation.Text = _device.Location;
				EntryUser.Text = _device.User;
			}
		}
	}

	private async void UpdateBtn_Clicked(object sender, EventArgs e)
	{
		if (NameValidator.IsNotValid)
		{
			var toast = Toast
				.Make("Device Name should be at least 5 characters long.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (IPv4Octet0Validator.IsNotValid ||
			IPv4Octet1Validator.IsNotValid ||
			IPv4Octet2Validator.IsNotValid ||
			IPv4Octet3Validator.IsNotValid ||
			SubnetMaskOctet0Validator.IsNotValid ||
			SubnetMaskOctet1Validator.IsNotValid ||
			SubnetMaskOctet2Validator.IsNotValid ||
			SubnetMaskOctet3Validator.IsNotValid)
		{
			var toast = Toast
				.Make("IPv4 and Subnet octets must have a value between 0 and 255.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (LocationValidator.IsNotValid)
		{
			var toast = Toast
				.Make("Location should be at least 3 characters long.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (UserValidator.IsNotValid)
		{
			var toast = Toast
				.Make("User name should be at least 3 characters long.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (_device is not null)
		{
			_device.Name = EntryName.Text;
			_device.IPv4 =
				EntryIPv4Octet0.Text + "." +
				EntryIPv4Octet1.Text + "." +
				EntryIPv4Octet2.Text + "." +
				EntryIPv4Octet3.Text;
			_device.SubnetMask =
				EntrySubnetMaskOctet0.Text + "." +
				EntrySubnetMaskOctet1.Text + "." +
				EntrySubnetMaskOctet2.Text + "." +
				EntrySubnetMaskOctet3.Text;
			_device.User = EntryUser.Text;

			DevicesRepository.UpdateDevice(_device.Id, _device);
			await Shell.Current.GoToAsync("..");
		}
	}

	private void CancelBtn_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}
}