using System;
using System.Collections.Generic;
using System.Text;

using Hello_World_Flyout.Models;
namespace Hello_World_Flyout
{
    public class Globals
    {
        #region Lazy implementation
        Globals() { } // just to avoid any direct instantiations

        private static Lazy<Globals> _instance = new Lazy<Globals>(() => new Globals());
        public static Globals Data => _instance.Value;
        #endregion

        #region Data implementation 
        // accessible as Globals.Data.xx 
        public List<City> Citylist { get; set; }
        public string Message { get; set;}
        public DateTime Time { get; set;}
        #endregion
    }
}
