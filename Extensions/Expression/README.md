# Krzaq.Extensions.Expression
Extension adds few method to Linq expressions.

## v1.0.2
Changed:
* `string GetMemberName<T>(this LambdaExpression expression)` to `string GetMemberName(this LambdaExpression expression)`

## v1.0.1
Changed:
* `string GetMemberName<T>(this Expression<Func<T, object>> expression)` to `string GetMemberName<T>(this LambdaExpression expression)`

## v1.0.0
Added:
* `string GetMemberName<T>(this Expression<Func<T, object>> expression)`
