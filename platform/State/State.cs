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

        public State(int nNo, int nSize) {
            mMaxNo = nNo * nSize;
            mNo = nNo;
            int length = (int)Math.Log((nNo + 1), 2);
            length *= nSize;
            mLeft = length % 8;
            if (mLeft > 0) {
                mLeft = 8 - mLeft;
                mLeft = (int)Math.Pow(2, mLeft);
                length /= 8;
                length += 1;
            } else {
                length /= 8;
            }
            mValue = new char[length];
        }

        char[] mValue;
        int mMaxNo;
        int mLeft;
        int mNo;
    }
}
