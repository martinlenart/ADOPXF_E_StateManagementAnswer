using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using Hello_World_Flyout.Services;
//using Hello_World_Flyout.Models;
using Hello_World_Flyout.Consoles;

namespace Hello_World_Flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsolePage : ContentPage
    {
        public ConsolePage()
        {
            InitializeComponent();
            myOutput.Text = "";
        }
        public void WriteLine()
        {
            WriteLine("");
        }
        public void WriteLine(string str)
        {
            myOutput.Text += str + "\n";
        }
        public void Write(string str)
        {
            myOutput.Text += str;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            myOutput.Text = "";
            WriteLine("---Start Console program---\n");

            var p = new Program(this);
            await p.myMain();

            WriteLine("\n---End Console program---");
        }
    }
}