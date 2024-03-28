using System.Diagnostics;
using System.IO.Compression;
using Typstio.Core.Models;

namespace Typstio.Core.Services;

public class TypstCompiler
{
    const string Version = "v0.11.0";
    const string Name = "typst-x86_64-pc-windows-msvc";
    const string DownloadUri = $"/{Version}/{Name}.zip";

    string? _typstPath;

    public TypstCompiler(string? typstPath = null)
    {
        _typstPath = typstPath;
    }

    static string LocalTypstPath => ApplicationTypstDir + "/" + Version + "/" + Name + "/typst.exe";
    static string ApplicationTypstDir => AppDomain.CurrentDomain.BaseDirectory + "/typst";
    
    public async Task PdfAsync(ContentWriter content, string codePath, string outputPath)
    {
        if (string.IsNullOrWhiteSpace(_typstPath) || !File.Exists(_typstPath))
        {
            await DownloadTypstAsync();
        }

        var code = CodeGenerator.ToCode(content);
        await File.WriteAllTextAsync(codePath, code);

        await Process.Start(_typstPath!, $"compile {codePath} {outputPath}").WaitForExitAsync();
    }

    async Task DownloadTypstAsync()
    {
        if (File.Exists(LocalTypstPath))
        {
            _typstPath = LocalTypstPath;
            return;
        }
        
        const string baseUrl = "https://github.com/typst/typst/releases/download";
        
        using var client = new HttpClient();
        await using var stream = await client.GetStreamAsync(baseUrl + DownloadUri);

        using var archive = new ZipArchive(stream);
        archive.ExtractToDirectory(ApplicationTypstDir + "/" + Version);

        if (!File.Exists(LocalTypstPath))
        {
            throw new InvalidOperationException("Failed to download typst");
        }
        
        _typstPath = LocalTypstPath;
    }
}