namespace Training.DomainClasses
{
    public class Conjunction<IItem> : Criteria<IItem>
    {
        private readonly Criteria<IItem> _criteria;
        private readonly Criteria<IItem> _criteria2;

        public Conjunction(Criteria<IItem> criteria, Criteria<IItem> criteria2)
        {
            _criteria = criteria;
            _criteria2 = criteria2;
        }

        public override bool IsSatisfiedBy(IItem item)
        {
            return _criteria.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }
}