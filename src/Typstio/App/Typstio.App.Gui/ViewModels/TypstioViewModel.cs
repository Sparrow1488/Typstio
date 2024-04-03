using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Typstio.App.Gui.Contracts;
using Typstio.App.Gui.Data;
using Typstio.App.Gui.Events;
using Typstio.App.Gui.Services;
using Typstio.App.Gui.Views;
using Typstio.Core.Contracts;
using Typstio.Core.Services;

namespace Typstio.App.Gui.ViewModels;

public sealed class TypstioWindowViewModel
{
    readonly IDataSources _dataSources;
    readonly IEventAggregator _events;
    readonly IReport _report;
    readonly TypstCompiler _compiler = new();
    
    public TypstioWindowViewModel(IDataSources dataSources, IEventAggregator events, IReport report)
    {
        _dataSources = dataSources;
        _events = events;
        _report = report;
        
        CreateElement = new AsyncDelegateCommand<ElemTag>(OnCreateElementAsync);
        CompileReport = new AsyncDelegateCommand(OnCompileReportAsync);
        AddDataFileSource = new DelegateCommand(OnAddDataFileSource);
    }

    public ICommand CreateElement { get; }
    public ICommand CompileReport { get; }
    public ICommand AddDataFileSource { get; }

    async Task OnCreateElementAsync(ElemTag tag)
    {
        IContentWritable element = tag switch
        {
            ElemTag.Header => ControlsFactory.Header(1),
            ElemTag.Table => ControlsFactory.Table(),
            _ => throw new NotImplementedException()
        };
        
        if (element is IDataBindable bindable)
        {
            if (_dataSources.Sources.Count == 0)
            {
                MessageBox.Show("Нельзя создать Bindable элемент без источника данных.", "Ошибка");
                return;
            }

            // Пока прикрепляю данные таким образом. Потом будет возможность выбора через UI
            var source = _dataSources.Sources.Last();
            var data = await source.ProvideAsync();

            await data.LoadAsync();
            bindable.Bind(data);
        }
        
        _events.GetEvent<ReportAppendElementEvent>().Publish(element);
    }

    async Task OnCompileReportAsync()
    {
        const string output = "./output.pdf";
        await _compiler.PdfAsync(_report.Content, "code.txt", output);
        
        Process.Start("explorer", Path.GetFullPath(output));
    }

    void OnAddDataFileSource()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Json file |*.json",
            FilterIndex = 1,
            Multiselect = false
        };

        if (dialog.ShowDialog() is not true)
        {
            return;
        }
        
        var source = new JsonDataSource(dialog.FileName);
        _dataSources.Sources.Add(source);
    }
}