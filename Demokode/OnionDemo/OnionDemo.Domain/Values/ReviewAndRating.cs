namespace OnionDemo.Domain.Values;

public record ReviewAndRating : ValueBase
{
    protected ReviewAndRating()
    {
    }

    public ReviewAndRating(string review, int rating)
    {
        Review = review;
        Rating = rating;
    }

    public string Review { get; private set; }
    public int Rating { get; private set; }
}