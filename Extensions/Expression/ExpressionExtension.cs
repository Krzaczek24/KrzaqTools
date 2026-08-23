using System;
using System.Linq.Expressions;

namespace Krzaq.Extensions.Expression
{
    public static class ExpressionExtension
    {
        public static string GetMemberName<T>(this Expression<Func<T, object>> expression) => expression.Body switch
        {
            MemberExpression memberExpression => memberExpression.Member.Name,
            UnaryExpression unaryExpression when unaryExpression.Operand is MemberExpression memberOperand => memberOperand.Member.Name,
            _ => throw new ArgumentException("Invalid expression")
        };
    }
}
