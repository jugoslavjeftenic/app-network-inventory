using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Plugins.DataStore.InMemory;

public class DeviceInMemoryRepository : IDeviceRepository
{
	private readonly static List<Device> _devices = [
		new Device {
			Id = 1,
			Name = "Upstream Router",
			GetIPv4Address = "203.0.113.1",
			GetSubnetMask = "255.255.255.0",
			Location = "ISP",
			User = "ISP",
		},
		new Device {
			Id = 2,
			Name = "SUL1-RT-RV340",
			GetIPv4Address = "10.1.1.1",
			GetSubnetMask = "255.255.255.0",
			UpstreamDevice = "Upstream Router",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 3,
			Name = "SUL1-SW-SG350",
			GetIPv4Address = "10.1.2.1",
			GetSubnetMask = "255.255.255.0",
			GetGateway = "10.1.1.1",
			UpstreamDevice = "SUL1-RT-RV340",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 4,
			Name = "SUL1-AP-240AC",
			GetIPv4Address = "10.1.2.2",
			GetSubnetMask = "255.255.255.0",
			GetGateway = "10.1.1.1",
			UpstreamDevice = "SUL1-SW-SG350",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 5,
			Name = "SUL1-PR-MFP521",
			GetIPv4Address = "10.1.2.10",
			GetSubnetMask = "255.255.255.0",
			GetGateway = "10.1.1.1",
			UpstreamDevice = "SUL1-SW-SG350",
			Location = "Subotica - Lokacija 1",
		},
		new Device {
			Id = 6,
			Name = "SUL1-D19-100001",
			GetIPv4Address = "10.1.2.50",
			GetSubnetMask = "255.255.255.0",
			GetGateway = "10.1.1.1",
			UpstreamDevice = "SUL1-SW-SG350",
			Location = "Subotica - Lokacija 1",
			User = "info-pult",
		},
		new Device {
			Id = 7,
			Name = "SUL1-L365-200001",
			GetIPv4Address = "DHCP",
			GetSubnetMask = "DHCP",
			GetGateway = "DHCP",
			UpstreamDevice = "SUL1-AP-240AC",
			Location = "Subotica - Lokacija 1",
			User = "pera",
		},
		new Device {
			Id = 8,
			Name = "SUL1-L365-200002",
			GetIPv4Address = "DHCP",
			GetSubnetMask = "DHCP",
			GetGateway = "DHCP",
			UpstreamDevice = "SUL1-AP-240AC",
			Location = "Subotica - Lokacija 1",
			User = "zdera",
		},
		new Device {
			Id = 9,
			Name = "SUL1-LNO-200003",
			GetIPv4Address = "10.1.2.203",
			GetSubnetMask = "255.255.255.0",
		},
		new Device {
			Id = 10,
			Name = "SUL2-RT-RV340",
			GetIPv4Address = "10.1.3.1",
			GetSubnetMask = "255.255.255.0",
			Location = "Subotica - Lokacija 2",
		},
		new Device {
			Id = 11,
			Name = "SUL2-DNO-100002",
			GetIPv4Address = "10.1.3.50",
			GetSubnetMask = "255.255.255.0",
		},
		new Device {
			Id = 12,
			Name = "SUL2-L365-200004",
			GetIPv4Address = "10.1.3.204",
			GetSubnetMask = "255.255.255.0",
		},
		new Device {
			Id = 13,
			Name = "SUL2-LNO-200005",
			GetIPv4Address = "10.1.3.205",
			GetSubnetMask = "255.255.255.0",
			Location = "Subotica - Lokacija 2",
			User = "bomba",
		},
		new Device {
			Id = 14,
			Name = "SUL2-L365-200005",
			GetIPv4Address = "DHCP",
			GetSubnetMask = "DHCP",
			Location = "Subotica - Lokacija 2",
			User = "bomba",
		},
		new Device {
			Id = 15,
			Name = "SUL2-L19-200005",
			GetIPv4Address = "DHCP",
			GetSubnetMask = "DHCP",
			Location = "Subotica - Lokacija 2",
		},
		new Device {
			Id = 16,
			Name = "SUL2-LNO-200005",
			GetIPv4Address = "10.1.3.206",
			GetSubnetMask = "255.255.255.0",
			Location = "Subotica - Lokacija 2",
		},
	];

	public Task AddDeviceAsync(Device device)
	{
		var maxId = _devices.Select(x => x.Id).DefaultIfEmpty(0).Max();
		device.Id = maxId + 1;
		_devices.Add(device);

		return Task.CompletedTask;
	}

	public Task DeleteDeviceAsync(int deviceId)
	{
		var device = _devices.FirstOrDefault(x => x.Id.Equals(deviceId));
		if (device is not null)
		{
			_devices.Remove(device);
		}

		return Task.CompletedTask;
	}

	public Task<Device> GetDeviceByIdAsync(int deviceId)
	{
		var device = _devices.FirstOrDefault(x => x.Id.Equals(deviceId));
		if (device is not null)
		{
			return Task.FromResult(new Device()
			{
				Id = device.Id,
				Name = device.Name,
				SerialNumber = device.SerialNumber,
				GetIPv4Address = device.GetIPv4Address,
				GetSubnetMask = device.GetSubnetMask,
				GetGateway = device.GetGateway,
				GetPreferredDNS = device.GetPreferredDNS,
				GetAlternateDNS = device.GetAlternateDNS,
				Vlan = device.Vlan,
				UpstreamDevice = device.UpstreamDevice,
				Location = device.Location,
				User = device.User
			});
		}

		return Task.FromResult(new Device());
	}

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

	public Task UpdateDeviceAsync(int deviceId, Device device)
	{
		if (deviceId.Equals(device.Id) is false) return Task.CompletedTask;

		var deviceToUpdate = _devices.FirstOrDefault(x => x.Id.Equals(deviceId));
		if (deviceToUpdate is not null)
		{
			deviceToUpdate.Name = device.Name;
			deviceToUpdate.SerialNumber = device.SerialNumber;
			deviceToUpdate.GetIPv4Address = device.GetIPv4Address;
			deviceToUpdate.GetSubnetMask = device.GetSubnetMask;
			deviceToUpdate.GetGateway = device.GetGateway;
			deviceToUpdate.GetPreferredDNS = device.GetPreferredDNS;
			deviceToUpdate.GetAlternateDNS = device.GetAlternateDNS;
			deviceToUpdate.Vlan = device.Vlan;
			deviceToUpdate.UpstreamDevice = device.UpstreamDevice;
			deviceToUpdate.Location = device.Location;
			deviceToUpdate.User = device.User;
		}

		return Task.CompletedTask;
	}
}
