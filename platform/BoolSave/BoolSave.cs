using System;
namespace platform
{
    public class BoolSave
    {
        public BoolType_ _runOpen(ushort nIndex) {
            __tuple<BoolType_, ushort, byte> tuple_ =
                this._getIndex(nIndex);
            BoolType_ result = tuple_._get_0();
            if (BoolType_.mSucess_ == result) {
                result = this._openPos(tuple_._get_1(),
                    tuple_._get_2());
            }
            return result;
        }

        public BoolType_ _runClose(ushort nIndex) {
            __tuple<BoolType_, ushort, byte> tuple_ =
                this._getIndex(nIndex);
            BoolType_ result = tuple_._get_0();
            if (BoolType_.mSucess_ == result)
            {
                result = this._closePos(tuple_._get_1(),
                    tuple_._get_2());
            }
            return result;
        }

        public BoolType_ _isOpen(ushort nIndex)
        {
            __tuple<BoolType_, ushort, byte> tuple_ =
                this._getIndex(nIndex);
            BoolType_ result = tuple_._get_0();
            if (BoolType_.mSucess_ == result)
            {
                result = this._isOpen(tuple_._get_1(),
                    tuple_._get_2());
            }
            return result;
        }

        BoolType_ _openPos(ushort nLength, byte nPos) {
            ulong value_ = 1;
            value_ <<= nPos;
            ulong open = value_ & mValue[nLength];
            if (open < 1) {
                mValue[nLength] += value_;
                mDirty = true;
                return BoolType_.mSucess_;
            }
            return BoolType_.mOpened_;
        }

        BoolType_ _closePos(ushort nLength, byte nPos) {
            ulong value_ = 1;
            value_ <<= nPos;
            ulong close = value_ & mValue[nLength];
            if (close > 0) {
                mValue[nLength] -= value_;
                mDirty = true;
                return BoolType_.mSucess_;
            }
            return BoolType_.mClosed_;
        }

        BoolType_ _isOpen(ushort nLength, byte nPos) {
            ulong value_ = 1;
            value_ <<= nPos;
            ulong open = value_ & mValue[nLength];
            if (open < 1)
            {
                return BoolType_.mClosed_;
            }
            return BoolType_.mOpened_;
        }

        __tuple<BoolType_, ushort, byte> _getIndex(
            ushort nIndex) {
            if (nIndex < 1) {
                return new __tuple<BoolType_, ushort,
                    byte>(BoolType_.mIndex_, 0, 0);
            }
            ushort length = (ushort)(nIndex / 64);
            byte pos = (byte)(nIndex % 64);
            if (pos > 0) {
                pos -= 1;
            } else {
                length -= 1;
                pos = 63;
            }
            if (length >= mValue.Length) {
                return new __tuple<BoolType_, ushort, 
                    byte>(BoolType_.mOverflow_, 0, 0);
            }
            return new __tuple<BoolType_, ushort,
                byte>(BoolType_.mSucess_, length, pos);
        }

        public bool _needSave()
        {
            return mDirty;
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
