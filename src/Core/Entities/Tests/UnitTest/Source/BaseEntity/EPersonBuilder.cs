namespace DotNetCenter.Core.Entities.UnitTest
{
    public class EPersonBuilder
    {
        public EPerson GetPerson(byte id, string name, byte age)
            => new EPerson(id, name, age);
    }
}
