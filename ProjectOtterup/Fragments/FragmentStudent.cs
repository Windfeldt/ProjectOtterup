using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using ProjectOtterup.Activitys;
using SharedLibrary;

namespace ProjectOtterup.Fragments
{
    public class FragmentStudent : Android.Support.V4.App.Fragment 
    {
        public delegate EventHandler<MyEventArgs> MyEventHandler(object sender, MyEventArgs args);

        public class MyEventArgs : EventArgs
        {
            public int Id { get; set; }
        };



        StudentRepository StudentRepo = new StudentRepository();
        public event EventHandler OnListViewClick;
        private List<Student> _listStudents;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public static FragmentStudent NewInstance()
        {
            var fragStudent = new FragmentStudent { Arguments = new Bundle() };
            return fragStudent;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {


            View view = inflater.Inflate(Resource.Layout.ListViewStudent, container, false);
            ListView _listView = view.FindViewById<ListView>(Resource.Id.myStudentListView);


            _listStudents = StudentRepo.GetStudents();
            //_listStudents = StudentRepo.GetStudents().Result;

            StudentListViewAdapter adapter = new StudentListViewAdapter(Context, _listStudents);

            _listView.Adapter = adapter;

            _listView.ItemClick += _listView_ItemClick;

            return view;
        }

        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //if (OnListViewClick != null)
            //{
            //    OnListViewClick(this, new MyEventArgs { Id = _listStudents[e.Position].StudentId });
            //}

            Intent intent = new Intent(Context, typeof(SelectedStudentActivity));
            
            intent.PutExtra("Id", _listStudents[e.Position].StudentId);
            StartActivity(intent);

        }
    }
}