SharpPlugins
============

Helpers for having plugins in a .NET application.

-------------------------------------------------------------------------------------------------------------------------------------

##Usage##

Plugins have to be derived from `SharpPlugins.PluginBase`.

If they're supposed to be loaded, they have to be marked with the `SharpPlugins.PluginBase.RegisterPluginAttribute` and not be abstract.

The client just has to use the methods provided in the `SharpPlugins.PluginLoader` class.

###Example###

``` CSharp
using SharpPlugins;

namespace SharpPlugins.Example
{
  public abstract class ApplicationPluginBase : PluginBase
  {
    public abstract void DoStuff();
  }
  
  
  [RegisterPlugin(name: "Example Plugin", author: "Banane9")]
  public class ExampleApplicationPlugin : ApplicationPluginBase
  {
    public override void DoStuff()
    {
      // Do Stuff!
    }
  }
  
  internal class Program
  {
    private static void Main(string[] args)
    {
      var pluginInstance = PluginLoader.InstanciatePlugins<ApplicationPluginBase>(new Type[] { typeof(ExampleApplicationPlugin) }).First();
    }
  }
}


```
