using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft;
using Newtonsoft.Json;

namespace OpenHR
{
    public class FileHelper<T> where T : new()
    {
        private string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }
        public void SerializeToFile(T fileContent)
        {
            
            var serializer = new JsonSerializer();
            using (var streamWriter = new StreamWriter(_filePath))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(jsonWriter, fileContent);
                    streamWriter.Close();
                }

            }

        }

        public T DeserializedFromFile()
        {
            if (!File.Exists(_filePath))
                return new T();

            T fileContent;
            var serializer = new JsonSerializer();
            using (var streamReader = new StreamReader(_filePath))
            {
                fileContent =(T)serializer.Deserialize(streamReader, typeof(T)); 
                streamReader.Close();                  
            }

            return fileContent;
        }
        }

    }

