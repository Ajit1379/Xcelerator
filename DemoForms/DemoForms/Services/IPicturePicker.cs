using System.Threading.Tasks;
using System.IO;

namespace DemoForms.Services
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
