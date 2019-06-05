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
    class ILTestAdapter : BaseAdapter<ILTest>
    {

        Context context;
        List<ILTest> iLTests;

        public ILTestAdapter(Context context, List<ILTest> iLTests)
        {
            this.context = context;
            this.iLTests = iLTests;
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
                view = LayoutInflater.From(context).Inflate(Resource.Layout.selectedCourse_ILTest, null, false);
            }

            TextView testName = view.FindViewById<TextView>(Resource.Id.selectedCourse_ILTestName);
            testName.Text = iLTests[position].TestName;

            TextView lixNumber = view.FindViewById<TextView>(Resource.Id.selectedCourse_LIXNumber);
            lixNumber.Text = iLTests[position].LIX.ToString();

            TextView outLoudReadingResult = view.FindViewById<TextView>(Resource.Id.selectedCourse_OutLoudReadingResult);
            outLoudReadingResult.Text = iLTests[position].OutLoudWordsPerMinute.ToString();

            TextView silentReadingResult = view.FindViewById<TextView>(Resource.Id.selectedCourse_SilentReadingResult);
            silentReadingResult.Text = iLTests[position].SilentReadingWordsPerMinute.ToString();

            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return iLTests.Count;
            }
        }

        public override ILTest this[int position] => throw new NotImplementedException();
    }

    class ILTestAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}