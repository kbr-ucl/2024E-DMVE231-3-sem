namespace Demo.XunitOgMoq.BusinessLogic;

public interface IFoo
{
    string GetFoo();
}

public interface IBar
{
    string GetBar();
}

public class Foo : IFoo
{
    public string GetFoo()
    {
        return "Foo";
    }
}

public class Bar : IBar
{
    private readonly IFoo _foo;

    public Bar(IFoo foo)
    {
        _foo = foo;
    }

    public string GetBar()
    {
        return _foo.GetFoo() + "Bar";
    }
}