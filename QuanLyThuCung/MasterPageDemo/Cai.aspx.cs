using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class Cai : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dta = kn.ExecuteQuery("GetLoaiThuCung", new object[] { 0 }, new List<string> { "@bGioiTinh" });
            ListViewLoaiThuCungCai.DataSource = dta;
            ListViewLoaiThuCungCai.DataBind();

            string type = Request.QueryString["type"];
            string min = Request.QueryString["min"];
            string max = Request.QueryString["max"];


            LayThuCungTheoDieuKien(type, min, max);
        }

        private void LayThuCungTheoDieuKien(string type, string min, string max)
        {
            if (type == null)
            {
                if (min != null)
                {
                    object[] para = new object[] { 0, min, max };
                    List<string> paraName = new List<string> { "@bGioiTinh", "@min", "@max" };
                    using (DataTable dt = kn.ExecuteQuery("GetThuCung", para, paraName))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            ListViewThuCungCai.DataSource = dt;
                            ListViewThuCungCai.DataBind();
                        }
                        else
                        {
                            ThongBao.Style.Remove("display");
                        }
                    }
                }
                else if (min == null && max != null)
                {
                    Response.Redirect("Cai.aspx");
                }
                else
                {
                    ListViewThuCungCai.DataSource = kn.ExecuteQuery("GetThuCung", new object[] { 0 }, new List<string> { "@bGioiTinh" });
                    ListViewThuCungCai.DataBind();
                }
            }
            else
            {
                using (DataTable dt = kn.ExecuteQuery("GetThuCung", new object[] { 0, type }, new List<string> { "@bGioiTinh", "@iMaLoai" }))
                {
                    if (dt != null)
                    {
                        Response.Write("<title>" + kn.lay1giatri("Select sTenLoaiThuCung from tblLoaiThuCung where iMaLoai='" + type + "'") + " - ThuCung.VN</title>");
                        ListViewThuCungCai.DataSource = dt;
                        ListViewThuCungCai.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Cai.aspx");
                    }
                }
            }
        }


    }
}