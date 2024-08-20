namespace DependencyInjectionInConsole;

public class BarService : IBar
{
    public BarService()
    {

    }
    public string GetData()
    {
        return "Data From Bar Service";

    }
}