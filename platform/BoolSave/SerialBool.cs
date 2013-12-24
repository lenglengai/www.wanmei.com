using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class SerialBool
    {
        public BoolType_ _isOpen(byte nIndex)
        {
            if (nIndex < 1) {
                return BoolType_.mOverflow_;
            }
            int first = nIndex * mSize;
            int index = first / 64;
            int second = first % 64;
            if (second < 1)
            {
                index -= 1;
                second = 64;
            }
            return this._isOpen(index, second);
        }

        public BoolType_ _runOpen(byte nIndex)
        {
            int first = nIndex * mSize;
            int index = first / 64;
            int second = first % 64;
            if (mSize <= second) {
                first = second - mSize;
                return _openIndex(index, 
                    first, second);
            }
            if (second < 1) {
                index -= 1;
                second = 64;
                first = second - mSize;
                return _openIndex(index,
                    first, second);
            }
            first = mSize - second;
            first = 64 - first;
            BoolType_ result =
                this._openIndex((index - 1), 
                first, 64);
            if (BoolType_.mSucess_ != result) {
                result =
                    this._openIndex(index,
                    0, second);
            }
           return result;
        }

        BoolType_ _isOpen(int nIndex, int nSecond)
        {
            ulong value_ = 1;
            value_ <<= (nSecond - 1);
            ulong count = 
                (value_ & mValue[nIndex]);
            if (count > 0) {
                return BoolType_.mOpened_;
            }
            return BoolType_.mClosed_;
        }

        BoolType_ _openIndex(int nIndex, 
            int nFirst, int nSecond)
        {
            ulong value_ = 1;
            value_ <<= nFirst;
            for (int i = nFirst; i < nSecond; ++i)
            {
                ulong count = 
                    (value_ & mValue[nIndex]);
                if (count < 1)
                {
                    mValue[nIndex] += value_;
                    return BoolType_.mSucess_;
                }
                value_ <<= 1;
            }
            return BoolType_.mOpened_;
        }

        public SerialBool(byte nSize,
            byte nCount = 1)
        {
            mValue = new ulong[nCount];
            mSize = nSize;
        }

        ulong[] mValue;
        byte mSize;
    }
}
