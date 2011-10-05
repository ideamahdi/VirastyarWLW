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

        public ResourceManager()
        {
            
        }

        public ResourceManager(Assembly mainAssembly)
        {
            Init(mainAssembly);
        }

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

        public Stream GetResource(string resourceName)
        {
            CheckInitialized();
            string fullResName = m_mainAssembly.FullName.Split(',')[0] + ".Resources." + resourceName;
            return m_mainAssembly.GetManifestResourceStream(fullResName);
        }

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
