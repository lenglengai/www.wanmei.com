using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class State
    {
        public State(int nNo, int nSize) {
            mMaxNo = nNo * nSize;
            mNo = nNo;
            int length = (int)Math.Log((nNo + 1), 2);
            length *= nSize;
            if ((length % 8) > 0){
                length /= 8;
                length += 1;
            } else {
                length /= 8;
            }
            mValue = new char[length];
        }

        char[] mValue;
        int mMaxNo;
        int mNo;
    }
}
