using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class StringTable : IHeadstream
    {
        public void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mType, @"type");
            List<Strings> strings = new List<Strings>();
            nSerialize._serialize(ref strings, @"strings");
        }

        public string _streamName() {
            return "stringTable";
        }

        public uint getType() {
            return GenerateId._runCommon(mType);
        }

        public string getString(uint nNo) {
            string result = null;
            if (mStrings.ContainsKey(nNo)) {
                result = mStrings[nNo];
            } else {
                LogService logService_ =
                    __singleton<LogService>._instance();
                string logError =
                    string.Format(@"StringTable getString:{0}",
                        mType);
                logService_._logError(logError);
            }
            return result;
        }

        Dictionary<uint, string> mStrings;
        string mType;
    }
}
