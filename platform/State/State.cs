using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class State
    {
        public int _getIndex(out int nNo, int nIndex) {

        }

        public bool _setIndex(int nNo, int nIndex) {

        }

        public bool _setLeft(int nLeft) {
            if (nLeft > mLeft) return false;

        }

        public State(int nNo, int nCount) {
            mSize = (int)Math.Log((nNo + 1), 2);
            mNo = nNo;
            mCount = mSize * nCount;
            mLength = mCount / 8;
            if ( (mCount % 8) > 0 ) {
                mLength += 1;
            }
            mValue = new char[mLength];
        }

        char[] mValue;
        int mLength;
        int mCount;
        int mSize;
        int mNo;
    }
}
