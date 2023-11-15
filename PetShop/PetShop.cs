using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            return Filter(pet => pet.species == Species.Cat);
        }
        
        public IEnumerable<Pet> Filter(Func<Pet, bool> predicate)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (predicate.Invoke(pet))
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

		public IEnumerable<Pet> AllMice()
		{
            return Filter(pet => pet.species == Species.Mouse);
		}

		public IEnumerable<Pet> AllFemalePets()
		{
            return Filter(pet => pet.sex == Sex.Female);
		}

		public IEnumerable<Pet> AllPetsButNotMice()
		{
            return Filter(pet => pet.species != Species.Mouse);
		}

		public IEnumerable<Pet> AllDogsBornAfter2010()
		{
			return Filter(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog );
		}

		public IEnumerable<Pet> AllMaleDogs()
		{
			return Filter(pet => pet.sex == Sex.Male && pet.species == Species.Dog );
		}

		public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
		{
			return Filter(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit  );
		}

		public IEnumerable<Pet> AllCatsOrDogs()
		{
			return Filter(pet => pet.species == Species.Dog || pet.species == Species.Cat  );
		}

		public IEnumerable<Pet> AllPetsBornAfter2010()
		{
			return Filter(pet => pet.yearOfBirth > 2010);
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