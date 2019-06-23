using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Views;
using ProjectOtterup.Fragments;
using System;
using Android.Content;

namespace ProjectOtterup
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.MyTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FragmentStudent frag = new FragmentStudent();
            base.OnCreate(savedInstanceState);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            SetContentView(Resource.Layout.activity_main);
            LoadFragment(4);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            }

            

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
                    case Resource.Id.menu_student:
                        fragment = FragmentStudent.NewInstance();
                        break;
                    case Resource.Id.menu_newStudent:
                        fragment = FragmentAddStudent.NewInstance();
                        break;
                    case Resource.Id.menu_tests:
                        fragment = FragmentAddTest.NewInstance();
                        break;
                    case 4:
                        fragment = FragmentStudent.NewInstance();
                        break;
                }
                if (fragment == null) return;

                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
            }
        }
    }
}