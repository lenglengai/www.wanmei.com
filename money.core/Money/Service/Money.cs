using platform;

namespace money.core
{
    public class Money
    {
        public void _setId(uint nId)
        {
            mId = nId;
        }

        public uint _getId()
        {
            return mId;
        }

        public void _setValue(uint nValue)
        {
            mValue = nValue;
        }

        public uint _getValue()
        {
            return mValue;
        }

        public void _setTotal(uint nTotal)
        {
            mTotal = nTotal;
        }

        public uint _getTotal()
        {
            return mTotal;
        }

        public void _setDayInc(uint nDayInc)
        {
            mDayInc = nDayInc;
        }

        public uint _getDayInc()
        {
            return mDayInc;
        }

        public void _setDayDec(uint nDayDec)
        {
            mDayDec = nDayDec;
        }

        public uint _getDayDec()
        {
            return mDayDec;
        }

        public void _setMaxInc(uint nMaxInc)
        {
            mMaxInc = nMaxInc;
        }

        public uint _getMaxInc()
        {
            return mMaxInc;
        }

        public void _setMaxDec(uint nMaxDec)
        {
            mMaxDec = nMaxDec;
        }

        public uint _getMaxDec()
        {
            return mMaxDec;
        }

        public void _setDebts(uint nDebts)
        {
            mDebts = nDebts;
        }

        public uint _getDebts()
        {
            return mDebts;
        }

        public Money(uint nId)
        {
            mId = nId;
            mValue = 0;
            mTotal = 0;
            mDayInc = 0;
            mDayDec = 0;
            mMaxInc = 0;
            mMaxDec = 0;
            mDebts = 0;
        }

        uint mId;
        uint mValue;
        uint mTotal;
        uint mDayInc;
        uint mDayDec;
        uint mMaxInc;
        uint mMaxDec;
        uint mDebts;
    }
}
