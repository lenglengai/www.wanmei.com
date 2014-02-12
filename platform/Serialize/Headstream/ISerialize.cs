using System;
using System.Collections.Generic;

namespace platform
{
    public interface ISerialize
    {
        //__bool
        void _serialize(ref bool nValue, string nName, bool nOptimal = default(bool));
        //__i8
        void _serialize(ref sbyte nValue, string nName, sbyte nOptimal = default(sbyte));
        void _serialize(ref List<sbyte> nValue, string nName);
        //__u8
        void _serialize(ref byte nValue, string nName, byte nOptimal = default(byte));
        void _serialize(ref List<byte> nValue, string nName);
        //__i16
        void _serialize(ref short nValue, string nName, short nOptimal = default(short));
        void _serialize(ref List<short> nValue, string nName);
        //__u16
        void _serialize(ref ushort nValue, string nName, ushort nOptimal = default(ushort));
        void _serialize(ref List<ushort> nValue, string nName);
        //__i32
        void _serialize(ref int nValue, string nName, int nOptimal = default(int));
        void _serialize(ref List<int> nValue, string nName);
        //__u32
        void _serialize(ref uint nValue, string nName, uint nOptimal = default(uint));
        void _serialize(ref List<uint> nValue, string nName);
        //__i64
        void _serialize(ref long nValue, string nName, long nOptimal = default(long));
        void _serialize(ref List<long> nValue, string nName);
        //__u64
        void _serialize(ref ulong nValue, string nName, ulong nOptimal = default(ulong));
        void _serialize(ref List<ulong> nValue, string nName);
        //__str
        void _serialize(ref string nValue, string nName, string nOptimal = default(string));
        void _serialize(ref List<string> nValue, string nName);
        //datetime
        void _serialize(ref DateTime nValue, string nName, DateTime nOptimal = default(DateTime));
        void _serialize(ref List<DateTime> nValue, string nName);
        //__float
        void _serialize(ref float nValue, string nName, float nOptimal = default(float));
        void _serialize(ref List<float> nValue, string nName);
        //__double
        void _serialize(ref double nValue, string nName, double nOptimal = default(double));
        void _serialize(ref List<double> nValue, string nName);
        //__t
        void _serialize<__t>(ref __t nValue, string nName, __t nOptimal = default(__t)) where __t : IStream;
        void _serialize<__t>(ref List<__t> nValue, string nName) where __t : IStream;
        //ISerialize
        void _openUrl(string nUrl);
        void _selectStream(string nStreamName);
        void _runClose();
    }
}
