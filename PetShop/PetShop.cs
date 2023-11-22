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

        public void Add(Pet newItem)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (newItem.name==pet.name)
                    return;
            }
            _petsInTheStore.Add(newItem);
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.Filter((IsACat));
        }

        private bool IsACat(Pet item)
        {
	        return item.species == Species.Cat;
        }


        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.Filter(IsMice());
        }

        private static Predicate<Pet> IsMice()
        {
	        return (pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.Filter(IsFemale());
        }

        private static Predicate<Pet> IsFemale()
        {
	        return pet => pet.sex == Sex.Female;
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.Filter((pet => pet.species != Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
	        return _petsInTheStore.Filter(IsBornAfter(2010));
        }

        private static Predicate<Pet> IsBornAfter(int year)
        {
	        return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Dog && pet.yearOfBirth > 2010));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011));
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