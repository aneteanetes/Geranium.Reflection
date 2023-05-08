# Geranium.Reflection
[![NuGet version](https://badge.fury.io/nu/Geranium.Reflection.svg)](https://badge.fury.io/nu/Geranium.Reflection)

.NET reflection provided by ExpressionTrees.
An alternative for reflection by extensions methods based on Expressions. This extensions allow create new instances without activator, set or get property values of unknown types and unknown properties, check equality with unknown type default value, call object methods and extension methods avoiding Invoke, and couple of non-expression extensions for as/is.

## Benchmarks
 [Benchmarks resuts](https://github.com/anetegithub/Geranium.Reflection/wiki/Benchmarks)
* `New()` average faster then `Activator` in **10** times
* `GetPropValue()` average faster then `PropertyInfo` in **2** times
* `SetPropValue()` average faster then `PropertyInfo` in **2** times


## Short list of features:
* `New`
* `get/set`
* `default`
* `is`
* `as`
* `call`

## Supported targets:
* `net6.0+`
* `netcoreapp3.1+`
* `netstandard2.1+`
* `net46+`

## New
Alternative for `Activator.CreateInstance` provided by `Expression.New` lambda cached by `System.Type` into `Delegate`.
### Available methods
* `object New(this object obj)`
* `object New<T1, T2, ..., T16>(this object obj, T1 arg1,T2 arg2,..., T16 arg16)`
* `object New(this object obj, params object[] args)`

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
    var migration = migrationType.New().As<CodegenMigration>();
    ...
    migration.Apply();
    ...
}
```
## Get property / Set property
## Get property values:
There is three methods for getting value from property based on `Expression.PropertyOrField`:
* `object GetPropValue(this object obj, string propName)`
* `TValue GetPropValue<TValue>(this object obj, string propName)`
* `TValue GetPropValue<THost, TValue>(this THost obj, string propName)`

Example of getting 'Id' value of uknown type:
```C#
var rowAccess = new RowAccess
{
    Type = typeof(T),
    IdValue = entity.GetPropValue("Id") // value can be long/string/Guid or something
};
```
## Set property values:
There is only one method for setting value:
* `void SetPropValue(this object obj, string propName, object propValue)`

But it can works different based on passed value:
* Usually (for `nullable` too) its just set value by lambda
* For `enum` values it wraps action with `Enum.Parse(value.ToString())`
* If you pass wrong `type` for value, it will try convert by `Convert.ChangeType`

Example method of setting 'Id' value when you don't know type:
```C#
public static void SetId<TId>(this object obj, TId value) 
=> obj.SetPropValue("Id", value);

public static void SetId(this object obj, object value) 
=> obj.SetPropValue("Id", value);

```
Example of create IList and bind to object:
```C#
var type = obj.GetType();
var prop = type.GetProperty('Users');
var list = prop.IList();
obj.SetPropValue(prop.Name, list);
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

Example of using `Call` chain with `LiteDatabase`: gettin anonymous class from store in runtime:

```C#

var liteDbCollectionQueryable = LiteDb
    .CallGeneric("GetCollection", new Type[] { type })
    .Call("FindAll")
    .CallGenericExtension("ToList", typeof(Enumerable), new[] { type })
    .CallGenericExtension("AsQueryable", typeof(Queryable), new[] { type });
    
var filtered = SelectionModelConverter
    .CallGeneric("Convert", new Type[] { type }, selection, liteDbCollectionQueryable)
    .GetPropertyExprRaw("Result");
    
var (filteredPropertyConverted, anonymousType) = SelectionModelConverter
    .CallGeneric<(IQueryable, Type)>("ConvertProperties", new Type[] { type }, selection.Properties, filtered); // returns IQueryable and anonymousType
    
var materialize = filteredPropertyConverted.CallGenericExtension("ToList", typeof(Enumerable), new[] { anonymousType });

```

## TypeFromAssemblyExtensions
Extensions for getting `Type`s and instances of `Type` from `Assembly` and assembly names loaded from `AppDomain.Current.BasePath`.

## Note about performance (package version 1.0.0)
That's not speed-up alternative. You can check it by run some benchmarks. That's `alternative` of System.Reflection. 
With .NET6 all techniques of 'speed-up' by `ExpressionTrees` and even `source generators` is pointless because of reflection improvements described here: https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#reflection 
But still it can be useful alternative for full .NET Framework with 'old' runtime.