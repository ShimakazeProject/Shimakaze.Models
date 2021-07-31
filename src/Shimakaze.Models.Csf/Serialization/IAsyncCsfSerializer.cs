using System.IO;
using System.Threading.Tasks;

namespace Shimakaze.Models.Csf.Serialization
{
    public interface IAsyncCsfSerializer<T>
    {
        Task<T> DeserializeAsync(Stream stream, byte[] buffer);
        Task SerializeAsync(T t, Stream stream);
    }
}