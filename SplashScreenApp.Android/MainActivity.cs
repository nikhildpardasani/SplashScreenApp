using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

namespace SplashScreenApp.Droid
{
    [Activity(Label = "Anki+", Theme = "@style/MainTheme", MainLauncher = false)]
    public class MainActivity : FormsAppCompatActivity
    {
        public static MainActivity Intance;

        public static DisplayMetrics displayMetrics;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Window.AddFlags(WindowManagerFlags.Fullscreen);

            base.OnCreate(savedInstanceState);
            Intance = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Start();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            
            displayMetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetRealMetrics(displayMetrics);

            //==================================== Code to hide the bottom 3 buttons on Android.
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            //====================================
            LoadApplication(new App());

            //if (Window != null) Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            if (isPhone(this)) RequestedOrientation = ScreenOrientation.Portrait;

        }

        protected override void OnResume()
        {
            base.OnResume();
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

        public void Start()
        {
        }

        public static bool isPhone(Context context)
        {
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}