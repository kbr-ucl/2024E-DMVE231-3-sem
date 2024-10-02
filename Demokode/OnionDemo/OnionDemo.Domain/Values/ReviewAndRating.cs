using System.ComponentModel.DataAnnotations.Schema;

namespace OnionDemo.Domain.Values;

[ComplexType]
public record ReviewAndRating
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