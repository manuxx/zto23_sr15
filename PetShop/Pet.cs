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

        public static Criteria<Pet> IsMale()
        {
            return new SexCriteria(Sex.Male);
        }

        public static Criteria<Pet> IsNotASpeciesOf(Species species)
        {
            return new Negation<Pet>(Pet.IsASpeciesOf(species));
        }

        public static Criteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }
        public class SexCriteria : Criteria<Pet>
        {
            private readonly Sex _sex;

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public override bool IsSatisfiedBy(Pet pet)
            {
                return pet.sex == _sex;
            }
        }

        public class BornAfterCriteria : Criteria<Pet>
        {
            private readonly int _year;

            public BornAfterCriteria(int year)
            {
                _year = year;
            }

            public override bool IsSatisfiedBy(Pet pet)
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

            public override bool IsSatisfiedBy(Pet pet)
            {
                return pet.species == _species;
            }
        }
        public class Negation<T> : Criteria<Pet>
        {
            private readonly Criteria<Pet> _isASpeciesOf;

            public Negation(Criteria<Pet> isASpeciesOf)
            {
                _isASpeciesOf = isASpeciesOf;
            }

            public override bool IsSatisfiedBy(Pet item)
            {
                return !_isASpeciesOf.IsSatisfiedBy(item);
            }
        }
    }
}