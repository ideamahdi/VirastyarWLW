using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VirastyarWLW
{
    internal class ResourceManager
    {
        #region Private Fields

        private Assembly m_mainAssembly = null;

        #endregion

        #region Ctors and Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManager"/> class.
        /// </summary>
        public ResourceManager()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManager"/> class.
        /// </summary>
        /// <param name="mainAssembly">The main assembly which contains the resources.</param>
        public ResourceManager(Assembly mainAssembly)
        {
            Init(mainAssembly);
        }

        /// <summary>
        /// Inits this instance with the given assembly instance as the main assembly.
        /// </summary>
        /// <param name="mainAssembly">The main assembly.</param>
        public void Init(Assembly mainAssembly)
        {
            Debug.Assert(mainAssembly != null);
            if (mainAssembly == null)
            {
                throw new ArgumentException("Main assembly should not be null!", "mainAssembly");
            }
            m_mainAssembly = mainAssembly;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the resource stream from the embedded resources of the main assembly.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        public Stream GetResource(string resourceName)
        {
            CheckInitialized();
            string fullResName = m_mainAssembly.FullName.Split(',')[0] + ".Resources." + resourceName;
            return m_mainAssembly.GetManifestResourceStream(fullResName);
        }

        /// <summary>
        /// Gets the resource stream from the embedded resources of the main assembly and saves 
        /// it at the given path.
        /// </summary>
        /// <param name="resourceName">Name of the embedded resource.</param>
        /// <param name="destPath">The destination path.</param>
        /// <returns></returns>
        public bool SaveResourceAs(string resourceName, string destPath)
        {
            CheckInitialized();

            string dirPath = Path.GetDirectoryName(destPath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                Stream inputStream = GetResource(resourceName);

                if (inputStream != null)
                {
                    using (inputStream)
                    {
                        inputStream.Seek(0, SeekOrigin.Begin);

                        using (var outputStream = File.Create(destPath))
                        {
                            var data = new byte[1024];
                            int readed;
                            do
                            {
                                readed = inputStream.Read(data, 0, data.Length);
                                outputStream.Write(data, 0, readed);
                            } while (readed == data.Length);

                            return true;
                        }
                    }
                }
                else // Try .zip files
                {
                    string zippedResourceName = resourceName + ".zip";
                    inputStream = GetResource(zippedResourceName);

                    if (inputStream != null)
                    {
                        using (inputStream)
                        {
                            inputStream.Seek(0, SeekOrigin.Begin);

                            using (var outputStream = File.Create(destPath))
                            {
                                using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                                {
                                    var data = new byte[1024];
                                    int readed;
                                    do
                                    {
                                        readed = gzipStream.Read(data, 0, data.Length);
                                        outputStream.Write(data, 0, readed);
                                    } while (readed == data.Length);
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine("Unable to save the resource:" + resourceName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to save the resource:" + resourceName);
            }

            return false;
        }

        /// <summary>
        /// Checks if the given resource name exists at <paramref name="basePath"/>. 
        /// If not, it restores the resource.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="basePath">The base path.</param>
        public void CheckAndRestoreResource(string resourceName, string basePath)
        {
            string resourceFilePath = Path.Combine(basePath, resourceName);
            if (!File.Exists(resourceFilePath))
            {
                SaveResourceAs(resourceName, resourceFilePath);
            }
        }

        #endregion

        #region Private Methods
        
        private void CheckInitialized()
        {
            if (m_mainAssembly == null)
                throw new InvalidOperationException("ResourceManager is not initialized");
        }

        #endregion
    }
}
