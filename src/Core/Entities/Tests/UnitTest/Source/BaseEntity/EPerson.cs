namespace DotNetCenter.Core.Entities.UnitTest
{
    using DotNetCenter.Core.Entities;
    using System.Collections.Generic;
    public class EPerson : BaseEntity<EPerson, byte>
    {
        public EPerson(byte id, string name, byte age)
            : base(id)
        {
            _name = name;
            _age = Age;
        }

        public string Name => _name;
        private readonly string _name;
        public byte Age => _age;
        private readonly byte _age;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Age;
        }

        protected override int GetHashCodeCore() 
            => System.HashCode.Combine(Name + Age);
    }
}
