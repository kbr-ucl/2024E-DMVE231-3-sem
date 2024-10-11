using AddressManager.Application.Command;
using AddressManager.Domain.Entity;
using AddressManager.Domain.Values;
using System;

namespace AddressManager.Infrastructure;

public class AddressRepository : IAddressRepository
{
    private readonly AddressContext _db;

    public AddressRepository(AddressContext db)
    {
        _db = db;
    }
    void IAddressRepository.Add(Address? address)
    {
        _db.Addresses.Add(address);
        _db.SaveChanges();
    }

    Address? IAddressRepository.GetAddress(string street, string building, string zipCode, string city)
    {
        var hashCode = AddressHashCode.Create(street, building, zipCode, city).HashCode;
        return _db.Addresses.FirstOrDefault(a => a.AddressHashCode.HashCode == hashCode);
    }

    Address IAddressRepository.GetAddress(int id)
    {
        return _db.Addresses.First(a => a.Id == id);
    }

    void IAddressRepository.Update()
    {
        _db.SaveChanges();
    }
}