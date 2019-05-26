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

namespace ProjectOtterup.Activitys
{
    [Activity(Label = "SelectedStudentActivity")]
    public class SelectedStudentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.selectedStudent);


            StudentRepository studentRepository = new StudentRepository();


            TextView textViewId = FindViewById<TextView>(Resource.Id.SelectedStudentId);

            TextView textViewFirstFirstname = FindViewById<TextView>(Resource.Id.SelectedStudentFirstname);

            TextView textViewFirstLastname = FindViewById<TextView>(Resource.Id.SelectedStudentLastname);

            int studentId = base.Intent.Extras.GetInt("Id");

            Student selectedStudent = studentRepository.GetStudent(studentId.ToString());


            textViewId.Text = selectedStudent.Id;

            textViewFirstFirstname.Text = selectedStudent.StudentFirstName;

            textViewFirstLastname.Text = selectedStudent.StudentLastName;
            //textView.Text = studentId.ToString();





            // Create your application here
        }
    }
}