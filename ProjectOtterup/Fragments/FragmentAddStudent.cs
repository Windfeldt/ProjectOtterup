using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SharedLibrary;
using SharedLibrary.Services;

namespace ProjectOtterup.Fragments
{
    public class FragmentAddStudent : Android.Support.V4.App.Fragment
    {
        StudentRepository repository = new StudentRepository();
        AzureService azureService = new AzureService();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public static FragmentAddStudent NewInstance()
        {
            var fragAddStudent = new FragmentAddStudent { Arguments = new Bundle() };
            return fragAddStudent;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_addStudent, container, false);

            Button button = view.FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return view; //inflater.Inflate(Resource.Layout.fragment_tests, null);
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            await azureService.AddStudent();
        }
    }
}