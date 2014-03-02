namespace _01.School
{
    // Abstract class that is inherited by all none human objects
    public abstract class SchoolNoneHumanObject : SchoolObject
    {
        public SchoolNoneHumanObject(string name, string comments)
            : base(name, comments)
        {
        }
    }
}