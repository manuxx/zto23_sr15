namespace Training.DomainClasses
{
    public class Alternative<IItem> : Criteria<IItem>
    {
        private readonly Criteria<IItem> _criteria;
        private readonly Criteria<IItem> _criteria2;

        public Alternative(Criteria<IItem> criteria, Criteria<IItem> criteria2)
        {
            _criteria = criteria;
            _criteria2 = criteria2;
        }

        public override bool IsSatisfiedBy(IItem item)
        {
            return _criteria.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }
}