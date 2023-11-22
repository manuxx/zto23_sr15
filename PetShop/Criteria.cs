using Training.DomainClasses;

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}

public class SexCriteria : Criteria<Pet>
{
    private readonly Sex _sex;
    public SexCriteria(Sex sex)
    {
        _sex = sex;
    }


    public bool IsSatisfiedBy(Pet item)
    {
        return item.sex == _sex;
    }
}

public class BornAfterCriteria : Criteria<Pet>
{
    private readonly int _year;
    public BornAfterCriteria(int year)
    {
        _year = year;
    }


    public bool IsSatisfiedBy(Pet item)
    {
        return item.yearOfBirth > _year;
    }
}

public class SpeciesCriteria : Criteria<Pet>
{
    private readonly Species _species;
    public SpeciesCriteria(Species species)
    {
        _species = species;
    }


    public bool IsSatisfiedBy(Pet item)
    {
        return item.species == _species;
    }
}