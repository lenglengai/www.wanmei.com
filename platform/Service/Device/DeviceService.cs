using System.Collections.Generic;

namespace platform
{
    public class DeviceService
    {
        public bool _contain(uint nDeviceType)
        {
            return mDeviceTypes.Contains(nDeviceType);
        }

        public void _runInit()
        {
            mDeviceTypes.Add(GenerateId._runComputer());
            mDeviceTypes.Add(GenerateId._runCellphone());
        }

        public DeviceService()
        {
            mDeviceTypes = new SortedSet<uint>();
        }

        SortedSet<uint> mDeviceTypes;
    }
}
