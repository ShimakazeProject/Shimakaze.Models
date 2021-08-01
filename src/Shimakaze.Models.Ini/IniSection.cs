using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Text;

namespace Shimakaze.Models.Ini
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class IniSection : DynamicObject, IDictionary<string, IniValue>
    {
        public string Name { get; set; }

        public ICollection<string> Keys => Datas.Keys;

        public ICollection<IniValue> Values => Datas.Values;

        public int Count => Datas.Count;

        bool ICollection<KeyValuePair<string, IniValue>>.IsReadOnly => ((ICollection<KeyValuePair<string, IniValue>>)Datas).IsReadOnly;

        public IniValue this[string key]
        {
            get => Datas[key];
            set => Datas[key] = value;
        }

        public IniSection(string name) => Name = name;

        public Dictionary<string, IniValue> Datas = new();

        public override bool Equals(object? obj) => obj is IniSection section && Name == section.Name;

        public override int GetHashCode() => HashCode.Combine(Name);

        public override string ToString() => $"[{Name}]:{Count}";

        private string GetDebuggerDisplay() => ToString();



        public void Add(string key, IniValue value) => ((IDictionary<string, IniValue>)Datas).Add(key, value);

        public bool ContainsKey(string key) => ((IDictionary<string, IniValue>)Datas).ContainsKey(key);

        public bool Remove(string key) => ((IDictionary<string, IniValue>)Datas).Remove(key);

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out IniValue value) => ((IDictionary<string, IniValue>)Datas).TryGetValue(key, out value);

        public void Add(KeyValuePair<string, IniValue> item) => ((ICollection<KeyValuePair<string, IniValue>>)Datas).Add(item);

        public void Clear() => ((ICollection<KeyValuePair<string, IniValue>>)Datas).Clear();

        public bool Contains(KeyValuePair<string, IniValue> item) => ((ICollection<KeyValuePair<string, IniValue>>)Datas).Contains(item);

        void ICollection<KeyValuePair<string, IniValue>>.CopyTo(KeyValuePair<string, IniValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<string, IniValue>>)Datas).CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<string, IniValue> item) => ((ICollection<KeyValuePair<string, IniValue>>)Datas).Remove(item);

        public IEnumerator<KeyValuePair<string, IniValue>> GetEnumerator() => ((IEnumerable<KeyValuePair<string, IniValue>>)Datas).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Datas).GetEnumerator();

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string name = binder.Name;
            var b = TryGetValue(name, out var str);
            result = str;
            return b;
        }

        public override IEnumerable<string> GetDynamicMemberNames() => Datas.Keys;
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (value is IniValue v)
            {
                this[binder.Name] = v;
                return true;
            }
            return false;
        }
    }
}