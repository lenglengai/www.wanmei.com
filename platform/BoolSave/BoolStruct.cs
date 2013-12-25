namespace platform 
{
    class BoolStruct
    {
        public void _setBoolType(
            BoolType_ nBoolType)
        {
            mBoolType = nBoolType;
        }

        public BoolType_ _getBoolType()
        {
            return mBoolType;
        }

        public void _setLength(
            ushort nLength)
        {
            mLength = nLength;
        }

        public ushort _getLength()
        {
            return mLength;
        }

        public void _setFirst(
            byte nFirst)
        {
            mFirst = nFirst;
        }

        public byte _getFirst()
        {
            return mFirst;
        }

        public void _setSecond(
            byte nSecond)
        {
            mSecond = nSecond;
        }

        public byte _getSecond()
        {
            return mSecond;
        }

        public BoolStruct(
            BoolType_ nBoolType,
            ushort nLength,
            byte nFirst,
            byte nSecond)
        {
            mBoolType = nBoolType;
            mLength = nLength;
            mFirst = nFirst;
            mSecond = nSecond;
        }
        BoolType_ mBoolType;
        ushort mLength;
        byte mFirst;
        byte mSecond;
    }
}
