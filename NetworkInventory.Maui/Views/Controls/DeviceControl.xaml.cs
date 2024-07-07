namespace NetworkInventory.Maui.Views.Controls;

public partial class DeviceControl : ContentView
{
	public event EventHandler<string>? OnError;
	public event EventHandler<EventArgs>? OnSave;
	public event EventHandler<EventArgs>? OnCancel;

	public DeviceControl()
	{
		InitializeComponent();
	}

	public string? Name
	{
		get
		{
			return EntryName.Text;
		}
		set
		{
			EntryName.Text = value;
		}
	}

	public string? SerialNumber
	{
		get
		{
			return EntrySerialNumber.Text;
		}
		set
		{
			EntrySerialNumber.Text = value;
		}
	}

	public string? IPv4
	{
		get
		{
			return
				EntryIPv4Octet0.Text + "." +
				EntryIPv4Octet1.Text + "." +
				EntryIPv4Octet2.Text + "." +
				EntryIPv4Octet3.Text;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				EntryIPv4Octet0.Text = string.Empty;
				EntryIPv4Octet1.Text = string.Empty;
				EntryIPv4Octet2.Text = string.Empty;
				EntryIPv4Octet3.Text = string.Empty;
			}
			else if (value.Equals("DHCP"))
			{
				EntryIPv4Octet0.Text = "0";
				EntryIPv4Octet1.Text = "0";
				EntryIPv4Octet2.Text = "0";
				EntryIPv4Octet3.Text = "0";
			}
			else
			{
				var Ipv4Octets = value.Split('.');
				EntryIPv4Octet0.Text = Ipv4Octets[0];
				EntryIPv4Octet1.Text = Ipv4Octets[1];
				EntryIPv4Octet2.Text = Ipv4Octets[2];
				EntryIPv4Octet3.Text = Ipv4Octets[3];
			}
		}
	}

	public string? SubnetMask
	{
		get
		{
			return
				EntrySubnetMaskOctet0.Text + "." +
				EntrySubnetMaskOctet1.Text + "." +
				EntrySubnetMaskOctet2.Text + "." +
				EntrySubnetMaskOctet3.Text;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				EntrySubnetMaskOctet0.Text = string.Empty;
				EntrySubnetMaskOctet1.Text = string.Empty;
				EntrySubnetMaskOctet2.Text = string.Empty;
				EntrySubnetMaskOctet3.Text = string.Empty;
			}
			else if (value.Equals("DHCP"))
			{
				EntrySubnetMaskOctet0.Text = "0";
				EntrySubnetMaskOctet1.Text = "0";
				EntrySubnetMaskOctet2.Text = "0";
				EntrySubnetMaskOctet3.Text = "0";
			}
			else
			{
				var SubnetMaskOctets = value.Split('.');
				EntrySubnetMaskOctet0.Text = SubnetMaskOctets[0];
				EntrySubnetMaskOctet1.Text = SubnetMaskOctets[1];
				EntrySubnetMaskOctet2.Text = SubnetMaskOctets[2];
				EntrySubnetMaskOctet3.Text = SubnetMaskOctets[3];
			}
		}
	}

	public string? Gateway
	{
		get
		{
			return
				EntryGatewayOctet0.Text + "." +
				EntryGatewayOctet1.Text + "." +
				EntryGatewayOctet2.Text + "." +
				EntryGatewayOctet3.Text;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				EntryGatewayOctet0.Text = string.Empty;
				EntryGatewayOctet1.Text = string.Empty;
				EntryGatewayOctet2.Text = string.Empty;
				EntryGatewayOctet3.Text = string.Empty;
			}
			else if (value.Equals("DHCP"))
			{
				EntryGatewayOctet0.Text = "0";
				EntryGatewayOctet1.Text = "0";
				EntryGatewayOctet2.Text = "0";
				EntryGatewayOctet3.Text = "0";
			}
			else
			{
				var GatewayMaskOctets = value.Split('.');
				EntryGatewayOctet0.Text = GatewayMaskOctets[0];
				EntryGatewayOctet1.Text = GatewayMaskOctets[1];
				EntryGatewayOctet2.Text = GatewayMaskOctets[2];
				EntryGatewayOctet3.Text = GatewayMaskOctets[3];
			}
		}
	}

	public string? PreferredDNS
	{
		get
		{
			return
				EntryPreferredDNSOctet0.Text + "." +
				EntryPreferredDNSOctet1.Text + "." +
				EntryPreferredDNSOctet2.Text + "." +
				EntryPreferredDNSOctet3.Text;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				EntryPreferredDNSOctet0.Text = string.Empty;
				EntryPreferredDNSOctet1.Text = string.Empty;
				EntryPreferredDNSOctet2.Text = string.Empty;
				EntryPreferredDNSOctet3.Text = string.Empty;
			}
			else if (value.Equals("DHCP"))
			{
				EntryPreferredDNSOctet0.Text = "0";
				EntryPreferredDNSOctet1.Text = "0";
				EntryPreferredDNSOctet2.Text = "0";
				EntryPreferredDNSOctet3.Text = "0";
			}
			else
			{
				var PreferredDNSMaskOctets = value.Split('.');
				EntryPreferredDNSOctet0.Text = PreferredDNSMaskOctets[0];
				EntryPreferredDNSOctet1.Text = PreferredDNSMaskOctets[1];
				EntryPreferredDNSOctet2.Text = PreferredDNSMaskOctets[2];
				EntryPreferredDNSOctet3.Text = PreferredDNSMaskOctets[3];
			}
		}
	}

	public string? AlternateDNS
	{
		get
		{
			return
				EntryAlternateDNSOctet0.Text + "." +
				EntryAlternateDNSOctet1.Text + "." +
				EntryAlternateDNSOctet2.Text + "." +
				EntryAlternateDNSOctet3.Text;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				EntryAlternateDNSOctet0.Text = string.Empty;
				EntryAlternateDNSOctet1.Text = string.Empty;
				EntryAlternateDNSOctet2.Text = string.Empty;
				EntryAlternateDNSOctet3.Text = string.Empty;
			}
			else if (value.Equals("DHCP"))
			{
				EntryAlternateDNSOctet0.Text = "0";
				EntryAlternateDNSOctet1.Text = "0";
				EntryAlternateDNSOctet2.Text = "0";
				EntryAlternateDNSOctet3.Text = "0";
			}
			else
			{
				var AlternateDNSMaskOctets = value.Split('.');
				EntryAlternateDNSOctet0.Text = AlternateDNSMaskOctets[0];
				EntryAlternateDNSOctet1.Text = AlternateDNSMaskOctets[1];
				EntryAlternateDNSOctet2.Text = AlternateDNSMaskOctets[2];
				EntryAlternateDNSOctet3.Text = AlternateDNSMaskOctets[3];
			}
		}
	}

	public string? Vlan
	{
		get
		{
			return EntryVlan.Text;
		}
		set
		{
			EntryVlan.Text = value;
		}
	}

	public int UpstreamDeviceId
	{
		get
		{
			if (int.TryParse(EntryUpstreamDevice.Text, out int entryUpstreamDeviceId))
			{
				return entryUpstreamDeviceId;
			}
			return 0;
		}
		set
		{
			EntryUpstreamDevice.Text = value.ToString();
		}
	}

	public string? Location
	{
		get
		{
			return EntryLocation.Text;
		}
		set
		{
			EntryLocation.Text = value;
		}
	}

	public string? User
	{
		get
		{
			return EntryUser.Text;
		}
		set
		{
			EntryUser.Text = value;
		}
	}

	private void SaveBtn_Clicked(object sender, EventArgs e)
	{
		if (NameValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "Device Name should be at least 5 characters long.");
			return;
		}

		if (SerialNumberValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "Serial Number should be at least 3 characters long.");
			return;
		}

		if (IPv4Octet0Validator.IsNotValid ||
			IPv4Octet1Validator.IsNotValid ||
			IPv4Octet2Validator.IsNotValid ||
			IPv4Octet3Validator.IsNotValid)
		{
			OnError?.Invoke(sender, "IPv4 octets must have a value between 0 and 255.");
			return;
		}

		if (SubnetMaskOctet0Validator.IsNotValid ||
			SubnetMaskOctet1Validator.IsNotValid ||
			SubnetMaskOctet2Validator.IsNotValid ||
			SubnetMaskOctet3Validator.IsNotValid)
		{
			OnError?.Invoke(sender, "Subnet octets must have a value between 0 and 255.");
			return;
		}

		if (GatewayOctet0Validator.IsNotValid ||
			GatewayOctet1Validator.IsNotValid ||
			GatewayOctet2Validator.IsNotValid ||
			GatewayOctet3Validator.IsNotValid)
		{
			OnError?.Invoke(sender, "Gateway octets must have a value between 0 and 255.");
			return;
		}

		if (PreferredDNSOctet0Validator.IsNotValid ||
			PreferredDNSOctet1Validator.IsNotValid ||
			PreferredDNSOctet2Validator.IsNotValid ||
			PreferredDNSOctet3Validator.IsNotValid)
		{
			OnError?.Invoke(sender, "Preferred DNS octets must have a value between 0 and 255.");
			return;
		}

		if (AlternateDNSOctet0Validator.IsNotValid ||
			AlternateDNSOctet1Validator.IsNotValid ||
			AlternateDNSOctet2Validator.IsNotValid ||
			AlternateDNSOctet3Validator.IsNotValid)
		{
			OnError?.Invoke(sender, "Alternate DNS octets must have a value between 0 and 255.");
			return;
		}

		if (UpstreamDeviceValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "Upstream device should be at least 5 characters long.");
			return;
		}

		if (LocationValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "Location should be at least 2 characters long.");
			return;
		}

		if (UserValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "User name should be at least 2 characters long.");
			return;
		}

		OnSave?.Invoke(sender, e);
	}

	private void CancelBtn_Clicked(object sender, EventArgs e)
	{
		OnCancel?.Invoke(sender, e);
	}
}