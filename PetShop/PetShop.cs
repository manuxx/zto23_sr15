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
            foreach (var pet in _petsInTheStore) //ten kod to œciema, tak naprawde nie iterujemy po 
            {
                yield return pet; //zrob nowy iterator, to jest na niego przepis, i zwróæ
            }
        }

        public void Add(Pet newPet)
        {
            bool containsClone = _petsInTheStore.Contains(newPet);
            bool containsName = false;
            foreach (Pet pet in _petsInTheStore)
            {
                if (pet.name == newPet.name)
                {
                    containsName = true;
                }
            }
            if (!containsClone && !containsName)
            {
                _petsInTheStore.Add(newPet);
            }
        }
    }
}