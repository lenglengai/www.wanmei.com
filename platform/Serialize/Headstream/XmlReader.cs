using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace platform
{
    public class XmlReader : ISerialize
    {
        public void _serialize(ref bool nValue, string nName,
            bool nOptimal = default(bool)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null == xmlAttribute_) return;
            string text_ = xmlAttribute_.InnerText;
            if (@"true" == text_) {
                nValue = true;
            }  else if (@"false" == text_) {
                nValue = false;
            } else {
                nValue = nOptimal;
            }
        }

        public void _serialize(ref sbyte nValue, string nName,
            sbyte nOptimal = default(sbyte)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToSByte(text_);
            }
        }
        
        public void _serialize(ref List<sbyte> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<sbyte>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                sbyte value_ = Convert.ToSByte(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref byte nValue, string nName,
            byte nOptimal = default(byte)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToByte(text_);
            }
        }

        public void _serialize(ref List<byte> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<byte>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                byte value_ = Convert.ToByte(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref short nValue, string nName,
            short nOptimal = default(short)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToInt16(text_);
            }
        }

        public void _serialize(ref List<short> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<short>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                short value_ = Convert.ToInt16(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref ushort nValue, string nName,
            ushort nOptimal = default(ushort)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToUInt16(text_);
            }
        }

        public void _serialize(ref List<ushort> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<ushort>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                ushort value_ = Convert.ToUInt16(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref int nValue, string nName,
            int nOptimal = default(int)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToInt32(text_);
            }
        }

        public void _serialize(ref List<int> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<int>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                int value_ = Convert.ToInt32(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref uint nValue, string nName,
            uint nOptimal = default(uint)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToUInt32(text_);
            }
        }

        public void _serialize(ref List<uint> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<uint>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                uint value_ = Convert.ToUInt32(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref long nValue, string nName,
            long nOptimal = default(long)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToInt64(text_);
            }
        }

        public void _serialize(ref List<long> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<long>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                long value_ = Convert.ToInt64(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref ulong nValue, string nName,
            ulong nOptimal = default(ulong)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToUInt64(text_);
            }
        }

        public void _serialize(ref List<ulong> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<ulong>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                ulong value_ = Convert.ToUInt64(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref string nValue, string nName,
            string nOptimal = default(string)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                nValue = xmlAttribute_.InnerText;
            }
        }

        public void _serialize(ref List<string> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<string>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                nValue.Add(text_);
            }
        }

        //datetime
        public void _serialize(ref DateTime nValue, string nName,
            DateTime nOptimal = default(DateTime)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToDateTime(text_);
            }
        }

        public void _serialize(ref List<DateTime> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<DateTime>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                DateTime value_ = Convert.ToDateTime(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref float nValue, string nName, 
            float nOptimal = default(float)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToSingle(text_);
            }
        }

        public void _serialize(ref List<float> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<float>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                float value_ = Convert.ToSingle(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize(ref double nValue, string nName,
            double nOptimal = default(double)) {
            nValue = nOptimal;
            XmlAttribute xmlAttribute_ = mXmlNode.Attributes[nName];
            if (null != xmlAttribute_) {
                string text_ = xmlAttribute_.InnerText;
                nValue = Convert.ToDouble(text_);
            }
        }

        public void _serialize(ref List<double> nValue, string nName) {
            if (null == nValue) {
                nValue = new List<double>();
            }
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null == xmlNode_) return;
            foreach (XmlNode i in xmlNode_.ChildNodes) {
                string text_ = i.InnerText;
                double value_ = Convert.ToDouble(text_);
                nValue.Add(value_);
            }
        }

        public void _serialize<__t>(ref __t nValue, string nName,
            __t nOptimal = default(__t)) where __t : IStream {
            mXmlNodes.Push(mXmlNode);
            mXmlNode = mXmlNode.SelectSingleNode(nName);
            if (null == mXmlNode) {
                nValue = nOptimal;
            } else {
                if (object.Equals(nValue, default(__t))) {
                    nValue = Activator.CreateInstance<__t>();
                }
                nValue._serialize(this);
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _serialize<__t>(ref List<__t> nValue, string nName)
            where __t : IStream {
            if (null == nValue) {
                nValue = new List<__t>();
            }
            mXmlNodes.Push(mXmlNode);
            XmlNode xmlNode_ = mXmlNode.SelectSingleNode(nName);
            if (null != xmlNode_) {
                foreach (XmlNode i in xmlNode_.ChildNodes) {
                    mXmlNode = i;
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._serialize(this);
                    nValue.Add(t_);
                }
            }
            mXmlNode = mXmlNodes.Pop();
        }

        public void _openString(string nString) {
            mXmlDocument.LoadXml(nString);
        }

        public void _openUrl(string nUrl) {
            SettingService settingService_ = 
                __singleton<SettingService>._instance();
            string systemPath = settingService_._systemPath();
            string url_ = Path.Combine(systemPath, nUrl);
            mXmlDocument.Load(url_);
        }

        public void _selectStream(string nStreamName) {
            mXmlNode =
                mXmlDocument.SelectSingleNode(nStreamName);
        }

        public void _runClose() {
            mXmlDocument = null;
            mXmlNodes.Clear();
            mXmlNodes = null;
            mXmlNode = null;
        }

        public XmlReader() {
            mXmlDocument = new XmlDocument();
            mXmlNodes = new Stack<XmlNode>();
            mXmlNode = null;
        }

        XmlDocument mXmlDocument;
        Stack<XmlNode> mXmlNodes;
        XmlNode mXmlNode;
    }
}
