using System;
using System.Collections.Generic;
using Training.DomainClasses;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Training.Specificaton
{
    public abstract class pet_shop_concern : Specification<PetShop>
    {
        Establish context = () =>
        {
            pet_initial_content = new List<Pet>();
            ProvideBasicConstructorArgument(pet_initial_content);
        };

        protected static IList<Pet> pet_initial_content;
    }

    public class when_counting_pets_in_the_shop : pet_shop_concern
    {
        Establish context = () =>
        {
            pet_initial_content.AddManyItems(new Pet(), new Pet());
        };
        Because of = () =>
        {
            number_of_pets = subject.AllPets().CountItems();
        };
        static int number_of_pets;

        It should_return_the_number_of_all_pets_in_the_shop = () =>
            number_of_pets.ShouldEqual(2);
    }

    public class when_asking_for_all_pets : pet_shop_concern
    {
        Establish context = () =>
        {
            first_pet = new Pet();
            second_pet = new Pet();
            pet_initial_content.AddManyItems(first_pet, second_pet);
        };

        Because of = () => pets_in_shop = subject.AllPets();

        It should_return_all_the_pets_in_the_shop = () =>
            pet_initial_content.ShouldContainOnly(first_pet, second_pet);

        static Pet first_pet;
        static Pet second_pet;
        static IEnumerable<Pet> pets_in_shop;
    }

    public class when_adding_a_new_pet : pet_shop_concern
    {
        Establish context = () => pet = new Pet();
        Because of = () => subject.Add(pet);

        It should_store_a_new_pet_in_the_shop = () =>
            subject.AllPets().ShouldContain(pet);

        static Pet pet;
<<<<<<< HEAD
    }

    public class when_adding_an_existing_pet_again_ : pet_shop_concern
=======
    }


	public class when_adding_an_existing_pet_again_ : pet_shop_concern
>>>>>>> 5cd8c7a02841fb3d9ea0f71c22947862932c2898
    {
        Establish context = () =>
        {
            pet = new Pet();
            pet_initial_content.Add(pet);
        };

        Because of = () =>
            subject.Add(pet);

        It should_store_a_pet_in_the_shop_once = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static Pet pet;
<<<<<<< HEAD
    }

    public class when_adding_a_new_pet_with_existing_name_ : pet_shop_concern
=======
    }


	public class when_adding_a_new_pet_with_existing_name_ : pet_shop_concern
>>>>>>> 5cd8c7a02841fb3d9ea0f71c22947862932c2898
    {
        Establish context = () =>
        {
            fluffy_the_first = new Pet { name = "Fluffy" };
            fluffy_the_second = new Pet { name = "Fluffy" };
            pet_initial_content.Add(fluffy_the_first);
        };

        Because of = () => subject.Add(fluffy_the_second);

        It should_contain_only_one_pet_of_the_name_in_the_store = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static Pet fluffy_the_first;
        private static Pet fluffy_the_second;
    }

    [Subject(typeof(PetShop))]
    class when_trying_to_change_returned_collection_of_pets : pet_shop_concern
    {
        Establish c = () => pet_initial_content.AddManyItems(new Pet { name = "Pixie" }, new Pet { name = "Dixie" });
        Because b = () =>
        {
            IEnumerable<Pet> returned_pets = subject.AllPets();
            exception = Catch.Exception(() => { var x = (ICollection<Pet>)returned_pets; });
        };
        private static IEnumerable<Pet> returned_collection_of_pets;
        private static Exception exception;
        It invalid_cast_exception_should_be_thrown = () => exception.ShouldBeOfExactType<InvalidCastException>();
    }

}