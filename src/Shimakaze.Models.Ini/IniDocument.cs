using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

using Shimakaze.Models.Ini.Internal;

namespace Shimakaze.Models.Ini
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class IniDocument : IniSection, IDictionary<string, IniSection>
    {
        private Dictionary<string, IniSection> sections { get; init; } = new();
        public IEnumerable<IniSection> Sections => sections.Values;

        public new ICollection<string> Keys => sections.Keys;

        public new ICollection<IniSection> Values => sections.Values;

        bool ICollection<KeyValuePair<string, IniSection>>.IsReadOnly => true;

        public new IniSection this[string section]
        {
            get => sections[section];
            set => sections[section] = value;
        }
        public IniValue this[string section, string key]
        {
            get => sections[section][key];
            set => sections[section][key] = value;
        }

        public IniSection Default => this;

        public IniDocument() : base(nameof(Default))
        {
        }

        public override string ToString() => $"{nameof(IniDocument)}: {Count}";

        public void Add(string key, IniSection value) => sections.Add(key, value);

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out IniSection value) => sections.TryGetValue(key, out value);

        public void Add(KeyValuePair<string, IniSection> item) => ((ICollection<KeyValuePair<string, IniSection>>)sections).Add(item);

        public bool Contains(KeyValuePair<string, IniSection> item) => ((ICollection<KeyValuePair<string, IniSection>>)sections).Contains(item);

        public void CopyTo(KeyValuePair<string, IniSection>[] array, int arrayIndex) => ((ICollection<KeyValuePair<string, IniSection>>)sections).CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<string, IniSection> item) => ((ICollection<KeyValuePair<string, IniSection>>)sections).Remove(item);

        IEnumerator<KeyValuePair<string, IniSection>> IEnumerable<KeyValuePair<string, IniSection>>.GetEnumerator() => ((IEnumerable<KeyValuePair<string, IniSection>>)sections).GetEnumerator();

        public new IEnumerator<IniSection> GetEnumerator() => Values.GetEnumerator();

        private string GetDebuggerDisplay() => ToString();


        public new static IniDocument? TryGetSection(object document) => document is DynamicIniDocument ini
            ? (new() { sections = ini.Document.Values.Select(IniSection.TryGetSection).Select(x => x!).ToDictionary(x => x.Name) })
            : (IniDocument?)null;

        public override object AsDynamicIni() => new DynamicIniDocument(this);
    }
}