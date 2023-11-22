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

        public static Predicate<Pet> IsSpecies(Species species)
        {
            return pet => pet.species == species;
        }

        private static Predicate<Pet> IsNotSpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public static Predicate<Pet> IsSex()
        {
            return pet => pet.sex == Sex.Female;
        }

        public static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }
    }
}