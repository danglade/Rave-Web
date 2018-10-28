using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Rave.Utils
{
    public static class Layout
    {
        public static DataTable GetParents(DataTable x)
        {
            DataTable menu = x.Select("[parent] = " + "-1" + "").CopyToDataTable();
            return menu;
             
        }

        public static DataTable GetChildrens(DataTable x, string parent)
        {
            try
            {
                DataTable menu = x.Select("[parent] = " + parent + "","sort").CopyToDataTable();
                return menu;
            }
            catch (Exception)
            {
                return new DataTable();
            }

        }
    }
}