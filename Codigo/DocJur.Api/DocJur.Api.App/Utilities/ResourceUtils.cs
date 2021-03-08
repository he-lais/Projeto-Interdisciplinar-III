using System.IO;
using System.Reflection;

namespace DocJur.Api.App.Utilities
{
    /// <summary>
    /// Extensions and utilities methods to ease the coding with project resource files.
    /// </summary>
    public class ResourceUtils
    {
        /// <summary>
        /// Loads a resouce into a Stream.
        /// </summary>
        /// <param name="context">The class instance in the project that has the resource.</param>
        /// <param name="resourceName">The name of the resource file.</param>
        /// <param name="folder">The folder where the resource is located. Default = Assets</param>
        /// <returns></returns>
        public static Stream LoadResource(object context, string resourceName, string folder = "Assets")
        {
            Assembly contextAssembly = context.GetType().Assembly;
            Stream resourceStream = contextAssembly.GetManifestResourceStream($"{contextAssembly.GetName().Name}.{folder}.{resourceName}");
            return resourceStream;
        }
    }
}
