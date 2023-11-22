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

        public static Predicate<Pet> IsSpeciesOf(Species species)
        {
            return pet => pet.species == species;
        }

        public static Predicate<Pet> IsSexOf(Sex female)
        {
            return pet => pet.sex == female;
        }

        public static Predicate<Pet> IsNotSpeciesOf(Species species)
        {
            return pet => pet.species != species;
        }

        public static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }
    }
}