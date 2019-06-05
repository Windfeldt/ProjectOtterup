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
    class NonOrdAdapter : BaseAdapter<NonOrdTest>
    {

        Context context;
        List<NonOrdTest> nonOrdTests;



        public NonOrdAdapter(Context context, List<NonOrdTest> nonOrdTests)
        {
            this.context = context;
            this.nonOrdTests = nonOrdTests;
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
                view = LayoutInflater.From(context).Inflate(Resource.Layout.selectedCourse_nonOrdTest,  null,   false);
            }

            TextView testName = view.FindViewById<TextView>(Resource.Id.selectedCourse_NonOrdTestName);
            testName.Text = nonOrdTests[position].TestName;

            TextView assignmentNumber = view.FindViewById<TextView>(Resource.Id.selectedCourse_AssignmentNumber);
            assignmentNumber.Text = nonOrdTests[position].AssignmentAmount.ToString();

            TextView correctAssignment = view.FindViewById<TextView>(Resource.Id.selectedCourse_CorrectNumber);
            correctAssignment.Text = nonOrdTests[position].FinishedAssignments.ToString();

            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return nonOrdTests.Count;
            }
        }

        public override NonOrdTest this[int position] => throw new NotImplementedException();
    }

    class NonOrdAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}