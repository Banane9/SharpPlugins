using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpPlugins
{
    /// <summary>
    /// The abstract base class for plugins.
    /// </summary>
    public abstract class PluginBase
    {
        /// <summary>
        /// Gets the plugin's Author, or empty string if it fails.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>The plugin's Author, or empty string if it fails.</returns>
        public static string GetAuthor(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Author == null ? string.Empty : attribute.Author;
        }

        /// <summary>
        /// Gets the plugin's Description, or empty string if it fails.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>The plugin's Description, or empty string if it fails.</returns>
        public static string GetDescription(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Description == null ? string.Empty : attribute.Description;
        }

        /// <summary>
        /// Gets the identifier for the plugin, or empty string if it fails.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>The identifier for the plugin, or empty string if it fails.</returns>
        public static string GetIdentifier(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Identifier == null ? string.Empty : attribute.Identifier;
        }

        /// <summary>
        /// Gets the plugin's Name, or empty string if it fails.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>The plugin's Name, or empty string if it fails.</returns>
        public static string GetName(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Name == null ? string.Empty : attribute.Name;
        }

        /// <summary>
        /// Gets the plugin's Version, or empty string if it fails.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>The plugin's Version, or empty string if it fails.</returns>
        public static string GetVersion(Type type)
        {
            var attribute = getAttribute(type);
            return attribute == null ? string.Empty : attribute.Version == null ? string.Empty : attribute.Version;
        }

        /// <summary>
        /// Gets whether the Type is a registered plugin or not.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>Whether the Type is a registered plugin or not.</returns>
        public static bool IsRegisteredPlugin(Type type)
        {
            return getAttribute(type) != null;
        }

        /// <summary>
        /// Gets the plugin's RegisteredPluginAttribute, or null if it fails.
        /// </summary>
        /// <param name="type">The plugin's Type.</param>
        /// <returns>The plugin's RegisteredPluginAttribute, or null if it fails.</returns>
        private static RegisterPluginAttribute getAttribute(Type type)
        {
            return (RegisterPluginAttribute)type.GetCustomAttributes(typeof(RegisterPluginAttribute), false).FirstOrDefault();
        }

        /// <summary>
        /// Marks a PluginBase derived class as to be loaded and contains some optional information about the plugin.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class RegisterPluginAttribute : Attribute
        {
            /// <summary>
            /// Gets the plugin's Author.
            /// </summary>
            public string Author { get; private set; }

            /// <summary>
            /// Gets the plugin's Description.
            /// </summary>
            public string Description { get; private set; }

            /// <summary>
            /// Gets an identifier for the plugin.
            /// </summary>
            public string Identifier { get; private set; }

            /// <summary>
            /// Gets the plugin's Name.
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Gets the plugin's Version.
            /// </summary>
            public string Version { get; private set; }

            /// <summary>
            /// Creates a new instance of the <see cref="SharpPlugins.PluginBase.RegisterPluginAttribute"/> class
            /// with the identifier, given optional information about the plugin to mark it as to be loaded.
            /// </summary>
            /// <param name="identifier">The identifier for the plugin.</param>
            /// <param name="author">The plugin's Author.</param>
            /// <param name="name">The plugin's Name.</param>
            /// <param name="version">The plugin's Version.</param>
            /// <param name="description">The plugin's Description.</param>
            public RegisterPluginAttribute(string identifier, string author = "", string name = "", string version = "", string description = "")
            {
                Identifier = identifier;
                Author = author;
                Name = name;
                Version = version;
                Description = description;
            }
        }
    }
}