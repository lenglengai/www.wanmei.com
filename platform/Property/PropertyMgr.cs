using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertyMgr
    {
        public __t _getProperty<__t>(uint nPropertyId) where __t : Property
        {
            __t result_ = default(__t);
            if (mPropertys.ContainsKey(nPropertyId))
            {
                result_ = (__t)mPropertys[nPropertyId];
            }
            return result_;
        }

        public void _addPropertyId(IPropertyId nPropertyId)
        {
            uint propertyId_ = nPropertyId._getId();
            if (mPropertys.ContainsKey(propertyId_))
            {
                LogService logService_ = __singleton<LogService>._instance();
                logService_._logError(string.Format(@"PropertyMgr _AddProperty ContainsKey:{0}", propertyId_));
                throw new Exception();
            }
            Property property_ = nPropertyId._createProperty();
            property_._setPropertyMgr(this);
            property_._initCreate();
            mPropertys[propertyId_] = property_;
        }

        public void _runInit()
        {
            foreach (KeyValuePair<uint, Property> i in mPropertys)
            {
                Property property_ = i.Value;
                property_._runInit();
            }
        }

        public PropertyMgr()
        {
            mPropertys = new Dictionary<uint, Property>();
        }

        Dictionary<uint, Property> mPropertys;
    }
}
