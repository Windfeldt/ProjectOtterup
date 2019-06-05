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

namespace ProjectOtterup.Fragments
{
    class Select_Course: DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);


            AlertDialog.Builder courseAlert = new AlertDialog.Builder(Activity);
            courseAlert.SetTitle("Navngiv forløb");
            EditText courseName = new EditText(Activity);
            courseAlert.SetView(courseName);

            AlertDialog dialog = courseAlert.Create();

            //View view = inflater.Inflate(Resource.Layout.dialog_select_course, container, false);
            View view = inflater.Inflate(Resource.Layout.dialog_select_course, container, false);


            //dialog.Show();


            return view;


        }
    }
}