using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Shimakaze.Models.Ini.Internal;

namespace Shimakaze.Models.Ini
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class IniSection : Dictionary<string, IniValue>
    {
        public string Name { get; set; }
        public IniSection(string name) => Name = name;

        public override bool Equals(object? obj) => obj is IniSection section && Name == section.Name;

        public override int GetHashCode() => HashCode.Combine(Name);

        public override string ToString() => $"[{Name}]:{Count}";

        private string GetDebuggerDisplay() => ToString();


        public static IniSection? TryGetSection(object section) => (section as DynamicIniSection)?.Section;

        public virtual object AsDynamicIni() => new DynamicIniSection(this);
    }
}