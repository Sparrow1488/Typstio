using Typstio.Core.Models;

namespace Typstio.Core.Scripting;

public abstract record SignatureArgument(bool HasValue, bool IsRequired = false);

/// <summary>
/// Аргумент, у которого можно указать имя в скобках
/// </summary>
public record ArgumentWithName(string Name, object? Value, bool IsRequired = false) : SignatureArgument(HasValue: Value != default, IsRequired);

/// <summary>
/// Аргумент, у которого нельзя указать имя в скобках
/// </summary>
public record PositionalArgument(object? Value, bool IsRequired = false) : SignatureArgument(HasValue: Value != default, IsRequired);

public record ContentArgument(ContentWriter Content) : PositionalArgument(Content, IsRequired: true);
public record ContentArgumentWithName(string Name, ContentWriter Content, bool IsRequired = false) : ArgumentWithName(Name, Content, IsRequired);

public record FunctionArgumentWithName(string Name, ITypstFunction? Function, bool IsRequired = false) : ArgumentWithName(Name, Function, IsRequired);