namespace platform
{
    public class __singleton<__t> where __t : new()
    {
        public static __t _instance()
        {
            if (null == mT)
            {
                mT = new __t();
            }
            return mT;
        }
        static __t mT = default(__t);
    }
}
