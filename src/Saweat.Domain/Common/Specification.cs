using System.Linq.Expressions;

namespace Saweat.Domain.Common;

public class Specification<T> where T : class
{
    public Specification(Expression<Func<T, bool>> expression)
    {
        Expression = expression;
    }

    public Expression<Func<T, bool>> Expression { get; }

    public bool IsSatisfiedBy(T entity)
    {
        return Expression.Compile().Invoke(entity);
    }
}