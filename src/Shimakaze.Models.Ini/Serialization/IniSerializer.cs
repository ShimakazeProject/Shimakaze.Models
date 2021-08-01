﻿using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shimakaze.Models.Ini.Serialization
{
    public static class IniSerializer
    {
        public static IniDocument Deserialize(TextReader tr)
        {
            IniDocument document = new();
            IniSection currentSection = document.Default;

            while (tr.Peek() > 0)
            {
                var line = tr.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("["))
                {
                    var section = line.Split('[').Last().Split(']').First();
                    currentSection = document.Add(section);
                }
                else
                {
                    var raw = line.Split('=');
                    currentSection.Add(raw.First().Trim(), raw.Last().Trim());
                }
            }
            return document;
        }
        public static void Serialize(IniDocument ini, TextWriter tw)
        {
            foreach (var line in ini.Default)
                tw.WriteLine(line.Key + "=" + line.Value);

            tw.WriteLine();

            foreach (var section in ini)
            {
                tw.WriteLine($"[{section.Name}]");
                foreach (var line in section)
                    tw.WriteLine(line.Key + "=" + line.Value);

                tw.WriteLine();
            }
        }
        public static async Task<IniDocument> DeserializeAsync(TextReader tr)
        {
            IniDocument document = new();
            IniSection currentSection = document.Default;

            while (tr.Peek() > 0)
            {
                var line = await tr.ReadLineAsync().ConfigureAwait(false);
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("["))
                {
                    var section = line.Split('[').Last().Split(']').First();
                    currentSection = document.Add(section);
                }
                else
                {
                    var raw = line.Split('=');
                    currentSection.Add(raw.First(), raw.Last());
                }
            }
            return document;
        }
        public static async Task SerializeAsync(IniDocument ini, TextWriter tw)
        {
            foreach (var line in ini.Default)
                await tw.WriteLineAsync(line.Key + "=" + line.Value).ConfigureAwait(false);

            await tw.WriteLineAsync().ConfigureAwait(false);

            foreach (var section in ini)
            {
                await tw.WriteLineAsync($"[{section.Name}]").ConfigureAwait(false);
                foreach (var line in section)
                    await tw.WriteLineAsync(line.Key + "=" + line.Value).ConfigureAwait(false);

                await tw.WriteLineAsync().ConfigureAwait(false);
            }
        }
    }
}