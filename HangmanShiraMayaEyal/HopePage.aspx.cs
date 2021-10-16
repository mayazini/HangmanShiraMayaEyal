using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HangmanShiraMayaEyal
{
    public partial class HopePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from category";
            DataTable dt = SQLHelper.SelectData(sql);
            Rept.DataSource = dt;
            Rept.DataBind();
        }
    }
}