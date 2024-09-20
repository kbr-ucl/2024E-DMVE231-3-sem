using OnionDemo.Domain.Entity;

namespace OnionDemo.Application;

public interface IHostRepository
{
    Host Get(int id);
}