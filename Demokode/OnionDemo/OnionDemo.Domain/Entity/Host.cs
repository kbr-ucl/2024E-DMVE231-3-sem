namespace OnionDemo.Domain.Entity;

public class Host : DomainEntity
{
    protected List<Accommodation> Accommodations { get; set; }

    public IEnumerable<Accommodation> GetAccommodations()
    {
        return Accommodations.AsEnumerable();
    }

}