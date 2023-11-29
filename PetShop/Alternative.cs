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

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }
}