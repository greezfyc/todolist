using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Git.Todolist.Core
{
    public static class SerializeHelper
    {
        /// <summary>
        /// 获取对象序列化的二进制版本
        /// </summary>
        /// <param name="pObj">对象实体</param>
        /// <returns>如果对象实体为Null，则返回结果为Null。</returns>
        public static byte[] GetBytes(object pObj)
        {
            if (pObj == null) { return null; }
            MemoryStream serializationStream = new MemoryStream();
            new BinaryFormatter().Serialize(serializationStream, pObj);
            serializationStream.Position = 0L;
            byte[] buffer = new byte[serializationStream.Length];
            serializationStream.Read(buffer, 0, buffer.Length);
            serializationStream.Close();
            return buffer;
        }

        /// <summary>
        /// 获取对象序列化的XmlDocument版本
        /// </summary>
        /// <param name="pObj">对象实体</param>
        /// <returns>如果对象实体为Null，则返回结果为Null。</returns>
        public static XmlDocument GetXmlDoc(object pObj)
        {
            if (pObj == null) { return null; }
            XmlSerializer serializer = new XmlSerializer(pObj.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            serializer.Serialize((TextWriter)writer, pObj);
            XmlDocument document = new XmlDocument();
            document.LoadXml(sb.ToString());
            writer.Close();
            return document;
        }

        /// <summary>
        /// 从已序列化数据中(byte[])获取对象实体
        /// </summary>
        /// <typeparam name="T">要返回的数据类型</typeparam>
        /// <param name="binData">二进制数据</param>
        /// <returns>对象实体</returns>
        public static T GetObject<T>(byte[] binData)
        {
            if (binData == null) { return default(T); }
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream(binData);
            return (T)formatter.Deserialize(serializationStream);
        }

        /// <summary>
        /// 从已序列化数据(XmlDocument)中获取对象实体
        /// </summary>
        /// <typeparam name="T">要返回的数据类型</typeparam>
        /// <param name="xmlDoc">已序列化的文档对象</param>
        /// <returns>对象实体</returns>
        public static T GetObject<T>(XmlDocument xmlDoc)
        {
            if (xmlDoc == null) { return default(T); }
            XmlNodeReader xmlReader = new XmlNodeReader(xmlDoc.DocumentElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(xmlReader);
        }

        /// <summary>
        /// 序列化 对象到字符串；
        /// 不能序列化IDictionary接口.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string XmlSerialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(stream, Encoding.UTF8);
                serializer.Serialize(xmlTextWriter, obj);
                stream = (MemoryStream)xmlTextWriter.BaseStream;
                return System.Text.Encoding.UTF8.GetString(stream.GetBuffer());
            }
            catch (Exception ex)
            {
                throw new Exception("XmlSerialize序列化失败", ex);
            }
            finally
            {
                stream.Dispose();
            }
        }

        /// <summary>
        /// 序列化 对象到字符串
        /// 不能序列化IDictionary接口.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object XmlDeserialize(string xml, Type type)
        {
            MemoryStream stream = null;
            try
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(xml);
                XmlSerializer serializer = new XmlSerializer(type);
                stream = new MemoryStream(buffer);
                return serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                throw new Exception("XmlSerialize反序列化失败", ex);
            }
            finally
            {
                stream.Dispose();
            }
        }

    }
}