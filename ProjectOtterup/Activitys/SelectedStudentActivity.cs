using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProjectOtterup.Activitys
{
    [Activity(Label = "SelectedStudentActivity")]
    public class SelectedStudentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.selectedStudent);

            TextView textView = FindViewById<TextView>(Resource.Id.SelectedStudentName);

            int intent = base.Intent.Extras.GetInt("Id");

            textView.Text = intent.ToString();

            // Create your application here
        }
    }
}