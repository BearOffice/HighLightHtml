using Microsoft.ClearScript.V8;
using System.Reflection;

namespace HighLightHtml;

public class HighLight : IDisposable
{
	private readonly V8ScriptEngine _engine;
	private const string _jsFilePath = "HighLightHtml.Resources.highlight.min.js";
	private const string _hljsExtension = "function hlAuto(c){return hljs.highlightAuto(c).value;} " +
		"function hl(l,c){return hljs.highlight(l,c).value;}";
	private const string _highlightFuncName = "hl";
	private const string _highlightAutoFuncName = "hlAuto";

	public HighLight()
	{
		var assembly = Assembly.GetExecutingAssembly();
		using var stream = assembly.GetManifestResourceStream(_jsFilePath)
			?? throw new Exception($"Resource `{_jsFilePath}` not found.");

		using var reader = new StreamReader(stream);
		var code = reader.ReadToEnd();

		_engine = new V8ScriptEngine();

		_engine.Execute(code);
		_engine.Execute(_hljsExtension);
	}

	public string GetHtml(string code)
	{
		ArgumentNullException.ThrowIfNull(code);

		return _engine.Invoke(_highlightAutoFuncName, code).ToString() ?? string.Empty;
	}

	public string GetHtml(string language, string code)
	{
		ArgumentNullException.ThrowIfNull(language);
		ArgumentNullException.ThrowIfNull(code);

		return _engine.Invoke(_highlightFuncName, language, code).ToString() ?? string.Empty;
	}

	public void Dispose()
	{
		_engine.Dispose();
		GC.SuppressFinalize(this);
	}

	~HighLight()
	{
		_engine.Dispose();
	}
}
