using System.Collections.Generic;
using System.Dynamic;

namespace Shimakaze.Models.Ini.Internal
{
    internal class DynamicIniDocument : DynamicObject
    {
        internal Dictionary<string, DynamicIniSection> Document { get; } = new();
        internal DynamicIniDocument(IniDocument document)
        {
            foreach (var section in document.Sections)
                Document.Add(section.Name, new(section));
        }

        public int Count => Document.Count;

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string name = binder.Name;
            var b = Document.TryGetValue(name, out var obj);
            result = obj;
            return b;
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (value is DynamicIniSection s)
            {
                Document[binder.Name] = s;
                return true;
            }
            else if (value is IniSection s1)
            {
                Document[binder.Name] = new(s1);
                return true;
            }
            return false;
        }
    }
}