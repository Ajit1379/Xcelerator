using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoForms.Views
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage()
        { 
            Master = new MenuPage(this);
            Detail = new NavigationPage(new ListDetailPage());
        }
    }
}
