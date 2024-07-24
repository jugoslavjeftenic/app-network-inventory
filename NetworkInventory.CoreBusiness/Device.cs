using System.Numerics;

namespace NetworkInventory.CoreBusiness;

/// <summary>
/// Represents a network device with various network and hardware properties.
/// </summary>
public class Device
{
	private const int _octetCount = 4;
	private const int _octetMinValue = 0;
	private const int _octetMaxValue = 255;

	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string DeviceType { get; set; } = "";
	public string Manufacturer { get; set; } = "";
	public string Make { get; set; } = "";
	public string SerialNumber { get; set; } = "";
	public string MACAddress { get; set; } = "";
	public int[] IPv4Octets { get; set; } = new int[_octetCount];
	public int[] SubnetMaskOctets { get; set; } = new int[_octetCount];
	public int[] GatewayOctets { get; set; } = new int[_octetCount];
	public int[] PreferredDNSOctets { get; set; } = new int[4];
	public int[] AlternateDNSOctets { get; set; } = new int[_octetCount];
	public string Vlan { get; set; } = "";
	public string UpstreamDevice { get; set; } = "";
	public string Location { get; set; } = "";
	public string User { get; set; } = "";

	public string GetIPv4Address() => GetAddressStringFromOctets(IPv4Octets);
	public string GetSubnetMask() => GetAddressStringFromOctets(SubnetMaskOctets);
	public string GetGateway() => GetAddressStringFromOctets(GatewayOctets);
	public string GetPreferredDNS() => GetAddressStringFromOctets(PreferredDNSOctets);
	public string GetAlternateDNS() => GetAddressStringFromOctets(AlternateDNSOctets);

	public string GetCIDR() => $"{GetIPv4Address}/{SubnetMaskToCIDR(SubnetMaskOctets)}";

	private static string GetAddressStringFromOctets(int[] octets)
	{
		ValidateOctets(octets);
		return string.Join(".", octets);
	}

	private static int SubnetMaskToCIDR(int[] subnetMaskOctets)
	{
		ValidateOctets(subnetMaskOctets);

		int cidr = 0;
		foreach (int octet in subnetMaskOctets)
		{
			//Counts the number of set bits (1s) in the binary representation of the value (ChatGPT).
			cidr += BitOperations.PopCount((uint)octet);
		}

		return cidr;
	}

	private static void ValidateOctets(int[] octets)
	{
		if (octets.Length.Equals(_octetCount) is false)
		{
			throw new InvalidOperationException
				($"The octet array must contain exactly {_octetCount} elements.");
		}

		foreach (int octet in octets)
		{
			if (octet < _octetMinValue || octet > _octetMaxValue)
			{
				throw new ArgumentOutOfRangeException
					($"Each octet must be in the range {_octetMinValue} to {_octetMaxValue}.");
			}
		}
	}
}
