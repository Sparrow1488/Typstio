using Typstio.Core.Models;

namespace Typstio.App.Gui.Contracts;

public interface IReport
{
    ContentWriter Content { get; }
}