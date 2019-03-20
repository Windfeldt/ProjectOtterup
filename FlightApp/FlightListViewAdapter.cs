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

namespace FlightApp
{
    public class FlightListViewAdapter : BaseAdapter<Flight>
    {

        Context myContext;
        List<Flight> allFlights;


        public FlightListViewAdapter(Context context, List<Flight> flights)
        {
            myContext = context;
            allFlights = flights;
        }

        public override Flight this[int position]
        {
            get { return allFlights[position]; }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return allFlights.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(myContext).Inflate(Resource.Layout.flightOverview, null, false);
            }

            TextView flightDes = view.FindViewById<TextView>(Resource.Id.flightDes);
            flightDes.Text = allFlights[position].FlightDestination;

            return view;



        }

    }
}