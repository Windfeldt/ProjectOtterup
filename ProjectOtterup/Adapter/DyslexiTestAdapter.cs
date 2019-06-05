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
    public class DyslexiTestAdapter : BaseAdapter<DyslexiaTest>
    {

        private Context context;
        private List<DyslexiaTest> dyslexiaTests;

        public DyslexiTestAdapter(Context context, List<DyslexiaTest>dyslexiaTests)
        {
            this.context = context;
            this.dyslexiaTests = dyslexiaTests;
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
                //view = LayoutInflater.From(context).Inflate(Resource.Layout.selectedCourse_dyslexia, null, false);
            }


            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        
        public override int Count
        {
            get
            {
                return dyslexiaTests.Count;
            }
        }

        public override DyslexiaTest this[int position] => throw new NotImplementedException();
    }

    class DyslexiTestAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}