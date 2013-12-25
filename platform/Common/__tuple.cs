namespace platform
{
    public class __tuple<__t0>
    {
        public __t0 _get_0()
        {
            return mT0;
        }

        public __tuple(__t0 nT0)
        {
            mT0 = nT0;
        }

        __t0 mT0;
    }

    public class __tuple<__t0, __t1> : __tuple<__t0>
    {
        public __t1 _get_1()
        {
            return mT1;
        }

        public __tuple(__t0 nT0, __t1 nT1)
            : base(nT0)
        {
            mT1 = nT1;
        }

        __t1 mT1;

    }

    public class __tuple<__t0, __t1, __t2> : __tuple<__t0, __t1>
    {
        public __t2 _get_2()
        {
            return mT2;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2)
            : base(nT0, nT1)
        {
            mT2 = nT2;
        }

        __t2 mT2;
    }

    public class __tuple<__t0, __t1, __t2, __t3> : __tuple<__t0, __t1, __t2>
    {
        public __t3 _get_3()
        {
            return mT3;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3)
            : base(nT0, nT1, nT2)
        {
            mT3 = nT3;
        }

        __t3 mT3;
    }

    public class __tuple<__t0, __t1, __t2, __t3, __t4> : __tuple<__t0, __t1, __t2, __t3>
    {
        public __t4 _get_4()
        {
            return mT4;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3, __t4 nT4)
            : base(nT0, nT1, nT2, nT3)
        {
            mT4 = nT4;
        }

        __t4 mT4;
    }

    public class __tuple<__t0, __t1, __t2, __t3, __t4, __t5> : __tuple<__t0, __t1, __t2, __t3, __t4>
    {
        public __t5 _get_5()
        {
            return mT5;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3, __t4 nT4, __t5 nT5)
            : base(nT0, nT1, nT2, nT3, nT4)
        {
            mT5 = nT5;
        }

        __t5 mT5;
    }

    public class __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6> : __tuple<__t0, __t1, __t2, __t3, __t4, __t5>
    {
        public __t6 _get_6()
        {
            return mT6;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3, __t4 nT4, __t5 nT5, __t6 nT6)
            : base(nT0, nT1, nT2, nT3, nT4, nT5)
        {
            mT6 = nT6;
        }

        __t6 mT6;
    }

    public class __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6, __t7> : __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6>
    {
        public __t7 _get_7()
        {
            return mT7;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3, __t4 nT4, __t5 nT5, __t6 nT6, __t7 nT7)
            : base(nT0, nT1, nT2, nT3, nT4, nT5, nT6)
        {
            mT7 = nT7;
        }

        __t7 mT7;
    }

    public class __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6, __t7, __t8> : __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6, __t7>
    {
        public __t8 _get_8()
        {
            return mT8;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3, __t4 nT4, __t5 nT5, __t6 nT6, __t7 nT7, __t8 nT8)
            : base(nT0, nT1, nT2, nT3, nT4, nT5, nT6, nT7)
        {
            mT8 = nT8;
        }

        __t8 mT8;
    }

    public class __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6, __t7, __t8, __t9> : __tuple<__t0, __t1, __t2, __t3, __t4, __t5, __t6, __t7, __t8>
    {
        public __t9 _get_9()
        {
            return mT9;
        }

        public __tuple(__t0 nT0, __t1 nT1, __t2 nT2, __t3 nT3, __t4 nT4, __t5 nT5, __t6 nT6, __t7 nT7, __t8 nT8, __t9 nT9)
            : base(nT0, nT1, nT2, nT3, nT4, nT5, nT6, nT7, nT8)
        {
            mT9 = nT9;
        }
        
        __t9 mT9;
    }
}
