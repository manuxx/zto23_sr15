using System;

namespace Training.DomainClasses
{
    public class Pet 
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Predicate<Pet> IsNotASpeciesOf(Species species)
        {
            return (pet => pet.species != species);
        }

        public static Criteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsBorAfter(int year)
        {
            return new BornCriteria(year);
        }

        public class SexCriteria : Criteria<Pet>
        {
            private readonly Sex _sex;

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public bool IsSatisfyBy(Pet pet)
            {
                return pet.sex == _sex;
            }
        }

        public class BornCriteria : Criteria<Pet>
        {
            private readonly int _year;

            public BornCriteria(int year)
            {
                _year = year;
            }

            public bool IsSatisfyBy(Pet pet)
            {
                return pet.yearOfBirth > _year;
            }
        }

        public class SpeciesCriteria : Criteria<Pet>
        {
            private readonly Species _species;

            public SpeciesCriteria(Species species)
            {
                _species = species;
            }

            public bool IsSatisfyBy(Pet pet)
            {
                return pet.species == _species;
            }
        }
    }
}