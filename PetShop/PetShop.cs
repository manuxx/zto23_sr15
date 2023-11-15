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
            foreach (var pet1 in _petsInTheStore.GetOneAtATime()) yield return pet1;
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
}