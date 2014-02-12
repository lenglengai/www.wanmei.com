using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace platform
{
    public class XmlWriter : ISerialize
    {
        public void _serialize(ref bool nValue, string nName, bool nOptimal = default(bool))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            if (true == nValue)
            {
                xmlAttribute_.Value = "true";
            }
            else
            {
                xmlAttribute_.Value = "false";
            }
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref sbyte nValue, string nName, sbyte nOptimal = default(sbyte))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<sbyte> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (sbyte i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__i8");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref byte nValue, string nName, byte nOptimal = default(byte))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<byte> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (byte i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__u8");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref short nValue, string nName, short nOptimal = default(short))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<short> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (short i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__i16");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref ushort nValue, string nName, ushort nOptimal = default(ushort))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<ushort> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (ushort i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__u16");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref int nValue, string nName, int nOptimal = default(int))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<int> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (int i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__i32");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref uint nValue, string nName, uint nOptimal = default(uint))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<uint> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (uint i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__u32");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref long nValue, string nName, long nOptimal = default(long))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<long> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (long i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__i64");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref ulong nValue, string nName, ulong nOptimal = default(ulong))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<ulong> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (ulong i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__u64");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref string nValue, string nName, string nOptimal = default(string))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<string> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (string i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__str");
                child_.InnerText = i.Trim();
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref DateTime nValue, string nName, DateTime nOptimal = default(DateTime))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<DateTime> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (DateTime i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__datetime");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref float nValue, string nName, float nOptimal = default(float))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<float> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (float i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__float");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize(ref double nValue, string nName, double nOptimal = default(double))
        {
            if (nValue == nOptimal)
            {
                return;
            }
            XmlNode xmlAttribute_ = mXmlDocument.CreateNode(XmlNodeType.Attribute, nName, null);
            string value_ = Convert.ToString(nValue);
            xmlAttribute_.Value = value_;
            mXmlElement.Attributes.SetNamedItem(xmlAttribute_);
        }

        public void _serialize(ref List<double> nValue, string nName)
        {
            if (null == nValue)
            {
                return;
            }
            XmlElement root_ = mXmlDocument.CreateElement(nName);
            foreach (double i in nValue)
            {
                XmlElement child_ = mXmlDocument.CreateElement("__double");
                string value_ = Convert.ToString(i);
                child_.InnerText = value_;
                root_.AppendChild(child_);
            }
            mXmlElement.AppendChild(root_);
        }

        public void _serialize<__t>(ref __t nValue, string nName, __t nOptimal = default(__t)) where __t : IStream
        {
            if (null == nValue)
            {
                return;
            }
            mXmlElements.Push(mXmlElement);
            XmlElement xmlElement_ = mXmlDocument.CreateElement(nName);
            mXmlElement.AppendChild(xmlElement_);
            mXmlElement = xmlElement_;
            nValue._serialize(this);
            mXmlElement = mXmlElements.Pop();
        }
        
        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : IStream
        {
            if (null == nValue)
            {
                return;
            }
            mXmlElements.Push(mXmlElement);
            XmlElement xmlElement_ = mXmlDocument.CreateElement(nName);
            mXmlElement.AppendChild(xmlElement_);
            mXmlElement = xmlElement_;
            for (int i = 0; i < nValue.Count; i++)
            {
                __t value_ = nValue[i];
                this._serialize(ref value_, "__t");
            }
            mXmlElement = mXmlElements.Pop();
        }

        public void _openUrl(string nUrl)
        {
            SettingService settingService_ = __singleton<SettingService>._instance();
            string mPath = Path.Combine(settingService_._systemPath(), nUrl);
            XmlDeclaration xmlDeclaration_ = mXmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            mXmlDocument.AppendChild(xmlDeclaration_);
        }

        public void _openString(string nString)
        {
            XmlDeclaration xmlDeclaration_ = mXmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            mXmlDocument.AppendChild(xmlDeclaration_);
            mPath = nString;
            mMemory = true;
        }

        public string _getString()
        {
            if (mMemory)
            {
                mPath = mXmlDocument.OuterXml;
            }
            return mPath;
        }

        public void _selectStream(string nStreamName)
        {
            mXmlElement = mXmlDocument.CreateElement(nStreamName);
            mXmlDocument.AppendChild(mXmlElement);
        }

        public void _runClose()
        {
            if (!mMemory)
            {
                mXmlDocument.Save(mPath);
            }
            mXmlElements.Clear();
            mXmlElements = null;
            mXmlDocument = null;
            mXmlElement = null;
            mPath = null;
            mMemory = false;
        }

        public XmlWriter()
        {
            mXmlElements = new Stack<XmlElement>();
            mXmlDocument = new XmlDocument();
            mXmlElement = null;
            mPath = null;
        }

        Stack<XmlElement> mXmlElements;
        XmlDocument mXmlDocument;
        XmlElement mXmlElement;
        string mPath;
        bool mMemory;
    }
}
