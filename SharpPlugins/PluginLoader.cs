using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SharpPlugins
{
    public static class PluginLoader
    {
        public static IEnumerable<TPlugin> InstanciatePlugins<TPlugin>(IEnumerable<Type> types) where TPlugin : PluginBase
        {
            return InstanciatePlugins<TPlugin>(types, new object[0]);
        }

        public static IEnumerable<TPlugin> InstanciatePlugins<TPlugin>(IEnumerable<Type> types, params object[] args) where TPlugin : PluginBase
        {
            return from type in types
                   where IsInstanciablePlugin(type)
                   select (TPlugin)Activator.CreateInstance(type, args);
        }

        public static bool IsInstanciablePlugin(Type type)
        {
            return PluginBase.IsRegisteredPlugin(type) && !type.IsAbstract;
        }

        public static IEnumerable<Type> LoadPluginsFromFiles<TPlugin>(IEnumerable<string> pluginFiles) where TPlugin : PluginBase
        {
            return from pluginFile in pluginFiles
                   let assembly = Assembly.LoadFrom(pluginFile)
                   from type in assembly.GetExportedTypes()
                   where IsInstanciablePlugin(type)
                   select type;
        }

        public static IEnumerable<Type> LoadPluginsFromFolders<TPlugin>(IEnumerable<string> pluginFolders) where TPlugin : PluginBase, new()
        {
            return from pluginFolder in pluginFolders
                   let files = Directory.EnumerateFiles(pluginFolder, "*.dll", SearchOption.AllDirectories)
                   let types = LoadPluginsFromFiles<TPlugin>(files)
                   from type in types
                   select type;
        }
    }
}