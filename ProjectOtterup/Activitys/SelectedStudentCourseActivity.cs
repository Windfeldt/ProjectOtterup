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
using ProjectOtterup.Adapter;
using SharedLibrary;

namespace ProjectOtterup.Activitys
{
    [Activity(Label = "SelectedStudentCourseActivity")]
    public class SelectedStudentCourseActivity : Activity
    {
        private StudentCourse studentCourse = new StudentCourse();
        private TextView courseName;
        private ListView iLTestList;
        private ListView nonOrdTestList;
        private ListView gradeTestList;
        private Button btnAddTest;
        private Button btnDyslexia;
        private Button btnIL;
        private Button btnGrade;
        private Button btnNonOrd;
        private ILTestAdapter iLTestAdapter;
        private GradeTestAdapter gradeTestAdapter;
        private NonOrdAdapter nonOrdAdapter;
        private Context context;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.selectedCourse);


            courseName = FindViewById<TextView>(Resource.Id.selectedCourseName);

            var intentcourseName = base.Intent.Extras.GetString("courseName");
            courseName.Text = intentcourseName;

            iLTestList = FindViewById<ListView>(Resource.Id.listViewIL);
            nonOrdTestList = FindViewById<ListView>(Resource.Id.listViewNonOrd);
            gradeTestList = FindViewById<ListView>(Resource.Id.listViewGrade);


            studentCourse.ILTests = new List<ILTest>();
            studentCourse.NonordTests = new List<NonOrdTest>();
            studentCourse.GradeTests = new List<GradeTest>();

            iLTestAdapter = new ILTestAdapter(context, studentCourse.ILTests);
            iLTestList.Adapter = iLTestAdapter;

            nonOrdAdapter = new NonOrdAdapter(context, studentCourse.NonordTests);
            nonOrdTestList.Adapter = nonOrdAdapter;

            gradeTestAdapter = new GradeTestAdapter(context, studentCourse.GradeTests);
            gradeTestList.Adapter = gradeTestAdapter;

            btnAddTest = FindViewById<Button>(Resource.Id.btnAddTests);
            btnAddTest.Click += BtnAddTest_Click;
            //btnDyslexia = FindViewById<Button>(Resource.Id.btnDyslexia);
            //btnDyslexia.Click += BtnDyslexia_Click;
            //btnGrade = FindViewById<Button>(Resource.Id.btnGrade);
            //btnGrade.Click += BtnGrade_Click;
            //btnIL = FindViewById<Button>(Resource.Id.btnIL);
            //btnIL.Click += BtnIL_Click;
            //btnNonOrd = FindViewById<Button>(Resource.Id.btnNonOrd);
            //btnNonOrd.Click += BtnNonOrd_Click;


            // Create your application here
        }

        private void BtnNonOrd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnIL_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnGrade_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDyslexia_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnAddTest_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Vælge prøve");
            Spinner spinner = new Spinner(this);
            builder.SetView(spinner);

            ArrayAdapter arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, StringArray());
            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = arrayAdapter;


            string[] StringArray()
            {
                string[] ArrayOfTests = { "Nonordprøve", "Karakterprøve", "Ordblindeprøve", "Læseprøve" };
                return ArrayOfTests;
            }

            builder.SetPositiveButton("Gem", (senderAlert, args) =>
            {

            });

            AlertDialog alertDialog = builder.Create();
            alertDialog.Show();
        }
    }
}