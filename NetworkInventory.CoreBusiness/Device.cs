using SQLite;
using System.ComponentModel.DataAnnotations;

namespace NetworkInventory.CoreBusiness;

/// <summary>
/// Represents a network device with various network and hardware properties.
/// </summary>
public class Device
{
	[Required]
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = "";
	public string SerialNumber { get; set; } = "";
	public string IPv4Address { get; set; } = "";
	public string SubnetMask { get; set; } = "";
	public string Location { get; set; } = "";
	public string User { get; set; } = "";

	// TODO
	// public string DeviceType { get; set; } = "";
	// public string Manufacturer { get; set; } = "";
	// public string Make { get; set; } = "";
	// public string MACAddress { get; set; } = "";
	// public string GatewayOctets { get; set; } = "";
	// public string PreferredDNSOctets { get; set; } = "";
	// public string AlternateDNSOctets { get; set; } = "";
	// public string Vlan { get; set; } = "";
	// public string UpstreamDevice { get; set; } = "";
}
