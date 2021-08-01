using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Shimakaze.Models.Ini
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class IniDocument : DynamicObject, IEnumerable<IniSection>
    {
        private readonly Dictionary<string, IniSection> sections = new();

        internal IniDocument(Dictionary<string, IniSection> sections)
        {
            this.sections = sections;
        }
        public IniDocument(IEnumerable<IniSection> sections) : this(sections.ToDictionary(x => x.Name))
        {
        }
        public IniDocument()
        {
        }

        public ICollection<IniSection> Sections => sections.Values;

        public IniSection this[string section]
        {
            get => sections[section];
            set => sections[section] = value;
        }

        public IniValue this[string section, string key]
        {
            get => sections[section][key];
            set
            {
                if (!sections.ContainsKey(section))
                    Add(section)[key] = value;
                else
                    sections[section][key] = value;
            }
        }

        public IniSection Default => new(nameof(Default));

        public int Count => sections.Count;

        public override string ToString() => $"{nameof(IniDocument)}: {Count}";

        public void Add(IniSection section) => sections.Add(section.Name, section);

        public IniSection Add(string section)
        {
            IniSection newSection = new(section);
            Add(newSection);
            return newSection;
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out IniSection value) => sections.TryGetValue(key, out value);

        public bool Remove(string section) => sections.Remove(section);


        public IEnumerator<IniSection> GetEnumerator() => Sections.GetEnumerator();

        private string GetDebuggerDisplay() => ToString();


        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string name = binder.Name;
            var b = TryGetValue(name, out var obj);
            result = obj;
            return b;
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (value is IniSection s1)
            {
                this[binder.Name] = s1;
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Sections).GetEnumerator();
    }
}