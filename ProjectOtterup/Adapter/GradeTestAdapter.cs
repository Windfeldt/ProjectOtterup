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
    class GradeTestAdapter : BaseAdapter<GradeTest>
    {

        Context context;
        List<GradeTest> gradeTests;

        public GradeTestAdapter(Context context, List<GradeTest> gradeTests)
        {
            this.context = context;
            this.gradeTests = gradeTests;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
       
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.selectedCourse_gradeTest, null, false);
            }

            TextView gradeName = view.FindViewById<TextView>(Resource.Id.selectedCourse_GradeTestName);
            gradeName.Text = gradeTests[position].TestName;

            TextView gradeResult = view.FindViewById<TextView>(Resource.Id.selectedCourse_GradeTestResult);
            gradeResult.Text = gradeTests[position].Grade.ToString();


            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return gradeTests.Count;
            }
        }

        public override GradeTest this[int position] => throw new NotImplementedException();
    }

    class GradeTestAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}