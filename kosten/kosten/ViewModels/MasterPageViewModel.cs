using System;
using System.Threading.Tasks;
using kosten.Models;

namespace kosten.ViewModels
{
    public class MasterPageViewModel : BaseViewModel
    {
        Boolean _isAllowed;
        public Boolean IsAllowed
        {
            get { return _isAllowed; }
            set { SetValue(ref _isAllowed, value); }
        }
  
        public MasterPageViewModel()
        {
            _isAllowed = Settings.CurrentUserRole.Equals("ADMIN");
        }

        public async Task<User> GetUserById()
        {
            return await App.UserService.GETId((string)Settings.UserId);
        }
    }
}
