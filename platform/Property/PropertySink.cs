using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertySink
    {
        public void _runCreate(PropertyMgr nPropertyMgr)
        {
            foreach (KeyValuePair<uint, IPropertyId> i in mCreates)
            {
                IPropertyId propertyId_ = i.Value;
                nPropertyMgr._addPropertyId(propertyId_);
            }
            nPropertyMgr._runStart();
        }

        public void _registerCreate(IPropertyId nPropertyId)
        {
            uint propertyId_ = nPropertyId._getId();
            if (mCreates.ContainsKey(propertyId_))
            {
                LogService logService_ = __singleton<LogService>._instance();
                logService_._logError(string.Format(@"PropertySink _registerInit ContainsKey:{0}", propertyId_));
                throw new Exception();
            }
            mCreates[propertyId_] = nPropertyId;
        }

        public IPropertyId _getPropertyId(uint nPropertyId)
        {
            IPropertyId result_ = null;
            if (mCreates.ContainsKey(nPropertyId))
            {
                result_ = mCreates[nPropertyId];
            }
            return result_;
        }

        public PropertySink()
        {
            mCreates = new Dictionary<uint, IPropertyId>();
        }

        Dictionary<uint, IPropertyId> mCreates;
    }
}
