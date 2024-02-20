using Typstio.Core.Writers;

namespace Typstio.Core.Scripting;

public abstract record FuncArg;

/// <summary>
/// Аргумент, у которого можно указать имя в скобках
/// </summary>
public record NamedArg(string Name, object? Value, bool IsRequired = false) : FuncArg;

/// <summary>
/// Аргумент, у которого нельзя указать имя в скобках
/// </summary>
public record PositionalArg(object Value) : FuncArg;

public record ContentArg(ContentWriter Content) : PositionalArg(Content);