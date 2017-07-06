using System.Collections.Generic;
using DemoForms.Droid;
using System.Threading.Tasks;
using DemoForms.Models;
using DemoForms.Services;
using System;
using Firebase.Xamarin.Database;

[assembly: Xamarin.Forms.Dependency(typeof(FirebaseService))]
namespace DemoForms.Droid
{
    public class FirebaseService : IFirebaseService
    {
        private string firebaseurl = "https://xamarinfirebase-74fdd.firebaseio.com/";

        private List<Form> listUser;

        public async Task<bool> SendData(Form form)
        {
            var firebase = new FirebaseClient(firebaseurl);
            try
            {
                var result = await firebase.Child("users").PostAsync<Form>(form);
                if (result.Key != null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public async Task<List<Form>> LoadData()
        {
            var firebase = new FirebaseClient(firebaseurl);
            listUser = new List<Form>();
            try
            {
                var items = await firebase.Child("users").OnceAsync<Form>();
                foreach (var item in items)
                {
                    listUser.Add(item.Object);
                }
                return listUser;
            }
            catch (Exception e)
            {
                return listUser;
            }
        }
    }
}