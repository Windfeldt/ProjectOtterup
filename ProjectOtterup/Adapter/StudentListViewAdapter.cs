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
using SharedLibrary;

namespace ProjectOtterup
{
    public class StudentListViewAdapter : BaseAdapter<Student>
    {

        Context myContext;
        List<Student> allStudents;


        public StudentListViewAdapter(Context context, List<Student> strudent)
        {
            myContext = context;
            allStudents = strudent;
        }

        public override Student this[int position]
        {
            get { return allStudents[position]; }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return allStudents.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(myContext).Inflate(Resource.Layout.StudentRow, null, false);
            }

            TextView studentFirstName = view.FindViewById<TextView>(Resource.Id.studentFirstName);
            studentFirstName.Text = allStudents[position].StudentFirstName;

            TextView studentLastName = view.FindViewById<TextView>(Resource.Id.studentLastName);
            studentLastName.Text = allStudents[position].StudentLastName;

            TextView studentClassLevel = view.FindViewById<TextView>(Resource.Id.studentClassLevel);
            studentClassLevel.Text = allStudents[position].SchoolClass;

            return view;



        }
    }
}