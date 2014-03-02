using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Models;

namespace Registration.Modules
{
    /// <summary>
    /// Responsible for handling all public requests 
    /// Methods are seperated from any pipeline declaration for testability.
    /// </summary>
    public interface IAccountModule
    {

        void RegisterAccount(AccountViewModel model);
        void Login(AccountViewModel model);
        void Logout();
    }
}
