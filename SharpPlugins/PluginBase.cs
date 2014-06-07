using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpPlugins
{
    public class PluginBase
    {
        public static string GetAuthor(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Author;
        }

        public static string GetDescription(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Description;
        }

        public static string GetName(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Name;
        }

        public static string GetVersion(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Version;
        }

        public static bool IsRegisteredPlugin(Type type)
        {
            return getAttribute(type) != null;
        }

        private static RegisterPluginAttribute getAttribute(Type type)
        {
            return (RegisterPluginAttribute)type.GetCustomAttributes(typeof(RegisterPluginAttribute), false).FirstOrDefault();
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class RegisterPluginAttribute : Attribute
        {
            public string Author { get; set; }

            public string Description { get; set; }

            public string Name { get; set; }

            public string Version { get; set; }
        }
    }
}