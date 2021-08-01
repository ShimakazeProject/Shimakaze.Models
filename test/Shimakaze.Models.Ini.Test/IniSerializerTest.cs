using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shimakaze.Models.Ini.Serialization;

namespace Shimakaze.Models.Ini.Test
{
    [TestClass]
    public class IniSerializerTest
    {
        private const string inistring = @"
[Section1]
key1=value1
key2=value2
";

        [TestMethod]
        public void DeserializeTest()
        {
            using StringReader sr = new(inistring);
            var result = IniSerializer.Deserialize(sr);
            dynamic d = result;
            result["Section1"]["key3"] = "value3";
            result["Section1", "key4"] = "value4";

            if (!(result["Section1"]["key1"] == result["Section1", "key1"] == d.Section1.key1 == "value1"))
                throw new Exception("DeserializeTest failed");

            if (!(result["Section1"]["key2"] == result["Section1", "key2"] == d.Section1.key2 == "value2"))
                throw new Exception("DeserializeTest failed");

            if (!(result["Section1"]["key3"] == result["Section1", "key3"] == d.Section1.key3 == "value3"))
                throw new Exception("DeserializeTest failed");

            if (!(result["Section1"]["key4"] == result["Section1", "key4"] == d.Section1.key4 == "value4"))
                throw new Exception("DeserializeTest failed");
        }
        [TestMethod]
        public void SerializeTest()
        {
            IniDocument ini = new();
            ini["Section1", "key1"] = "value1";
            ini["Section1", "key2"] = "value2";

            using StringWriter sw = new();
            IniSerializer.Serialize(ini, sw);
            if (!(sw.ToString().Trim() == inistring.Trim()))
                throw new Exception("SerializeTest failed");
        }
        [TestMethod]
        public async Task DeserializeAsyncTest()
        {
            using StringReader sr = new(inistring);
            var result = await IniSerializer.DeserializeAsync(sr);
            dynamic d = result;
            result["Section1"]["key3"] = "value3";
            result["Section1", "key4"] = "value4";

            if (!(result["Section1"]["key1"] == result["Section1", "key1"] == d.Section1.key1 == "value1"))
                throw new Exception("DeserializeTest failed");

            if (!(result["Section1"]["key2"] == result["Section1", "key2"] == d.Section1.key2 == "value2"))
                throw new Exception("DeserializeTest failed");

            if (!(result["Section1"]["key3"] == result["Section1", "key3"] == d.Section1.key3 == "value3"))
                throw new Exception("DeserializeTest failed");

            if (!(result["Section1"]["key4"] == result["Section1", "key4"] == d.Section1.key4 == "value4"))
                throw new Exception("DeserializeTest failed");
        }
        [TestMethod]
        public async Task SerializeAsyncTest()
        {
            IniDocument ini = new();
            ini["Section1", "key1"] = "value1";
            ini["Section1", "key2"] = "value2";

            using StringWriter sw = new();
            await IniSerializer.SerializeAsync(ini, sw);

            if (!(sw.ToString().Trim() == inistring.Trim()))
                throw new Exception("SerializeTest failed");
        }
    }
}
