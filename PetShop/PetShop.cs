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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        private IEnumerable<Pet> AllFromType( Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllCats()
        {
            return AllFromType( pet => pet.species == Species.Cat);
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllFromType( pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllFromType( pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllFromType( pet => pet.species == Species.Cat || pet.species == Species.Mouse);

        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllFromType(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllFromType(pet => pet.yearOfBirth >= 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllFromType(pet => pet.yearOfBirth >= 2010 && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllFromType(pet => pet.sex >= Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllFromType(pet => pet.yearOfBirth >= 2010 || pet.species == Species.Rabbit);
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