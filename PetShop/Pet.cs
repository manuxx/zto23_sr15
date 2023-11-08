using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Pet);
        }

        public bool Equals(Pet other)
        {
            return !(other is null) &&
                   name == other.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return EqualityComparer<Pet>.Default.Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !(left == right);
        }
    }
}