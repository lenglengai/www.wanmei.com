namespace platform
{
    public class Property
    {
        public virtual void _runPreinit() {
        }

        public virtual void _runInit() {
        }

        public void _setPropertyMgr(
            PropertyMgr nPropertyMgr) {
            mPropertyMgr = nPropertyMgr;
        }

        public __t _getPropertyMgr<__t>()
            where __t : PropertyMgr {
            return mPropertyMgr as __t;
        }

        public Property() {
            mPropertyMgr = null;
        }

        PropertyMgr mPropertyMgr;
    }
}
