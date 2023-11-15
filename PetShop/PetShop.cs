using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            return new ReadOnly(_petsInTheStore);
        }

        private Boolean IsAlredyAdded(string petName)
        {
            foreach (var item in _petsInTheStore)
            {
                if (item.name.Equals(petName))
                {
                    return true;
                }  
            }
            return false;
        }


        public void Add(Pet newPet)
        {
            if (!_petsInTheStore.Contains(newPet) && !IsAlredyAdded(newPet.name))
            {
                _petsInTheStore.Add(newPet);
            }
        }
    }

    public class ReadOnly : IEnumerable<Pet>
    {
        private readonly IEnumerable<Pet> _pets;

        public ReadOnly(IEnumerable<Pet> pets)
        {
            _pets = pets;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}