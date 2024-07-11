using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Plugins.DataStore.InMemory;

public class DeviceInMemoryRepository : IDeviceRepository
{
	private readonly static List<Device> _devices = [
		new Device {
			Id = 1,
			Name = "Upstream Router",
			IPv4 = "203.0.113.1",
			SubnetMask = "255.255.255.0",
			Location = "ISP",
			User = "ISP",
		},
		new Device {
			Id = 2,
			Name = "SUL1-RT-RV340",
			IPv4 = "10.1.1.1",
			SubnetMask = "255.255.255.0",
			UpstreamDeviceId = "Upstream Router",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 3,
			Name = "SUL1-SW-SG350",
			IPv4 = "10.1.2.1",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = "SUL1-RT-RV340",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 4,
			Name = "SUL1-AP-240AC",
			IPv4 = "10.1.2.2",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = "SUL1-SW-SG350",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 5,
			Name = "SUL1-PR-MFP521",
			IPv4 = "10.1.2.10",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = "SUL1-SW-SG350",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 6,
			Name = "SUL1-D19-100001",
			IPv4 = "10.1.2.50",
			SubnetMask = "255.255.255.0",
			Gateway = "10.1.1.1",
			UpstreamDeviceId = "SUL1-SW-SG350",
			Location = "Subotica - Lokacija 1",
			User = "info-pult",
		},
		new Device {
			Id = 7,
			Name = "SUL1-L365-200001",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Gateway = "DHCP",
			UpstreamDeviceId = "SUL1-AP-240AC",
			Location = "Subotica - Lokacija 1",
			User = "pera",
		},
		new Device {
			Id = 8,
			Name = "SUL1-L365-200002",
			IPv4 = "DHCP",
			SubnetMask = "DHCP",
			Gateway = "DHCP",
			UpstreamDeviceId = "SUL1-AP-240AC",
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

	public Task<List<Device>> GetDevicesAsync(string filterText)
	{
		if (string.IsNullOrWhiteSpace(filterText))
		{
			return Task.FromResult(_devices);
		}

		var devices = _devices
			.Where(x =>
				(x.Name?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false) ||
				(x.SerialNumber?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false) ||
				(x.Location?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false) ||
				(x.User?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false)
			)
			.ToList();

		return Task.FromResult(devices);
	}
}
