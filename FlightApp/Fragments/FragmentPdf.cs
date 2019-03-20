using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Views;
using FlightApp.Fragments;
using System.Collections.Generic;
using SharedLibrary;
using System;

namespace FlightApp.Fragments
{
    public class FragmentPdf : Android.Support.V4.App.Fragment
    {


        public delegate EventHandler<MyEventArgs> MyEventHandler(object sender, MyEventArgs args);

        public class MyEventArgs: EventArgs
        {
            public int Id { get; set; }
        };



        FlightRepository flightRepo = new FlightRepository();
        public event EventHandler OnListViewClick;
        private List<Flight> _listFlights;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public static FragmentPdf NewInstance()
        {
            var fragPdf = new FragmentPdf { Arguments = new Bundle()};
            return fragPdf;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {


            View view = inflater.Inflate(Resource.Layout.ListViewPdf, container, false);
            ListView _listView = view.FindViewById<ListView>(Resource.Id.myListView);


            _listFlights = flightRepo.GetFlights();

            FlightListViewAdapter adapter = new FlightListViewAdapter(Context, _listFlights);

            _listView.Adapter = adapter;

            _listView.ItemClick += _listView_ItemClick;

            return view;
        }

        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (OnListViewClick != null)
            {
                OnListViewClick(this, new MyEventArgs { Id = _listFlights[e.Position].FlightId });
            }
        }
    }
}