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

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy((Pet.IsASpeciesOf(Species.Mouse)));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsNotASpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Cat));
        }


        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(new Conjunction<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(new Alternative(Pet.IsASpeciesOf(Species.Rabbit), Pet.IsBornAfter(2011)));
        }
    }

    public class Alternative : Criteria<Pet>
    {
        private readonly Criteria<Pet> _isASpeciesOf;
        private readonly Criteria<Pet> _isBornAfter;

        public Alternative(Criteria<Pet> isASpeciesOf, Criteria<Pet> isBornAfter)
        {
            _isASpeciesOf= isASpeciesOf;
            _isBornAfter = isBornAfter;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _isASpeciesOf.IsSatisfiedBy(pet) || _isBornAfter.IsSatisfiedBy(pet);
        }

    }

    public class Conjunction<T> : Criteria<Pet>
    {
        private readonly Criteria<Pet> _isASpeciesOf;
        private readonly Criteria<Pet> _isBornAfter;
        public Conjunction(Criteria<Pet> isASpeciesOf, Criteria<Pet> isBornAfter)
        {
            _isASpeciesOf = isASpeciesOf;
            _isBornAfter = isBornAfter;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _isASpeciesOf.IsSatisfiedBy(pet) && _isBornAfter.IsSatisfiedBy(pet);
        }
    }
}