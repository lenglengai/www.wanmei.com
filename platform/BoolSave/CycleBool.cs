using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class CycleBool
    {
        public __tuple<BoolType_, byte> _getOpen(
            ushort nIndex)
        {
            __tuple<BoolStruct, BoolStruct> tuple_ =
                this._getIndex(nIndex);
            BoolStruct first = tuple_._get_0();
            BoolStruct second = tuple_._get_1();
            byte pos = 0;
            BoolType_ boolType = first._getBoolType();
            if (BoolType_.mSucess_ == boolType)
            {
                __tuple<BoolType_, byte> tupleOpen =
                    this._getOpen(first._getLength(),
                    first._getFirst(), first._getSecond());
                boolType = tupleOpen._get_0();
                pos = tupleOpen._get_1();
            }
            if ((BoolType_.mOpened_ == boolType) &&
                    (BoolType_.mSucess_ == second._getBoolType()))
            {
                __tuple<BoolType_, byte> tupleOpen =
                    this._getOpen(second._getLength(),
                    second._getFirst(), second._getSecond());
                boolType = tupleOpen._get_0();
                pos = tupleOpen._get_1();
            }
            return new __tuple<BoolType_, byte>(boolType, pos);
        }

        public BoolType_ _runOpen(byte nIndex)
        {
            __tuple<BoolStruct, BoolStruct> tuple_ =
                this._getIndex(nIndex);
            BoolStruct first = tuple_._get_0();
            BoolStruct second = tuple_._get_1();
            BoolType_ result = first._getBoolType();
            if (BoolType_.mSucess_ == result)
            {
                result = this._openIndex(first._getLength(),
                    first._getFirst(), first._getSecond());
            }
            if ((BoolType_.mOpened_ == result) &&
                (BoolType_.mSucess_ == second._getBoolType())) 
            {
                result = this._openIndex(second._getLength(),
                    second._getFirst(), second._getSecond());
            }
            if (BoolType_.mNext_ == result){
                this._clearIndex(first._getLength(),
                    first._getFirst(), first._getSecond());
                this._clearIndex(second._getLength(),
                    second._getFirst(), second._getSecond());
            }
            return result;
        }

        __tuple<BoolType_, byte> _getOpen(ushort nLength,
            byte nFirst, byte nSecond)
        {
            BoolType_ boolType = BoolType_.mOpened_;
            byte pos = 0;
            ulong value_ = 1;
            value_ <<= nFirst;
            for (byte i = nFirst; i <= nSecond; ++i)
            {
                if ((value_ & mValue[nLength]) < 1)
                {
                    boolType = BoolType_.mSucess_;
                    pos = (byte)(i - nFirst);
                    break;
                }
                value_ <<= 1;
            }
            return new __tuple<BoolType_, byte>(
                boolType, pos);
        }

        BoolType_ _openIndex(int nIndex,
            int nFirst, int nSecond)
        {
            ulong value_ = 1;
            value_ <<= nFirst;
            for (int i = nFirst; i <= nSecond; ++i)
            {
                if ((value_ & mValue[nIndex]) < 1)
                {
                    mValue[nIndex] += value_;
                    if (i == nSecond)
                    {
                        return BoolType_.mNext_;
                    }
                    return BoolType_.mSucess_;
                }
                value_ <<= 1;
            }
            return BoolType_.mOpened_;
        }

        void _clearIndex(ushort nIndex, byte nFirst,
            byte nSecond)
        {
            ulong value_ = 1;
            value_ <<= nFirst;
            for (byte i = nFirst; i <= nSecond; ++i)
            {
                mValue[nIndex] -= value_;
                value_ <<= 1;
            }
        }

        __tuple<BoolStruct, BoolStruct> _getIndex(
            ushort nIndex)
        {
            BoolStruct first = new BoolStruct(
                    BoolType_.mNone_, 0, 0, 0);
            BoolStruct second = new BoolStruct(
                    BoolType_.mNone_, 0, 0, 0);
            if (nIndex < 1)
            {
                first._setBoolType(BoolType_.mIndex_);
                second._setBoolType(BoolType_.mIndex_);
                return new __tuple<BoolStruct,
                    BoolStruct>(first, second);
            }
            int count = nIndex * mSize;
            ushort length = (ushort)(count / 64);
            byte secPos = (byte)(count % 64);
            if (secPos > 0)
            {
                secPos -= 1;
            }
            else
            {
                length -= 1;
                secPos = 63;
            }
            if (length >= mValue.Length)
            {
                first._setBoolType(
                    BoolType_.mOverflow_);
                second._setBoolType(
                    BoolType_.mOverflow_);
                return new __tuple<BoolStruct,
                    BoolStruct>(first, second);
            }
            if (mSize < (secPos + 2))
            {
                first._setBoolType(
                    BoolType_.mSucess_);
                byte fstPos =
                    (byte)(secPos + 1);
                fstPos -= mSize;
                first._setFirst(fstPos);
                first._setSecond(secPos);
                first._setLength(length);
            }
            else
            {
                second._setBoolType(
                    BoolType_.mSucess_);
                second._setFirst(0);
                second._setSecond(secPos);
                second._setLength(length);
                first._setBoolType(
                    BoolType_.mSucess_);
                byte fstPos =
                    (byte)(mSize - secPos);
                fstPos = (byte)(65 - fstPos);
                first._setFirst(fstPos);
                first._setSecond(63);
                length -= 1;
                first._setLength(length);
            }
            return new __tuple<BoolStruct,
                BoolStruct>(first, second);
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
