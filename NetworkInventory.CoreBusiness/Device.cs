using System.Numerics;

namespace NetworkInventory.CoreBusiness;

/// <summary>
/// Represents a network device with various network and hardware properties.
/// </summary>
public class Device
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string DeviceType { get; set; } = "";
	public string Manufacturer { get; set; } = "";
	public string Make { get; set; } = "";
	public string SerialNumber { get; set; } = "";
	public string MACAddress { get; set; } = "";
	public string IPv4 { get; set; } = "";
	public string SubnetMask { get; set; } = "";
	public string CIDR { get { return $"{IPv4}/{DecimalSubnetMaskToCIDR(SubnetMask)}"; } }
	public string Gateway { get; set; } = "";
	public string PreferredDNS { get; set; } = "";
	public string AlternateDNS { get; set; } = "";
	public string Vlan { get; set; } = "";
	public string UpstreamDevice { get; set; } = "";
	public string Location { get; set; } = "";
	public string User { get; set; } = "";

	private static int DecimalSubnetMaskToCIDR(string? SubnetMask)
	{
		if (string.IsNullOrWhiteSpace(SubnetMask))
		{
			return 0;
		}

		var octets = SubnetMask.Split('.');
		if (octets.Length.Equals(4) is false)
		{
			return 0;
		}

		int cidr = 0;
		foreach (string octet in octets)
		{
			if (int.TryParse(octet, out int value))
			{
				if (value < 0 || value > 255)
				{
					return 0;
				}
				//Counts the number of set bits (1s) in the binary representation of the value (ChatGPT).
				cidr += BitOperations.PopCount((uint)value);
			}
			else
			{
				return 0;
			}
		}

		return cidr;
	}
}
