using OnionDemo.Application;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class HostRepository : IHostRepository
{
    private readonly BookMyHomeContext _db;

    public HostRepository(BookMyHomeContext db)
    {
        _db = db;
    }

    Host IHostRepository.Get(int id)
    {
        return _db.Hosts.Single(a => a.Id == id);
    }
}