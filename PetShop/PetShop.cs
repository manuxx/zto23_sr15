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
            return new ReadOnly<Pet>(_petsInTheStore);
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
                if (pet.species==Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> GenerateEnumerable(IList<Pet> items, Func<Pet, bool> cond)
        {
            foreach (Pet pet in items)
            {
                if (cond(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllMice()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.species == Species.Dog || p1.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.yearOfBirth > 2010 && p1.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.sex == Sex.Male && p1.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return GenerateEnumerable(_petsInTheStore, (p1) => p1.yearOfBirth > 2011 || p1.species == Species.Rabbit);
        }
    }

    public class ReadOnly<TItem> : IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _pets;

        public ReadOnly(IEnumerable<TItem> pets)
        {
            _pets = pets;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}