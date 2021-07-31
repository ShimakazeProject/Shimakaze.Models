using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shimakaze.Models.Csf.Serialization
{
    public interface ICsfSerializer<T>
    {
        public T Deserialize(byte[] data);
        public byte[] Serialize(T t);
    }
    public interface IAsyncCsfSerializer<T>
    {
        public Task<T> DeserializeAsync(Stream stream, byte[] buffer);
        public Task SerializeAsync(T t, Stream stream);
    }
}