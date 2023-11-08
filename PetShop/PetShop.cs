using System;
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
            foreach (var pet in _petsInTheStore)
                yield return pet;
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
}