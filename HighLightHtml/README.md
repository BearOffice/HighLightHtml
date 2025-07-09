# HighLightHtml
A simple .NET library that generates syntax-highlighted HTML code using [highlight.js](https://highlightjs.org/).  

It’s useful when you want to render highlighted code on the **server side**, rather than relying on client-side rendering.

## Usage
```csharp
var html = new HighLight().GetHtml("function a()");
Console.WriteLine(html);
```

**Output:**

```html
<span class="hljs-keyword">function</span> <span class="hljs-title function_">a</span>(<span class="hljs-params"></span>)
```

---

### Highlighting with Language Specified

```csharp
var html = new HighLight().GetHtml("cs", @"using HighLightHtml;

namespace TestProject;

[TestClass]
public class UnitTest1
{
	[TestMethod]
	public void TestMethod1()
	{
		var htmlA = new HighLight().GetHtml(""function"");
		Console.WriteLine(htmlA);

		var htmlB = new HighLight().GetHtml(""function"");
		Console.WriteLine(htmlB);
	}
}");
Console.WriteLine(html);
```

**Output:**

```html
<span class="hljs-keyword">using</span> HighLightHtml;

<span class="hljs-keyword">namespace</span> <span class="hljs-title">TestProject</span>;

[<span class="hljs-meta">TestClass</span>]
<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">UnitTest1</span>
{
        [<span class="hljs-meta">TestMethod</span>]
        <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">TestMethod1</span>()</span>
        {
                <span class="hljs-keyword">var</span> htmlA = <span class="hljs-keyword">new</span> HighLight().GetHtml(<span class="hljs-string">&quot;function&quot;</span>);
                Console.WriteLine(htmlA);

                <span class="hljs-keyword">var</span> htmlB = <span class="hljs-keyword">new</span> HighLight().GetHtml(<span class="hljs-string">&quot;function&quot;</span>);
                Console.WriteLine(htmlB);
        }
}
```
