using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi kn = new ketnoi();
            ListViewThuCungDuc.DataSource = kn.laybang("Select top 10 * from tblThuCung where bGioiTinh = 1 order by iID desc");
            ListViewThuCungDuc.DataBind();

            ListViewThuCungCai.DataSource = kn.laybang("Select top 10 * from tblThuCung where bGioiTinh = 0 order by iID desc");
            ListViewThuCungCai.DataBind();
        }


    }
}