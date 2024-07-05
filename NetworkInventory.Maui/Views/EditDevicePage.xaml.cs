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
				EntrySerialNumber.Text = _device.SerialNumber;

				if (_device.IPv4.Equals("DHCP"))
				{
					EntryIPv4Octet0.Text = "0";
					EntryIPv4Octet1.Text = "0";
					EntryIPv4Octet2.Text = "0";
					EntryIPv4Octet3.Text = "0";
				}
				else
				{
					var Ipv4Octets = _device.IPv4.Split('.');
					EntryIPv4Octet0.Text = Ipv4Octets[0];
					EntryIPv4Octet1.Text = Ipv4Octets[1];
					EntryIPv4Octet2.Text = Ipv4Octets[2];
					EntryIPv4Octet3.Text = Ipv4Octets[3];
				}

				if (_device.SubnetMask.Equals("DHCP"))
				{
					EntrySubnetMaskOctet0.Text = "0";
					EntrySubnetMaskOctet1.Text = "0";
					EntrySubnetMaskOctet2.Text = "0";
					EntrySubnetMaskOctet3.Text = "0";
				}
				else
				{
					var subnetMaskOctets = _device.SubnetMask.Split('.');
					EntrySubnetMaskOctet0.Text = subnetMaskOctets[0];
					EntrySubnetMaskOctet1.Text = subnetMaskOctets[1];
					EntrySubnetMaskOctet2.Text = subnetMaskOctets[2];
					EntrySubnetMaskOctet3.Text = subnetMaskOctets[3];
				}

				if (_device.Gateway.Equals("DHCP"))
				{
					EntryGatewayOctet0.Text = "0";
					EntryGatewayOctet1.Text = "0";
					EntryGatewayOctet2.Text = "0";
					EntryGatewayOctet3.Text = "0";
				}
				else
				{
					var gatewayOctets = _device.Gateway.Split('.');
					EntryGatewayOctet0.Text = gatewayOctets[0];
					EntryGatewayOctet1.Text = gatewayOctets[1];
					EntryGatewayOctet2.Text = gatewayOctets[2];
					EntryGatewayOctet3.Text = gatewayOctets[3];
				}

				if (_device.PreferredDNS.Equals("DHCP"))
				{
					EntryPreferredDNSOctet0.Text = "0";
					EntryPreferredDNSOctet1.Text = "0";
					EntryPreferredDNSOctet2.Text = "0";
					EntryPreferredDNSOctet3.Text = "0";
				}
				else
				{
					var preferredDNSOctets = _device.PreferredDNS.Split('.');
					EntryPreferredDNSOctet0.Text = preferredDNSOctets[0];
					EntryPreferredDNSOctet1.Text = preferredDNSOctets[1];
					EntryPreferredDNSOctet2.Text = preferredDNSOctets[2];
					EntryPreferredDNSOctet3.Text = preferredDNSOctets[3];
				}

				if (_device.AlternateDNS.Equals("DHCP"))
				{
					EntryAlternateDNSOctet0.Text = "0";
					EntryAlternateDNSOctet1.Text = "0";
					EntryAlternateDNSOctet2.Text = "0";
					EntryAlternateDNSOctet3.Text = "0";
				}
				else
				{
					var alternateDNSOctets = _device.AlternateDNS.Split('.');
					EntryAlternateDNSOctet0.Text = alternateDNSOctets[0];
					EntryAlternateDNSOctet1.Text = alternateDNSOctets[1];
					EntryAlternateDNSOctet2.Text = alternateDNSOctets[2];
					EntryAlternateDNSOctet3.Text = alternateDNSOctets[3];
				}

				EntryVlan.Text = _device.Vlan;

				// TODO: Find Upstream Device by Name
				// EntryUpstreamDevice.Text = _device.UpstreamDeviceId;

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

		if (SerialNumberValidator.IsNotValid)
		{
			var toast = Toast
				.Make("Serial Number should be at least 3 characters long.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (IPv4Octet0Validator.IsNotValid ||
			IPv4Octet1Validator.IsNotValid ||
			IPv4Octet2Validator.IsNotValid ||
			IPv4Octet3Validator.IsNotValid)
		{
			var toast = Toast
				.Make("IPv4 octets must have a value between 0 and 255.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (SubnetMaskOctet0Validator.IsNotValid ||
			SubnetMaskOctet1Validator.IsNotValid ||
			SubnetMaskOctet2Validator.IsNotValid ||
			SubnetMaskOctet3Validator.IsNotValid)
		{
			var toast = Toast
				.Make("Subnet octets must have a value between 0 and 255.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (PreferredDNSOctet0Validator.IsNotValid ||
			PreferredDNSOctet1Validator.IsNotValid ||
			PreferredDNSOctet2Validator.IsNotValid ||
			PreferredDNSOctet3Validator.IsNotValid)
		{
			var toast = Toast
				.Make("Preferred DNS octets must have a value between 0 and 255.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (AlternateDNSOctet0Validator.IsNotValid ||
			AlternateDNSOctet1Validator.IsNotValid ||
			AlternateDNSOctet2Validator.IsNotValid ||
			AlternateDNSOctet3Validator.IsNotValid)
		{
			var toast = Toast
				.Make("Alternate DNS octets must have a value between 0 and 255.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (UpstreamDeviceValidator.IsNotValid)
		{
			var toast = Toast
				.Make("Upstream device should be at least 5 characters long.", ToastDuration.Short);
			await toast.Show();
			return;
		}

		if (LocationValidator.IsNotValid)
		{
			var toast = Toast
				.Make("Location should be at least 2 characters long.", ToastDuration.Short);
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
			_device.SerialNumber = EntrySerialNumber.Text;
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
			_device.Gateway =
				EntryGatewayOctet0.Text + "." +
				EntryGatewayOctet1.Text + "." +
				EntryGatewayOctet2.Text + "." +
				EntryGatewayOctet3.Text;
			_device.PreferredDNS =
				EntryPreferredDNSOctet0.Text + "." +
				EntryPreferredDNSOctet1.Text + "." +
				EntryPreferredDNSOctet2.Text + "." +
				EntryPreferredDNSOctet3.Text;
			_device.AlternateDNS =
				EntryAlternateDNSOctet0.Text + "." +
				EntryAlternateDNSOctet1.Text + "." +
				EntryAlternateDNSOctet2.Text + "." +
				EntryAlternateDNSOctet3.Text;
			_device.Vlan = EntryVlan.Text;
			_device.UpstreamDeviceId = 1; // TODO:
			_device.Location = EntryLocation.Text;
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