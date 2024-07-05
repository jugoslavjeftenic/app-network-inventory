namespace NetworkInventory.Maui.Models;

public class DevicesRepository
{
	private readonly static List<Device> _devices = [
		new Device {
			Id = 1,
			Name = "Upstream Router",
			IPv4 = "203.0.113.1",
			SubnetMask = "255.255.255.0",
			ConnectedToDeviceId = 0,
			Location = "ISP",
			User = "ISP"
		},
		new Device {
			Id = 2,
			Name = "SU-L1-RT-RV340",
			IPv4 = "10.1.1.1",
			SubnetMask = "255.255.255.0",
			ConnectedToDeviceId = 1,
			Location = "Subotica - Lokacija 1"
		},
		new Device {
			Id = 3,
			Name = "SU-SZ-SW-SG350",
			IPv4 = "10.1.2.1",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			ConnectedToDeviceId = 2,
			Location = "Subotica - Lokacija 1"
		},
		new Device {
			Id = 4,
			Name = "SU-SZ-AP-240AC",
			IPv4 = "10.1.2.2",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			ConnectedToDeviceId = 3,
			Location = "Subotica - Lokacija 1"
		},
		new Device {
			Id = 5,
			Name = "SU-SZ-PR-MFP521",
			IPv4 = "10.1.2.10",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			ConnectedToDeviceId = 3,
			Location = "Subotica - Lokacija 1"
		},
		new Device {
			Id = 6,
			Name = "SU-D19-100001",
			IPv4 = "10.1.2.50",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			ConnectedToDeviceId = 3,
			Location = "Subotica - Lokacija 1",
			User = "Info Pult"
		},
		new Device {
			Id = 7,
			Name = "SU-L365-200001",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Gateway = "DHCP",
			ConnectedToDeviceId = 4,
			Location = "Subotica - Lokacija 1",
			User = "pera"
		},
		new Device {
			Id = 8,
			Name = "SU-L365-200002",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Gateway = "DHCP",
			ConnectedToDeviceId = 4,
			Location = "Subotica - Lokacija 1",
			User = "zdera"
		},
		new Device {
			Id = 9,
			Name = "SU-LNO-200003",
			IPv4 = "10.1.2.203",
			SubnetMask = "255.255.255.0"
		},
		new Device {
			Id = 10,
			Name = "SU-NZ-RV340",
			IPv4 = "10.1.3.1",
			SubnetMask = "255.255.255.0",
			Location = "Subotica Nova zgrada"
		},
		new Device {
			Id = 11,
			Name = "SU-DNO-100002",
			IPv4 = "10.1.3.50",
			SubnetMask = "255.255.255.0"
		},
		new Device {
			Id = 12,
			Name = "SU-L365-200004",
			IPv4 = "10.1.3.204",
			SubnetMask = "255.255.255.0"
		},
		new Device {
			Id = 13,
			Name = "SU-LNO-200005"
			, IPv4 = "10.1.3.205",
			SubnetMask = "255.255.255.0",
			Location = "Subotica Nova zgrada",
			User = "bomba"
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
				IPv4 = device.IPv4,
				SubnetMask = device.SubnetMask,
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
			deviceToUpdate.IPv4 = device.IPv4;
			deviceToUpdate.SubnetMask = device.SubnetMask;
			deviceToUpdate.Gateway = device.Gateway;
			deviceToUpdate.PreferredDNS = device.PreferredDNS;
			deviceToUpdate.AlternateDNS = device.AlternateDNS;
			deviceToUpdate.ConnectedToDeviceId = device.ConnectedToDeviceId;
			deviceToUpdate.Location = device.Location;
			deviceToUpdate.User = device.User;
		}
	}
}
