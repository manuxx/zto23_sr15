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
            return Filter(IsASpecies(Species.Cat));
        }

        private static Func<Pet, bool> IsASpecies(Species species)
        {
            return pet => pet.species == species;
        }


        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return Filter(IsASpecies(Species.Mouse));
        }

        private IEnumerable<Pet> Filter(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return Filter(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return Filter(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return Filter(NotASpecies(Species.Mouse));
        }

        private static Func<Pet, bool> NotASpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return Filter(IsBornAfter(2010));
        }

        private static Func<Pet, bool> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            var isASpecies = IsASpecies(Species.Dog);
            var isBornAfter = IsBornAfter(2010);
            return Filter(pet => isASpecies(pet) && isBornAfter(pet));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            var isASpecies = IsASpecies(Species.Dog);
            return Filter(pet => isASpecies(pet) && pet.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            var isASpecies = IsASpecies(Species.Rabbit);
            var isBornAfter = IsBornAfter(2011);
            return Filter(pet => isASpecies(pet)|| isBornAfter(pet));
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