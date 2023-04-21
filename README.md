# Geranium.Reflection
.NET reflection provided by ExpressionTrees.
An alternative for reflection by extensions methods based on Expressions. This extensions allow create new instances without activator, set or get property values of unknown types and unknown properties, check equality with unknown type default value, call object methods and extension methods avoiding Invoke, and couple of non-expression extensions for as/is.

## Short list of features:
* `New`
* `get/set`
* `default`
* `is`
* `as`
* `call`

## New
Alternative for `Activator.CreateInstance` provided by `Expression.New` lambda cached by `System.Type` into `Delegate`.
### Available methods
* `T New<T>(this object)`
* `T New<T>(this object, object[] ctorArgs)`
* `T New<T>(this object, ConstructorInfo ctor, params object[] ctorArgs)` - main
* `object New(this object)`
* `object New(this object, object[] ctorArgs)` 
* `object New(this object, bool oblyParameterless, object[] ctorArgs)` - FirstOrDefault ctor

### Examples
Getting `List<T>` as `IList` of `Type` in runtime:
```C#
public static IList IList(this Type type)
{
    return typeof(List<>).MakeGenericType(type)
        .New()
        .As<IList>();
}
```
Create and apply migration from migration type:
```C#
void RunMigration(Type migrationType)
{
    var migration = migrationType.NewAs<CodegenMigration>();
    ...
    migration.Apply();
    ...
}
```
## Get property / Set property
## Get property values:
There is basic method for getting value from property based on `Expression.PropertyOrField`:
* `GetPropertyExprRaw(this object, string propertyName)`

And two overloads:
* `GetPropertyExpr<TValue>(this object, string propertyName)`
* `GetStaticProperty(this Type, string propertyName)`

Example of getting 'Id' value of uknown type:
```C#
var rowAccess = new RowAccess
{
    Type = typeof(T),
    IdValue = entity.GetPropertyExprRaw("Id") // value can be long/string/Guid or something
};
```
## Set property values:
There is couple of methods setting value or property: type-known - when you know type of property, and 'converted' - when value and property can be different types:
* `SetPropertyExprType(this @object, string propName, object propValue, Type valueType)`
* `SetPropertyExprConverted(this object @object, string propName, object propValue)`

'Converted' trying to convert value to property type, by:
* if nullable, `Expressions` too hard to predict, so: `prop.SetValue`
* if IsEnum, `Enum.Parse(value.ToString())`
* in other cases, `Convert.ChangeType`

After converting, using 'main' method `SetPropertyExprType`, which set value by `Delegate` compiled by expressions based on `Expression.Assign`.

Example method of setting 'Id' value when you don't know type:
```C#
public static void SetId<TId>(this object obj, TId value) 
=> obj.SetPropertyExprConverted("Id", value);

public static void SetId(this object obj, object value) 
=> obj.SetPropertyExprConverted("Id", value);

```
Example of create IList and bind to object:
```C#
var type = obj.GetType();
var prop = type.GetProperty('Users');
var list = prop.IList();
obj.SetPropertyExprConverted(prop.Name, list);
```

## Default
Alternative of `default` for `System.Type` in runtime based on `Expression.Default()` with cache available by `DefaultExtensions.Default(this Type type)`:
```C#
var type = obj.GetType();
var prop = type.GetProperty('Id');
var value = prop.GetValue(obj);
if(value.Equals(type.Default())
    Console.WriteLine("Property is not initialized!");
```

## Extensions provided not by ExpressionTree
### Equivalent of C# 'as'
* `As<T>(this object)`
* `As<T>(this object, bool throw)`
* `As<T>(this object, T default)`

### Equivalent of C# 'is/not' check
* `Is<T>(this object)`
* `Is<T>(this object, out T match)`
* `IsNot<T>(this object)`
* `IsNot<T>(this object, out T match)`
* `Is<T>(this Type)`
* `Is<T>(this Type, out T match)`
* `IsNot<T>(this Type)`
* `IsNot<T>(this Type, out T match)`

### Additional methods for 'is something'
* `IsSimple`
* `IsPrimitive`
* `IsNumericType`
* `IsDateType`
* `IsNullable`
* `IsNullablePrimitive`
* `IsAnonymousType`
* `IsICollection`
* `IsDbCollection`

### Additional methods for IEnumerable
'String' checks differenlty
* `IsEmpty`
* `IsNotEmpty`

## Call
Extensions for call methods by `ExpressionTrees`
Available methods for 'call':
* `obj.Call("Equalls",null);`
* `dbCtx.CallGeneric("Set",new Type[]{ typeof(User) });`
* `typeof(Console).CallStatic("WriteLine", "log");`
* `list.CallExtension("ToList",typeof("EnumerableExtensions");`

Overloads for `call static generic`, `call generic extension`, `Call with T result` etc included.

## TypeFromAssemblyExtensions
Extensions for getting `Type`s and instances of `Type` from `Assembly` and assembly names loaded from `AppDomain.Current.BasePath`.