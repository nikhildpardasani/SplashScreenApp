using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;

namespace SplashScreenApp.Droid
{
    [Activity(Label = "Anki+", Theme = "@style/LaunchTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);

            //==================================== Code to hide the bottom 3 buttons on Android.
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            //===================================

            base.SetTheme(Resource.Style.MainTheme);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            //==================================== Code to hide the bottom 3 buttons on Android.
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            //===================================

            System.Threading.Tasks.Task startupWork = new System.Threading.Tasks.Task(() => { SimulateStartup(); });
            startupWork.Start();
        }


        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            await System.Threading.Tasks.Task.Delay(1000); // Simulate a bit of startup work.
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed() { }
    }
}
