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

namespace ProjectOtterup.Adapter
{
    class SelectedStudentCourseAdapter : BaseAdapter<StudentCourse>
    {

        private Context myContext;
        private List<StudentCourse> studentCourses;

        public SelectedStudentCourseAdapter(Context context, List<StudentCourse> courses)
        {
            myContext = context;
            studentCourses = courses;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override StudentCourse this[int position]
        {
            get
            {
                return studentCourses[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            
            if (view == null)
            {
                view = LayoutInflater.From(myContext).Inflate(Resource.Layout.selectedStudent_listItem, null, false);
            }

            TextView selectedStudentCourseName = view.FindViewById<TextView>(Resource.Id.studentCourseName);
            selectedStudentCourseName.Text = studentCourses[position].CourseName;

            TextView selectedStudentCourseDate = view.FindViewById<TextView>(Resource.Id.studentCourseStartDate);
            selectedStudentCourseDate.Text = studentCourses[position].CourseCreated.ToString();


            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return studentCourses.Count;
            }
        }

       
    }

    class SelectedStudentCourseAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}