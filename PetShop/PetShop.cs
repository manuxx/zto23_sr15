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
            //return _petsInTheStore.OneAtATime();
            return new ReadOnly(_petsInTheStore);
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

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)

                    yield return pet;

            }
            //return AllPets();
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var r = new List<Pet>(_petsInTheStore);
            r.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return r;
            
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
            //throw new NotImplementedException();
            //return (IEnumerator<Pet>)EnumUtilis.OneAtATime(_pets);
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}