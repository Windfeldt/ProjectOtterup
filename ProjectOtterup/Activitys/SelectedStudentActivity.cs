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
using ProjectOtterup.Fragments;
using SharedLibrary;

namespace ProjectOtterup.Activitys
{
    [Activity(Label = "SelectedStudentActivity")]
    public class SelectedStudentActivity : Activity
    {
        private Student student = new Student();

        TextView textViewFirstFirstname;
        TextView textViewSchoolClass;
        Button btnCreateCourse;
        ListView courses;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.selectedStudent);


            StudentRepository studentRepository = new StudentRepository();

            textViewFirstFirstname = FindViewById<TextView>(Resource.Id.SelectedStudentName);
            textViewSchoolClass = FindViewById<TextView>(Resource.Id.SelectedSchoolclass);

            int studentId = base.Intent.Extras.GetInt("Id");
            Student selectedStudent = studentRepository.GetStudent(studentId.ToString());

            textViewFirstFirstname.Text = selectedStudent.StudentFirstName + " " + selectedStudent.StudentLastName;
            textViewSchoolClass.Text = selectedStudent.SchoolClass;

            student.Courses = new List<StudentCourse>();

            btnCreateCourse = FindViewById<Button>(Resource.Id.btnCreateCourse);

            btnCreateCourse.Click += BtnCreateCourse_Click;



        }

        /// <summary>
        /// Create a new test course for the selected student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateCourse_Click(object sender, EventArgs e)
        {

            //FragmentTransaction transaction = FragmentManager.BeginTransaction();

            //Select_Course select_Course = new Select_Course();

            //select_Course.Show(transaction, "dialog fragment");


            AlertDialog.Builder courceAlertDialog = new AlertDialog.Builder(this);
            courceAlertDialog.SetTitle("Navngiv forløb");

            EditText courseName = new EditText(this);
            courceAlertDialog.SetView(courseName);


            courceAlertDialog.SetPositiveButton("Gem", (senderAlert, args) => 
            {
                AddCourse(courseName.Text);
            }).SetNegativeButton("Anuller", (senderAlert, args)=> 
            {
                courceAlertDialog.Dispose();
            });
            AlertDialog alertDialog = courceAlertDialog.Create();
            alertDialog.Show();
        }

        private void AddCourse(string courseName)
        {
            courses = FindViewById<ListView>(Resource.Id.courseListView);
            SelectedStudentCourseAdapter courseAdapter = new SelectedStudentCourseAdapter(this, student.Courses);

            courses.Adapter = courseAdapter;

            StudentCourse studentCourse = new StudentCourse()
            {
                CourseName = courseName
            };
            student.Courses.Add(studentCourse);
            courseAdapter.NotifyDataSetChanged();

            courses.ItemClick += Courses_ItemClick;
        }

        private void Courses_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var selectedCourse = student.Courses.Where(s => s.Id == student.Courses[e.Position].Id).FirstOrDefault();
            Intent intent = new Intent(this, typeof(SelectedStudentCourseActivity));
            intent.PutExtra("courseName", selectedCourse.CourseName);
            StartActivity(intent);
        }
    }
}