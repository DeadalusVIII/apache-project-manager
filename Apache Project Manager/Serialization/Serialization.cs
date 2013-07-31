using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using YAXLib;

namespace Apache_Project_Manager.Serialization
{
    public class Serialization
    {
        /// <summary>
        /// Converts (Serializes) an object to an xml string.
        /// Uses UTF-8 encoding in the string.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <returns>Xml string obtained.</returns>
        public static string SerializeToXmlString<T>(T obj)
        {
            YAXSerializer serializer = new YAXSerializer(typeof(T));
            return serializer.Serialize(obj);

            /*XmlSerializer xmls = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.NewLineChars = Environment.NewLine;
                settings.ConformanceLevel = ConformanceLevel.Document;

                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    xmls.Serialize(writer, obj);
                }

                string xml = Encoding.UTF8.GetString(ms.ToArray());
                return xml;
            }*/
        }



        /// <summary>
        /// Converts (Deserializes) an xml string to an object.
        /// Consideres that the string uses a UTF-8 encoding.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="xmlString">Xml string.</param>
        /// <returns>Object obtained.</returns>
        public static T DeserializeFromXmlString<T>(string xmlString)
        {
            /*XmlSerializer xmls = new XmlSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                return (T)xmls.Deserialize(ms);
            }*/
            YAXSerializer serializer = new YAXSerializer(typeof(T));
            return (T)serializer.Deserialize(xmlString);
        }


        /*
        /// <summary>
        /// Serializes an object of type T to a String.
        /// </summary>
        public static String SerializeToString<T>(T obj)
        {
            StringWriter sw = new StringWriter();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(sw, obj);

            return sw.ToString();
        }

         * 
        /// <summary>
        /// Deserializes an object of type T from a String.
        /// </summary>
        public static T DeserializeFromString<T>(String s)
        {
            StringReader sr = new StringReader(s);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(sr);
        }*/



        /// <summary>
        /// Converts (Serializes) an object to an byte array.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="obj">Object to be converted.</param>
        /// <returns>Byte array obtained.</returns>
        public static byte[] SerializeToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }



        /// <summary>
        /// Converts (Deserializes) a byte array to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="arrBytes">Byte array.</param>
        /// <returns>Object obtained.</returns>
        public static T DeserializeFromByteArray<T>(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T obj = (T)binForm.Deserialize(memStream);
            return obj;
        }



        /// <summary>
        /// Clones an object by using serialization.
        /// </summary>
        /// <typeparam name="T">Object Type.</typeparam>
        /// <param name="source">Object to be cloned.</param>
        /// <returns>Clone of introduced object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
