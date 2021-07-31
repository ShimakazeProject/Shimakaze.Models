using System;
using System.Dynamic;

namespace Shimakaze.Models.Ini.Internal
{

    internal class DynamicIniSection : DynamicObject
    {
        internal IniSection Section { get; }
        internal DynamicIniSection(IniSection section) => Section = section;

        public int Count => Section.Count;

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string name = binder.Name;
            var b = Section.TryGetValue(name, out var str);
            result = str;
            return b;
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (value is IniValue v)
            {
                Section[binder.Name] = v;
                return true;
            }
            return false;
        }
    }
}