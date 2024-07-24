using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Plugins.DataStore.InMemory;

public class DeviceInMemoryRepository : IDeviceRepository
{
	private readonly static List<Device> _devices = [
		new Device {
			Id = 1,
			Name = "Edge router",
			SerialNumber = "12345ABC",
			IPv4Address = "192.168.0.1",
			SubnetMask = "255.255.255.0]",
			Location = "Server Room",
			User = "admin"
		},
		new Device {
			Id = 2,
			Name = "Location 1 Switch",
			SerialNumber = "234567890",
			IPv4Address = "192.168.1.1",
			SubnetMask = "255.255.255.0]",
			Location = "Location 1",
			User = "admin"
		},
		new Device {
			Id = 3,
			Name = "Location 2 Switch",
			SerialNumber = "23ABC7890",
			IPv4Address = "192.168.2.1",
			SubnetMask = "255.255.255.0]",
			Location = "Location 2",
			User = "admin"
		},
		new Device {
			Id = 4,
			Name = "Location 1 AP",
			SerialNumber = "23ABC0",
			IPv4Address = "192.168.1.2",
			SubnetMask = "255.255.255.0]",
			Location = "Location 1",
			User = "admin"
		},
		new Device {
			Id = 5,
			Name = "Location 2 AP",
			SerialNumber = "23ABC0FA4",
			IPv4Address = "192.168.2.2",
			SubnetMask = "255.255.255.0]",
			Location = "Location 2",
			User = "admin"
		},
		new Device {
			Id = 6,
			Name = "Location 1 Printer",
			SerialNumber = "2CDBC0FA4",
			IPv4Address = "192.168.1.10",
			SubnetMask = "255.255.255.0]",
			Location = "Location 1",
			User = "admin"
		},
		new Device {
			Id = 7,
			Name = "Location 2 Printer",
			SerialNumber = "2CDBC04",
			IPv4Address = "192.168.2.10",
			SubnetMask = "255.255.255.0]",
			Location = "Location 2",
			User = "admin"
		},
		new Device {
			Id = 8,
			Name = "Location 1 Desktop",
			SerialNumber = "2CDBC04",
			IPv4Address = "192.168.1.50",
			SubnetMask = "255.255.255.0]",
			Location = "Location 1",
			User = "info-pult"
		},
		new Device {
			Id = 9,
			Name = "Location 2 Desktop",
			SerialNumber = "2C234DBC04",
			IPv4Address = "192.168.2.50",
			SubnetMask = "255.255.255.0]",
			Location = "Location 2",
			User = "info-pult"
		},
		new Device {
			Id = 10,
			Name = "Location 1 Laptop1",
			SerialNumber = "12345",
			IPv4Address = "192.168.1.100",
			SubnetMask = "255.255.255.0]",
			Location = "Location 1",
			User = "user1"
		},
		new Device {
			Id = 11,
			Name = "Location 1 Laptop2",
			SerialNumber = "12345",
			IPv4Address = "192.168.1.101",
			SubnetMask = "255.255.255.0]",
			Location = "Location 1",
			User = "user2"
		},
		new Device {
			Id = 12,
			Name = "Location 2 Laptop1",
			SerialNumber = "12345",
			IPv4Address = "192.168.2.100",
			SubnetMask = "255.255.255.0]",
			Location = "Location 2",
			User = "user3"
		},
		new Device {
			Id = 13,
			Name = "Location 2 Laptop2",
			SerialNumber = "12345",
			IPv4Address = "192.168.2.101",
			SubnetMask = "255.255.255.0]",
			Location = "Location 2",
			User = "user4"
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
				IPv4Address = device.IPv4Address,
				SubnetMask = device.SubnetMask,
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
			deviceToUpdate.IPv4Address = device.IPv4Address;
			deviceToUpdate.SubnetMask = device.SubnetMask;
			deviceToUpdate.Location = device.Location;
			deviceToUpdate.User = device.User;
		}

		return Task.CompletedTask;
	}
}
