using System.Linq;
using System.Xml.Linq;
using UnityEditor;

/// <summary>
/// Workaround for Omnisharp + Unity + VSCode
/// https://github.com/OmniSharp/omnisharp-vscode/issues/5494
/// </summary>
public class CodeActionsRestorer : AssetPostprocessor {
    private static string OnGeneratedCSProject(string path, string content) {
        var document = XDocument.Parse(content);
        document.Root.Descendants()
            .Where(x => x.Name.LocalName == "Analyzer")
            .Where(x => x.Attribute("Include").Value.Contains("Unity.SourceGenerators"))
            .Remove();
        return document.Declaration + System.Environment.NewLine + document.Root;
    }
}