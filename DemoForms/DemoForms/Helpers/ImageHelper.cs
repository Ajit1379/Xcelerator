using System.IO;

namespace DemoForms.Helpers
{
    public class ImageHelper
    {
        public static byte[] StreamToByte(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static Stream ByteToStream(byte[] buffer)
        {
            return new MemoryStream(buffer);
        }
    }
}
