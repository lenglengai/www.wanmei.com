using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class SerialBool
    {
        public BoolType_ _runOpen(short nIndex)
        {
            nIndex *= mSize;
            int index = nIndex / 64;
            int second = nIndex % 64;
            int first = mSize - second;
            int pos = 64 - first;
            ulong value_ = 1;
            value_ <<= pos;
            for (int i = pos; i < 64; ++i)
            {
                ulong count = value_ & mValue[index];
                if (count < 1)
                {
                    mValue[index] += value_;
                    return BoolType_.mSucess_;
                }
                value_ <<= 1;
            }
            index += 1;
            return _openSecond(nIndex, second);
        }

        BoolType_ _openSecond(int nIndex, int nSecond)
        {
            ulong value_ = 1;
            for (int i = 0; i < nSecond; ++i)
            {
                ulong count = value_ & mValue[nIndex];
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
