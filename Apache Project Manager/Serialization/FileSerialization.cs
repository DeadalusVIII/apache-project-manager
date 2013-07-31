using System;
using System.IO;

namespace Apache_Project_Manager.Serialization
{
    public class FileSerialization
    {
        /// <summary>
        /// Creates a new text file, writes the specified object (in xml format) to the file, and then closes the file. 
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="obj">Object to be written.</param>
        /// <param name="filePath">Path to the file.</param>
        public static void WriteToXmlFile<T>(T obj, String filePath)
        {
            String serializedString = Serialization.SerializeToXmlString(obj);
            File.WriteAllText(filePath, serializedString);
        }



        /// <summary>
        /// Opens a text file, converts the xml to an object, and then closes the file.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="filePath">Path to the file.</param>
        public static T ReadFromXmlFile<T>(String filePath)
        {
            String textFile = File.ReadAllText(filePath);

            T obj = Serialization.DeserializeFromXmlString<T>(textFile);

            return obj;
        }
        


        /// <summary>
        /// Creates a new binary file, writes the specified object to the file, and then closes the file. 
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="obj">Object to be written.</param>
        /// <param name="filePath">Path to the file.</param>
        public static void WriteToBinaryFile<T>(T obj, String filePath)
        {
            byte[] serializedBytes = Serialization.SerializeToByteArray(obj);
            File.WriteAllBytes(filePath, serializedBytes);
        }



        /// <summary>
        /// Opens a binary file, converts to an object, and then closes the file.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="filePath">Path to the file.</param>
        public static T ReadFromBinaryFile<T>(String filePath)
        {
            byte[] byteFile = File.ReadAllBytes(filePath);

            T obj = Serialization.DeserializeFromByteArray<T>(byteFile);

            return obj;
        }
    }
}
