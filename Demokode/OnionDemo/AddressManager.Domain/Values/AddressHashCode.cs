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
        // https://www.compositional-it.com/news-blog/do-not-persist-gethashcode-in-net/
        var hashcode = 1430287;
        unchecked // Allow arithmetic overflow, numbers will just "wrap around"
        {
            hashcode = (hashcode * 7302013) ^ street.GetStableHashCode();
            hashcode = (hashcode * 7302013) ^ building.GetStableHashCode();
            hashcode = (hashcode * 7302013) ^ zipCode.GetStableHashCode();
            hashcode = (hashcode * 7302013) ^ city.GetStableHashCode();
            //return hashcode;
        }

        return new AddressHashCode(hashcode);
    }
}

/// <summary>
/// https://www.compositional-it.com/news-blog/do-not-persist-gethashcode-in-net/
/// https://stackoverflow.com/questions/36845430/persistent-hashcode-for-strings
/// </summary>
public static class StringExtensionMethods
{
    public static int GetStableHashCode(this string str)
    {
        unchecked
        {
            int hash1 = 5381;
            int hash2 = hash1;

            if (string.IsNullOrEmpty(str))
                return hash1;

            // Normalize the string
            str = str.ToUpperInvariant();
            str = str.Trim();
            str = str.RemoveWhitespace();

            // Compute hash
            for (int i = 0; i < str.Length && str[i] != '\0'; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1 || str[i + 1] == '\0')
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }

    public static string RemoveWhitespace(this string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !Char.IsWhiteSpace(c))
            .ToArray());
    }
}