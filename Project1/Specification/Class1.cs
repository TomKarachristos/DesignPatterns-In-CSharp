using System;

namespace Specification
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(object candidate);
        ISpecification And(ISpecification other);
        ISpecification AndNot(ISpecification other);
        ISpecification Or(ISpecification other);
        ISpecification OrNot(ISpecification other);
        ISpecification Not();
    }
}
