namespace platform
{
    public class PropertyId<__t> : IPropertyId where __t : Property, new()
    {
        public Property _createProperty()
        {
            return new __t();
        }

        public static uint _classId()
        {
            string className_ = typeof(__t).FullName;
            return GenerateId._runCommon(className_);
        }

        public uint _getId()
        {
            return _classId();
        }

        public PropertyId()
        {
        }
    }
}
