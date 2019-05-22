using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace SharedLibrary.Services
{
    public class AzureService
    {
        MobileServiceClient client = null;

        IMobileServiceSyncTable<Student> studentTable;

        public async Task Initialize()
        {
            try
            {
                if (client?.SyncContext?.IsInitialized ?? false)
                {
                    return;
                }

                var appUrl = "https://projectotterupsupportservice.azurewebsites.net";
                client = new MobileServiceClient(appUrl);

                var fileName = "ProjectOtterupDb.db";

                var store = new MobileServiceSQLiteStore(fileName);

                store.DefineTable<Student>();

                await client.SyncContext.InitializeAsync(store);

                studentTable = client.GetSyncTable<Student>();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
        }

        public async Task SyncStudent()
        {
            await Initialize();
            try
            {
                //We are offline, skip
                if (!CrossConnectivity.Current.IsConnected)
                {
                    return;
                }
                //We are online
                await client.SyncContext.PushAsync();
                await studentTable.PullAsync("allStudents", studentTable.CreateQuery());
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            await Initialize();
            await SyncStudent();

            //return await studentTable.OrderBy(s => s.ClassLevel).ToEnumerableAsync();
            var data = await studentTable.OrderBy(s => s.ClassLevel).ToEnumerableAsync();


            return data;
        }
        public async Task<Student> AddStudent()
        {
            await Initialize();

            var student = new Student
            {
                StudentId = 5,
                //StudentId = "5",
                StudentFirstName = "Daniel",
                SchoolClass = "5.B",
                ClassLevel = 5
            };
            await studentTable.InsertAsync(student);
            await SyncStudent();
            return student;
        }
    }
}
