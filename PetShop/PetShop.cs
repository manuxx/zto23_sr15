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
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Cat).Or(Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));
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
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Dog).And(Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsMale().And(Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2011).Or(Pet.IsASpeciesOf(Species.Rabbit)));
        }
    }

    public class Conjunction<T> : Criteria<T>
    {
        private Criteria<T> _conjuntion1;
        private Criteria<T> _conjuntion2;

        public Conjunction(Criteria<T> predicate1, Criteria<T> predicate2)
        {
            _conjuntion1 = predicate1;
            _conjuntion2 = predicate2;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _conjuntion1.IsSatisfiedBy(item) && _conjuntion2.IsSatisfiedBy(item);
        }
    }

    public class Alternative<T> : Criteria<T>
    {
        private Criteria<T> _alternative1;
        private Criteria<T> _alternative2;

        public Alternative(Criteria<T> predicate1, Criteria<T> predicate2)
        {
            _alternative1 = predicate1;
            _alternative2 = predicate2;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _alternative1.IsSatisfiedBy(item) || _alternative2.IsSatisfiedBy(item);
        }
    }

    public class Negation<T> : Criteria<T>
    {
        private Criteria<T> _negation;

        public Negation(Criteria<T> negation)
        {
            _negation = negation;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !_negation.IsSatisfiedBy(item);
        }
    }
}