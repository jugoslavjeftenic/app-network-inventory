namespace NetworkInventory.Maui.Models;

public class DevicesRepository
{
	private readonly static List<Device> _devices = [
		new Device {
			Id = 1,
			Name = "Upstream Router",
			IPv4 = "203.0.113.1",
			SubnetMask = "255.255.255.0",
			UpstreamDeviceId = 0,
			Location = "ISP",
			User = "ISP",
		},
		new Device {
			Id = 2,
			Name = "SUL1-RT-RV340",
			IPv4 = "10.1.1.1",
			SubnetMask = "255.255.255.0",
			UpstreamDeviceId = 1,
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 3,
			Name = "SUL1-SW-SG350",
			IPv4 = "10.1.2.1",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = 2,
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 4,
			Name = "SUL1-AP-240AC",
			IPv4 = "10.1.2.2",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = 3,
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 5,
			Name = "SUL1-PR-MFP521",
			IPv4 = "10.1.2.10",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = 3,
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 6,
			Name = "SUL1-D19-100001",
			IPv4 = "10.1.2.50",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = 3,
			Location = "Subotica - Lokacija 1",
			User = "info-pult",
		},
		new Device {
			Id = 7,
			Name = "SUL1-L365-200001",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Gateway = "DHCP",
			UpstreamDeviceId = 4,
			Location = "Subotica - Lokacija 1",
			User = "pera",
		},
		new Device {
			Id = 8,
			Name = "SUL1-L365-200002",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Gateway = "DHCP",
			UpstreamDeviceId = 4,
			Location = "Subotica - Lokacija 1",
			User = "zdera",
		},
		new Device {
			Id = 9,
			Name = "SUL1-LNO-200003",
			IPv4 = "10.1.2.203",
			SubnetMask = "255.255.255.0",
		},
		new Device {
			Id = 10,
			Name = "SUL2-RT-RV340",
			IPv4 = "10.1.3.1",
			SubnetMask = "255.255.255.0",
			Location = "Subotica - Lokacija 2",
		},
		new Device {
			Id = 11,
			Name = "SUL2-DNO-100002",
			IPv4 = "10.1.3.50",
			SubnetMask = "255.255.255.0",
		},
		new Device {
			Id = 12,
			Name = "SUL2-L365-200004",
			IPv4 = "10.1.3.204",
			SubnetMask = "255.255.255.0",
		},
		new Device {
			Id = 13,
			Name = "SUL2-LNO-200005",
			IPv4 = "10.1.3.205",
			SubnetMask = "255.255.255.0",
			Location = "Subotica - Lokacija 2",
			User = "bomba",
		},
		new Device {
			Id = 14,
			Name = "SUL2-L365-200005",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Location = "Subotica - Lokacija 2",
			User = "bomba",
		},
		new Device {
			Id = 15,
			Name = "SUL2-L19-200005",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Location = "Subotica - Lokacija 2",
		},
		new Device {
			Id = 16,
			Name = "SUL2-LNO-200005",
			IPv4 = "10.1.3.206",
			SubnetMask = "255.255.255.0",
			Location = "Subotica - Lokacija 2",
		},
	];

	public static List<Device> GetDevices() => _devices;

	public static Device? GetDeviceById(int id)
	{
		var device = _devices.FirstOrDefault(x => x.Id.Equals(id));
		if (device is not null)
		{
			return new Device()
			{
				Id = device.Id,
				Name = device.Name,
				SerialNumber = device.SerialNumber,
				IPv4 = device.IPv4,
				SubnetMask = device.SubnetMask,
				Gateway = device.Gateway,
				PreferredDNS = device.PreferredDNS,
				AlternateDNS = device.AlternateDNS,
				Vlan = device.Vlan,
				UpstreamDeviceId = device.UpstreamDeviceId,
				Location = device.Location,
				User = device.User
			};
		}

		return null;
	}

	public static void UpdateDevice(int id, Device device)
	{
		if (id.Equals(device.Id) is false) return;

		var deviceToUpdate = _devices.FirstOrDefault(x => x.Id.Equals(id));
		if (deviceToUpdate is not null)
		{
			deviceToUpdate.Name = device.Name;
			deviceToUpdate.SerialNumber = device.SerialNumber;
			deviceToUpdate.IPv4 = device.IPv4;
			deviceToUpdate.SubnetMask = device.SubnetMask;
			deviceToUpdate.Gateway = device.Gateway;
			deviceToUpdate.PreferredDNS = device.PreferredDNS;
			deviceToUpdate.AlternateDNS = device.AlternateDNS;
			deviceToUpdate.Vlan = device.Vlan;
			deviceToUpdate.UpstreamDeviceId = device.UpstreamDeviceId;
			deviceToUpdate.Location = device.Location;
			deviceToUpdate.User = device.User;
		}
	}
}
