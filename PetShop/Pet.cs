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

        public static Criteria<Pet> isSpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> isSpecificSex(Sex sex)
        {
            return new SexCriteria(sex);
        }

        public static Criteria<Pet> isNotSpeciesOf(Species species)
        {
            return new NotSpeciesOfCiteria(species);
        }

        public static Criteria<Pet> isBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }

        public class BornAfterCriteria : Criteria<Pet>
        {
            private int _year;

            public BornAfterCriteria(int year)
            {
                _year = year;
            }

            public bool IsSatisfiedBy(Pet pet)
            {
                return pet.yearOfBirth > _year;
            }
        }

        public class NotSpeciesOfCiteria : Criteria<Pet>
        {
            private Species _species;

            public NotSpeciesOfCiteria(Species species)
            {
                _species = species;
            }

            public bool IsSatisfiedBy(Pet pet)
            {
                return pet.species != _species;
            }
        }

        public class SexCriteria : Criteria<Pet>
        {
            private Sex _sex;

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public bool IsSatisfiedBy(Pet pet)
            {
                return pet.sex == _sex;
            }
        }

        public class SpeciesCriteria : Criteria<Pet>
        {
            private Species _species;

            public SpeciesCriteria(Species species)
            {
                _species = species;
            }

            public bool IsSatisfiedBy(Pet pet)
            {
                return pet.species == _species;
            }
        }
    }
}