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
            pet_initial_content = new List<TItem>();
            ProvideBasicConstructorArgument(pet_initial_content);
        };

        protected static IList<TItem> pet_initial_content;
    }

    public class when_counting_pets_in_the_shop : pet_shop_concern
    {
        Establish context = () =>
        {
            pet_initial_content.AddManyItems(new TItem(), new TItem());
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
            _firstItem = new TItem();
            _secondItem = new TItem();
            pet_initial_content.AddManyItems(_firstItem, _secondItem);
        };

        Because of = () => pets_in_shop = subject.AllPets();

        It should_return_all_the_pets_in_the_shop = () =>
            pet_initial_content.ShouldContainOnly(_firstItem, _secondItem);

        static TItem _firstItem;
        static TItem _secondItem;
        static IEnumerable<TItem> pets_in_shop;
    }

    public class when_adding_a_new_pet : pet_shop_concern
    {
        Establish context = () => _item = new TItem();
        Because of = () => subject.Add(_item);

        It should_store_a_new_pet_in_the_shop = () =>
            subject.AllPets().ShouldContain(_item);

        static TItem _item;
    }


	public class when_adding_an_existing_pet_again_ : pet_shop_concern
    {
        Establish context = () =>
        {
            _item = new TItem();
            pet_initial_content.Add(_item);
        };

        Because of = () =>
            subject.Add(_item);

        It should_store_a_pet_in_the_shop_once = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static TItem _item;
    }


	public class when_adding_a_new_pet_with_existing_name_ : pet_shop_concern
    {
        Establish context = () =>
        {
            fluffy_the_first = new TItem { name = "Fluffy" };
            fluffy_the_second = new TItem { name = "Fluffy" };
            pet_initial_content.Add(fluffy_the_first);
        };

        Because of = () => subject.Add(fluffy_the_second);

        It should_contain_only_one_pet_of_the_name_in_the_store = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static TItem fluffy_the_first;
        private static TItem fluffy_the_second;
    }

    [Subject(typeof(PetShop))]
    class when_trying_to_change_returned_collection_of_pets : pet_shop_concern
    {
        Establish c = () => pet_initial_content.AddManyItems(new TItem { name = "Pixie" }, new TItem { name = "Dixie" });
        Because b = () =>
        {
            IEnumerable<TItem> returned_pets = subject.AllPets();
            exception = Catch.Exception(() => { var x = (ICollection<TItem>)returned_pets; });
        };
        private static IEnumerable<TItem> returned_collection_of_pets;
        private static Exception exception;
        It invalid_cast_exception_should_be_thrown = () => exception.ShouldBeOfExactType<InvalidCastException>();
    }
    public class concern_with_pets_for_sorting_and_filtering : pet_shop_concern
    {
        private Establish c = () =>
        {
            mouse_Dixie = new TItem
            {
                name = "Dixie",
                species = Species.Mouse,
                price = 10,
                sex = Sex.Female,
                yearOfBirth = 2011
            };
            mouse_Jerry = new TItem
            {
                name = "Jerry",
                species = Species.Mouse,
                price = 5,
                sex = Sex.Male,
                yearOfBirth = 2012
            };

            cat_Tom = new TItem
            {
                name = "Tom",
                species = Species.Cat,
                price = 30,
                sex = Sex.Male,
                yearOfBirth = 2010
            };
            cat_Jinx = new TItem
            {
                name = "Jinx",
                species = Species.Cat,
                price = 40,
                sex = Sex.Male,
                yearOfBirth = 2009
            };
            rabbit_Fluffy = new TItem
            {
                name = "Fluffy",
                species = Species.Rabbit,
                price = 35,
                sex = Sex.Male,
                yearOfBirth = 2011
            };
            dog_Huckelberry = new TItem
            {
                name = "Huckelberry",
                species = Species.Dog,
                price = 80,
                sex = Sex.Male,
                yearOfBirth = 2008
            };
            dog_Lassie = new TItem
            {
                name = "Lassie",
                species = Species.Dog,
                price = 150,
                sex = Sex.Female,
                yearOfBirth = 2007
            };
            dog_Pluto = new TItem
            {
                name = "Pluto",
                species = Species.Dog,
                price = 100,
                sex = Sex.Male,
                yearOfBirth = 2011
            };
            pet_initial_content.AddManyItems(cat_Tom,
                                             cat_Jinx,
                                             dog_Huckelberry,
                                             dog_Lassie,
                                             dog_Pluto,
                                             rabbit_Fluffy,
                                             mouse_Dixie,
                                             mouse_Jerry);
        };

        protected static TItem mouse_Dixie;
        protected static TItem mouse_Jerry;
        protected static TItem rabbit_Fluffy;
        protected static TItem cat_Jinx;
        protected static TItem cat_Tom;
        protected static TItem dog_Huckelberry;
        protected static TItem dog_Lassie;
        protected static TItem dog_Pluto;
    }

    public class when_searching_for_pets : concern_with_pets_for_sorting_and_filtering
    {
        private It should_be_able_to_find_all_cats = () =>
        {
            var foundPets = subject.AllCats();
            foundPets.ShouldContainOnly(cat_Tom, cat_Jinx);
        };
        private It should_be_able_to_find_all_mice = () =>
        {
            var foundPets = subject.AllMice();
            foundPets.ShouldContainOnly(mouse_Dixie, mouse_Jerry);
        };
        private It should_be_able_to_find_all_female_pets = () =>
        {
            var foundPets = subject.AllFemalePets();
            foundPets.ShouldContainOnly(dog_Lassie, mouse_Dixie);
        };
        private It should_be_able_to_find_all_cats_or_dogs = () =>
        {
            var foundPets = subject.AllCatsOrDogs();
            foundPets.ShouldContainOnly(cat_Tom, cat_Jinx, dog_Huckelberry, dog_Lassie, dog_Pluto);
        };
        private It should_be_able_to_find_all_pets_but_not_mice = () =>
        {
            var foundPets = subject.AllPetsButNotMice();
            foundPets.ShouldContainOnly(cat_Tom, cat_Jinx, dog_Huckelberry, dog_Lassie, dog_Pluto, rabbit_Fluffy);
        };
        private It should_be_able_to_find_all_pets_born_after_2010 = () =>
        {
            var foundPets = subject.AllPetsBornAfter2010();
            foundPets.ShouldContainOnly(dog_Pluto, rabbit_Fluffy, mouse_Dixie, mouse_Jerry);
        };
        private It should_be_able_to_find_all_young_dogs = () =>
        {
            var foundPets = subject.AllDogsBornAfter2010();
            foundPets.ShouldContainOnly(dog_Pluto);
        };
        private It should_be_able_to_find_all_male_dogs = () =>
        {
            var foundPets = subject.AllMaleDogs();
            foundPets.ShouldContainOnly(dog_Huckelberry, dog_Pluto);
        };
        private It should_be_able_to_find_all_young_pets_or_rabbits = () =>
        {
            var foundPets = subject.AllPetsBornAfter2011OrRabbits();
            foundPets.ShouldContainOnly(mouse_Jerry, rabbit_Fluffy);
        };

    }

    class when_sorting_pets : concern_with_pets_for_sorting_and_filtering
    {
        It should_be_able_to_sort_by_name_ascending = () =>
        {
            var result = subject.AllPetsSortedByName();

            result.ShouldContainOnlyInOrder(mouse_Dixie, rabbit_Fluffy, dog_Huckelberry, mouse_Jerry, cat_Jinx,
                dog_Lassie,
                dog_Pluto, cat_Tom);
        };
    };

}