using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnly(EnumeratorUtils.AccessPets(_petsInTheStore));
        }

        public void Add(Pet newPet)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (newPet.name==pet.name)
      
                    return;
   
            }
            _petsInTheStore.Add(newPet);
        }
    }

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
}