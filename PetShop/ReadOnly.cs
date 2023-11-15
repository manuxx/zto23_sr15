using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnly : IEnumerable<Pet>
{
    private IEnumerable<Pet> _accessPets;

    public ReadOnly(IEnumerable<Pet> accessPets)
    {
        _accessPets = accessPets;
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        return _accessPets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}