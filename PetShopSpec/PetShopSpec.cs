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
            pet_initial_content = new List<TIem>();
            ProvideBasicConstructorArgument(pet_initial_content);
        };

        protected static IList<TIem> pet_initial_content;
    }

    public class when_counting_pets_in_the_shop : pet_shop_concern
    {
        Establish context = () =>
        {
            pet_initial_content.AddManyItems(new TIem(), new TIem());
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
            _firstIem = new TIem();
            _secondIem = new TIem();
            pet_initial_content.AddManyItems(_firstIem, _secondIem);
        };

        Because of = () => pets_in_shop = subject.AllPets();

        It should_return_all_the_pets_in_the_shop = () =>
            pet_initial_content.ShouldContainOnly(_firstIem, _secondIem);

        static TIem _firstIem;
        static TIem _secondIem;
        static IEnumerable<TIem> pets_in_shop;
    }

    public class when_adding_a_new_pet : pet_shop_concern
    {
        Establish context = () => _iem = new TIem();
        Because of = () => subject.Add(_iem);

        It should_store_a_new_pet_in_the_shop = () =>
            subject.AllPets().ShouldContain(_iem);

        static TIem _iem;
    }


	public class when_adding_an_existing_pet_again_ : pet_shop_concern
    {
        Establish context = () =>
        {
            _iem = new TIem();
            pet_initial_content.Add(_iem);
        };

        Because of = () =>
            subject.Add(_iem);

        It should_store_a_pet_in_the_shop_once = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static TIem _iem;
    }


	public class when_adding_a_new_pet_with_existing_name_ : pet_shop_concern
    {
        Establish context = () =>
        {
            fluffy_the_first = new TIem { name = "Fluffy" };
            fluffy_the_second = new TIem { name = "Fluffy" };
            pet_initial_content.Add(fluffy_the_first);
        };

        Because of = () => subject.Add(fluffy_the_second);

        It should_contain_only_one_pet_of_the_name_in_the_store = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static TIem fluffy_the_first;
        private static TIem fluffy_the_second;
    }

    [Subject(typeof(PetShop))]
    class when_trying_to_change_returned_collection_of_pets : pet_shop_concern
    {
        Establish c = () => pet_initial_content.AddManyItems(new TIem { name = "Pixie" }, new TIem { name = "Dixie" });
        Because b = () =>
        {
            IEnumerable<TIem> returned_pets = subject.AllPets();
            exception = Catch.Exception(() => { var x = (ICollection<TIem>)returned_pets; });
        };
        private static IEnumerable<TIem> returned_collection_of_pets;
        private static Exception exception;
        It invalid_cast_exception_should_be_thrown = () => exception.ShouldBeOfExactType<InvalidCastException>();
    }

}