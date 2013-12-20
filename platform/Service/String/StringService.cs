using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class StringService
    {
        public string getString(string nType, string nName) {
            string result = null;
            uint type = GenerateId._runCommon(nType);
            if (mStringTable.ContainsKey(type)) {
                StringTable stringTable = mStringTable[type];
                result = stringTable.getString(type);
            } else {
                LogService logService_ = 
                    __singleton<LogService>._instance();
                string logError =
                    string.Format(@"StringService getString:{0}",
                        nType);
                logService_._logError(logError);
            }
            return result;
        }

        public void registerStrings(string nUrl) {
            StringTable stringTable = new StringTable();
            string streamName = stringTable._streamName();
            XmlReader xmlReader_ = new XmlReader();
            xmlReader_._openUrl(nUrl);
            xmlReader_._selectStream(streamName);
            stringTable._headSerialize(xmlReader_);
            xmlReader_._runClose();
            uint type = stringTable.getType();
            if (mStringTable.ContainsKey(type)) {
                mStringTable[type] = stringTable;
            } else {
                LogService logService_ =
                    __singleton<LogService>._instance();
                string logError =
                    string.Format(@"StringService registerStrings:{0}",
                        nUrl);
                logService_._logError(logError);
            }
        }
        public void _runPreinit() {
        }

        public StringService() {
            mStringTable = new Dictionary<uint, StringTable>();
        }
        Dictionary<uint, StringTable> mStringTable;
    }
}
