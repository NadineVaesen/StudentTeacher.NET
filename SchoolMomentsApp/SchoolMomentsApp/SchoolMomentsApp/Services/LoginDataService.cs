using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SchoolMomentsApp.Services
{
    public class LoginDataService : ILoginDataService
    {
   
       
        public LoginDataService()
        {
            
        }

        public Object AuthenticateUser()
        {
            return new Teacher();
        }
    }
}
