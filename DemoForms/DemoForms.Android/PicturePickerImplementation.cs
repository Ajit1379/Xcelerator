using Android.Content;
using DemoForms.Droid;
using Xamarin.Forms;
using DemoForms.Services;
using System.Threading.Tasks;
using System.IO;

[assembly: Dependency(typeof(PicturePickerImplementation))]
namespace DemoForms.Droid
{
    public class PicturePickerImplementation : IPicturePicker
    {
        public Task<Stream> GetImageStreamAsync()
        {

                Intent intent = new Intent();
                intent.SetType("image/*");
                intent.SetAction(Intent.ActionGetContent);

                // Get the MainActivity instance
                MainActivity activity = Forms.Context as MainActivity;

                activity.StartActivityForResult(
                    Intent.CreateChooser(intent, "Select Picture"),
                    MainActivity.PickImageId);
                activity.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

                return activity.PickImageTaskCompletionSource.Task;
        }
    }
}