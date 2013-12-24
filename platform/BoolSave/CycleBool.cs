using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class CycleBool
    {
        public BoolType_ _runOpen(byte nIndex)
        {
            if (nIndex < 1) {
                return BoolType_.mOverflow_;
            }
            int first = nIndex * mSize;
            int index = first / 64;
            int second = first % 64;
            if (mSize <= second)
            {
                first = second - mSize;
                return _openNormal(index, 
                    first, second);
            }
            if (second < 1) {
                index -= 1;
                second = 64;
                return _openNormal(index,
                    first, second);
            }
            first = mSize - second;
            first = 64 - first;
            BoolType_ result =
                this._openIndex((index - 1), first, 64);
            if ( (BoolType_.mSucess_ != result)
                && (BoolType_.mNext_ != result) )
            {
                result = this._openIndex(index,
                    0, second);
                if (BoolType_.mNext_ == result) {
                    this._clearIndex((index - 1),
                        first, 64);
                    this._clearIndex(index,
                        0, second);
                    result = BoolType_.mSucess_;
                }
            }
            return result;
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
                    if (i == (nSecond - 1))
                    {
                        return BoolType_.mNext_;
                    }
                    return BoolType_.mSucess_;
                }
                value_ <<= 1;
            }
            return BoolType_.mError_;
        }

        BoolType_ _openNormal(int nIndex,
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
                    if (i == (nSecond - 1)) {
                        this._clearIndex(nIndex,
                            nFirst, nSecond);
                    }
                    return BoolType_.mSucess_;
                }
                value_ <<= 1;
            }
            return BoolType_.mError_;
        }

        void _clearIndex(int nIndex, 
            int nFirst, int nSecond)
        {
            ulong value_ = 1;
            value_ <<= nFirst;
            for (int i = nFirst; i < nSecond; ++i)
            {
                mValue[nIndex] -= value_;
                value_ <<= 1;
            }
        }

        public CycleBool(byte nSize,
            byte nCount = 1)
        {
            mValue = new ulong[nCount];
            mSize = nSize;
        }

        ulong[] mValue;
        byte mSize;
    }
}
