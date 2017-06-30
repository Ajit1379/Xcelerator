using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoForms.Models;
using DemoForms.Views;

namespace DemoForms.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        private List<MenuItem> menuList;
        private MenuItem selectedItem;

        public List<MenuItem> MenuList
        {
            get { return menuList; }
            set { SetProperty(ref menuList, value); }
        }

        public MenuItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        public MenuPageViewModel()
        {
            menuList = GetMenuList();
        }

        private List<MenuItem> GetMenuList()
        {
            return new List<MenuItem>
                       {
                           new MenuItem { Title = "List Page", Icon = "", TargetType = typeof(ListDetailPage) },
                           new MenuItem { Title = "Form Page", Icon = "", TargetType = typeof(FormDetailPage) }
                       };
        }
    }
}
