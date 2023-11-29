namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _criteria1;
        protected Criteria<TItem> _criteria2;

        public BinaryCriteria(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}