namespace NetworkInventory.Maui.Models;

public class Device
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string SerialNumber { get; set; } = "";
	public string IPv4 { get; set; } = "0.0.0.0";
	public string SubnetMask { get; set; } = "255.255.255.0";
	public string CIDR { get { return $"{IPv4}/{DecimalSubnetMaskToCIDR(SubnetMask)}"; } }
	public string Gateway { get; set; } = "0.0.0.0";
	public string PreferredDNS { get; set; } = "0.0.0.0";
	public string AlternateDNS { get; set; } = "0.0.0.0";
	public string Vlan { get; set; } = "";
	public int UpstreamDeviceId { get; set; }
	public string Location { get; set; } = "";
	public string User { get; set; } = "";

	private static int DecimalSubnetMaskToCIDR(string decimalMask)
	{
		string[] octets = decimalMask.Split('.');

		if (octets.Length.Equals(4) is false)
		{
			throw new ArgumentException("Invalid subnet mask format.");
		}

		int cidr = 0;
		foreach (string octet in octets)
		{
			int value = int.Parse(octet);
			if (value < 0 || value > 255)
			{
				throw new ArgumentException("Each octet must be in the range 0-255.");
			}
			cidr += CountSetBits(value);
		}

		return cidr;
	}

	private static int CountSetBits(int value)
	{
		int count = 0;
		while (value > 0)
		{
			count += value & 1;
			value >>= 1;
		}
		return count;
	}
}
