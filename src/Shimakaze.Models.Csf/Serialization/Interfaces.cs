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
        T Deserialize(byte[] data);
        byte[] Serialize(T t);
    }
    public interface IAsyncCsfSerializer<T>
    {
        Task<T> DeserializeAsync(Stream stream, byte[] buffer);
        Task SerializeAsync(T t, Stream stream);
    }
}