using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Views;
using FlightApp.Fragments;
using System;
using Android.Content;

namespace FlightApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true, Icon ="@drawable/iconScreen")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FragmentPdf frag = new FragmentPdf();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            }

            frag.OnListViewClick += (s, e) =>
            {
                Intent intent = new Intent(this, typeof(Activity1));
                StartActivity(intent);
            };

            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
            {
                LoadFragment(e.Item.ItemId);
            }
            void LoadFragment(int id)

            {
                Android.Support.V4.App.Fragment fragment = null;
                switch (id)
                {
                    case Resource.Id.menu_pdf:
                        fragment = FragmentPdf.NewInstance();
                        break;
                    case Resource.Id.menu_chili:
                        fragment = FragmentChili.NewInstance();
                        break;
                    case Resource.Id.menu_western:
                        fragment = FragmentWestern.NewInstance();
                        break;
                }
                if (fragment == null) return;

                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
            }
        }

        
    }
}