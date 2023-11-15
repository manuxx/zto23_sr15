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
            return new ReadOnly<Pet>(_petsInTheStore);
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

        public IEnumerable<Pet> AllCats()
        {
            IList<Pet> _petsInTheStore2 = new List<Pet>();
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species.Equals(Species.Cat))
                {
                    _petsInTheStore2.Add(pet);
                }
            }
            return _petsInTheStore2;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort ((p1, p2) => p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> Filter(Func<Pet, bool> condition)
        {
            IList<Pet> _petsInTheStore2 = new List<Pet>();
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                {
                    _petsInTheStore2.Add(pet);
                }
            }
            return _petsInTheStore2;
        }

        public IEnumerable<Pet> AllMice()
        {
            return Filter(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return Filter(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {

            return Filter(pet => (pet.species == Species.Cat || pet.species.Equals(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return Filter(pet => !pet.species.Equals(Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return Filter(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return Filter(pet => pet.yearOfBirth > 2010 && pet.species.Equals(Species.Dog));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return Filter(pet => pet.sex == Sex.Male && pet.species.Equals(Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return Filter(pet => pet.yearOfBirth > 2010 || pet.species.Equals(Species.Rabbit));
        }
    }

    public class ReadOnly<TItem> : IEnumerable<Pet>
    {
        private readonly IEnumerable<Pet> _pets;

        public ReadOnly(IEnumerable<Pet> pets)
        {
            _pets = pets;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}