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
	public int[] IPv4Octets { get; set; } = new int[4];
	public int[] SubnetMaskOctets { get; set; } = new int[4];
	public int[] GatewayOctets { get; set; } = new int[4];
	public int[] PreferredDNSOctets { get; set; } = new int[4];
	public int[] AlternateDNSOctets { get; set; } = new int[4];
	public string Vlan { get; set; } = "";
	public string UpstreamDevice { get; set; } = "";
	public string Location { get; set; } = "";
	public string User { get; set; } = "";

	public string GetIPv4Address() => GetAddressStringFromOctets(IPv4Octets);
	public string GetSubnetMask() => GetAddressStringFromOctets(SubnetMaskOctets);
	public string GetGateway() => GetAddressStringFromOctets(GatewayOctets);
	public string GetPreferredDNS() => GetAddressStringFromOctets(PreferredDNSOctets);
	public string GetAlternateDNS() => GetAddressStringFromOctets(AlternateDNSOctets);

	public string GetCIDR() => $"{GetIPv4Address}/{SubnetMaskToCIDR(GetSubnetMask())}";

	private static string GetAddressStringFromOctets(int[] octets)
	{
		if (octets.Length != 4)
		{
			throw new InvalidOperationException("The address array must contain exactly 4 elements.");
		}

		foreach (int octet in octets)
		{
			if (octet < 0 || octet > 255)
			{
				throw new ArgumentOutOfRangeException("Each octet must be in the range 0 to 255.");
			}
		}

		return string.Join(".", octets);
	}

	private static int SubnetMaskToCIDR(string? SubnetMask)
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
