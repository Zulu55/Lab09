using Android.App;
using Android.Widget;
using Android.OS;
using SALLab09;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView UserNameTextView2;
        TextView StatusTextView2;
        TextView TokenTextView2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            UserNameTextView2 = FindViewById<TextView>(Resource.Id.UserNameTextView2);
            StatusTextView2 = FindViewById<TextView>(Resource.Id.StatusTextView2);
            TokenTextView2 = FindViewById<TextView>(Resource.Id.TokenTextView2);

            Validate();
        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            var studentEmail = "jzuluaga55@gmail.com";
            var password = "XXX";
            var myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);

            UserNameTextView2.Text = result.Fullname;
            StatusTextView2.Text = result.Status.ToString();
            TokenTextView2.Text = result.Token;
        }
    }
}