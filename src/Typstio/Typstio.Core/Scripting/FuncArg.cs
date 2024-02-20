using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Scripting;

public abstract record FuncArg(bool HasValue, bool IsRequired = false);

/// <summary>
/// Аргумент, у которого можно указать имя в скобках
/// </summary>
public record NamedArg(string Name, object? Value, bool IsRequired = false) : FuncArg(HasValue: Value != default, IsRequired);

/// <summary>
/// Аргумент, у которого нельзя указать имя в скобках
/// </summary>
public record PositionalArg(object? Value, bool IsRequired = false) : FuncArg(HasValue: Value != default, IsRequired);

public record ContentArg(ContentWriter Content) : PositionalArg(Content, IsRequired: true);
public record ContentNamedArg(string Name, ContentWriter Content, bool IsRequired = false) : NamedArg(Name, Content, IsRequired);
public record FunctionNamedArg(string Name, TypstFunction? Function, bool IsRequired = false) : NamedArg(Name, Function, IsRequired);