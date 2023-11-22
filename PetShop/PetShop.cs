using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<TItem> _petsInTheStore;

        public PetShop(IList<TItem> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<TItem> AllPets()
        {
            return new ReadOnly<TItem>(_petsInTheStore);
        }

        public void Add(TItem newItem)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (newItem.name==pet.name)
                    return;
            }
            _petsInTheStore.Add(newItem);
        }

        public IEnumerable<TItem> AllCats()
        {
            return _petsInTheStore.Filter((IsACat));
        }

        private bool IsACat(TItem pet)
        {
	        return pet.species == Species.Cat;
        }


        public IEnumerable<TItem> AllPetsSortedByName()
        {
            var ret = new List<TItem>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<TItem> AllMice()
        {
            return _petsInTheStore.Filter(IsMice());
        }

        private static Predicate<TItem> IsMice()
        {
	        return (pet => pet.species == Species.Mouse);
        }

        public IEnumerable<TItem> AllFemalePets()
        {
            return _petsInTheStore.Filter(IsFemale());
        }

        private static Predicate<TItem> IsFemale()
        {
	        return pet => pet.sex == Sex.Female;
        }

        public IEnumerable<TItem> AllCatsOrDogs()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<TItem> AllPetsButNotMice()
        {
            return _petsInTheStore.Filter((pet => pet.species != Species.Mouse));
        }

        public IEnumerable<TItem> AllPetsBornAfter2010()
        {
	        return _petsInTheStore.Filter(IsBornAfter(2010));
        }

        private static Predicate<TItem> IsBornAfter(int year)
        {
	        return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<TItem> AllDogsBornAfter2010()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Dog && pet.yearOfBirth > 2010));
        }

        public IEnumerable<TItem> AllMaleDogs()
        {
            return _petsInTheStore.Filter((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<TItem> AllPetsBornAfter2011OrRabbits()
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