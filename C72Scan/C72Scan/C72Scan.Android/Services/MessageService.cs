using Android.App;
using Android.Widget;
using C72Scan.Droid.Services;
using C72Scan.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MessageService))]
namespace C72Scan.Droid.Services
{
    public class MessageService : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
