namespace AddressManager.Domain.Values;

public record AddressHashCode : ValueBase
{
    private AddressHashCode()
    {
    }

    protected AddressHashCode(int hashCode)
    {
        HashCode = hashCode;
    }

    public int HashCode { get; protected set; }

    public static AddressHashCode Create(string street, string building, string zipCode, string city)
    {
        var hashcode = 1430287;
        unchecked // Allow arithmetic overflow, numbers will just "wrap around"
        {
            hashcode = (hashcode * 7302013) ^ street.GetHashCode();
            hashcode = (hashcode * 7302013) ^ building.GetHashCode();
            hashcode = (hashcode * 7302013) ^ zipCode.GetHashCode();
            hashcode = (hashcode * 7302013) ^ city.GetHashCode();
            //return hashcode;
        }

        return new AddressHashCode(hashcode);
    }
}