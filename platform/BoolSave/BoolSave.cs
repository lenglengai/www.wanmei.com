namespace platform
{
    public class BoolSave
    {
        public BoolType_ _isOpen(ushort nIndex) {
            ushort length = default(ushort);
            byte pos = default(byte);
            return this._runIndex(nIndex, 
                out length, out pos);
        }

        public BoolType_ _runOpen(ushort nIndex) {
            ushort length = default(ushort);
            byte pos = default(byte);
            BoolType_ result = this._runIndex(nIndex,
                out length, out pos);
            if (BoolType_.mSucess_ != result) return result;
            ulong value_ = 1;
            value_ <<= pos;
            ulong open = value_ & mValue[length];
            if (open < 1) {
                mValue[length] += value_;
                mDirty = true;
                return BoolType_.mSucess_;
            }
            return BoolType_.mClosed_;
        }

        public BoolType_ _runClose(ushort nIndex) {
            ushort length = default(ushort);
            byte pos = default(byte);
            BoolType_ result = this._runIndex(nIndex, 
                out length, out pos);
            if (BoolType_.mSucess_ != result) return result;
            ulong value_ = 1;
            value_ <<= pos;
            ulong open = value_ & mValue[length];
            if (open > 0) {
                mValue[length] -= value_;
                mDirty = true;
                return BoolType_.mSucess_;
            }
            return BoolType_.mClosed_;
        }

        public bool _needSave() {
            return mDirty;
        }

        BoolType_ _runIndex(ushort nIndex,
            out ushort nLength, out byte nPos) {
            nLength = (ushort)(nIndex / 64);
            nPos = (byte)(nIndex % 64);
            if (nPos > 0) {
                nLength += 1;
            } else {
                nPos = 64;
            }
            if (nLength > mValue.Length) {
                return BoolType_.mOverflow_;
            }
            nLength -= 1;
            nPos -= 1;
            return BoolType_.mSucess_;
        }

        public BoolSave(byte mSize = 1)
        {
            mValue = new ulong[mSize];
            mDirty = false;
        }

        ulong[] mValue;
        bool mDirty;
    }
}
