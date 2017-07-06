using System.Threading.Tasks;
using DemoForms.Models;
using System.Collections.Generic;

namespace DemoForms.Services
{
    public interface IFirebaseService
    {
        Task<bool> SendData(Form form);

        Task<List<Form>> LoadData();
    }
}

