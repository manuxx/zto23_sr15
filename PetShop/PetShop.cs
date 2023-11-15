using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<TIem> _petsInTheStore;

        public PetShop(IList<TIem> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<TIem> AllPets()
        {
            return new ReadOnly(_petsInTheStore);
        }

        public void Add(TIem newIem)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (newIem.name==pet.name)
      
                    return;
   
            }
            _petsInTheStore.Add(newIem);
        }
    }

    public class ReadOnly<TItem> : IEnumerable<TIem>
    {
        private readonly IEnumerable<TIem> items;

        public ReadOnly(IEnumerable<TIem> items)
        {
            items = items;
        }

        public IEnumerator<TIem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}