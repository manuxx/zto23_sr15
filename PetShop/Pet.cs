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

        public static Predicate<Pet> IsSexEqual(Sex sex)
        {
            return pet => pet.sex == sex;
        }

        public static Predicate<Pet> IsSpeciesNotEqual(Species species)
        {
            return pet => pet.species != species;
        }

        public static Predicate<Pet> IsSpeciesEqual(Species species)
        {
            return pet => pet.species == species;
        }

        public static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }
    }
}