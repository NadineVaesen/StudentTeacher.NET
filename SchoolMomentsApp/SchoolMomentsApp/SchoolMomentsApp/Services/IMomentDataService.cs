using SchoolMomentsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public interface IMomentDataService
    {
        Task<IEnumerable<Moment>> GetAllMomentsAsync();

        Task<Moment> GetMomentAsync(int id);
        
    }
}
