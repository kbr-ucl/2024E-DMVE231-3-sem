// See https://aka.ms/new-console-template for more information
// See https://www.codeguru.co.in/2021/05/net-core-dependency-injection-in.html
using DependencyInjectionInConsole;
using Microsoft.Extensions.DependencyInjection;

var container = Startup.Configure();
var fooService = container.GetService<IFoo>();

if (fooService != null)
{
    fooService.GetData();
}
else
{
    Console.WriteLine("Failed to retrieve IFoo service.");
}
