using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class Duc : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dta = kn.ExecuteQuery("GetLoaiThuCung", new object[] { 1 }, new List<string> { "@bGioiTinh" });
            ListViewLoaiThuCungDuc.DataSource = dta;
            ListViewLoaiThuCungDuc.DataBind();

            string type = Request.QueryString["type"];
            string min = Request.QueryString["min"];
            string max = Request.QueryString["max"];

            
            LayThuCungTheoDieuKien(type, min, max);


        }



        private void LayThuCungTheoDieuKien(string type, string min, string max)
        {
            //nếu như loại giày không được truyền vào
            if (type == null)
            {
                //nếu như giá min được truyền vào
                if (min != null)
                {
                    object[] para = new object[] { 1, min, max };
                    List<string> paraName = new List<string> { "@bGioiTinh", "@min", "@max" };
                    using (DataTable dt = kn.ExecuteQuery("GetThuCung", para, paraName))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            ListViewThuCungDuc.DataSource = dt;
                            ListViewThuCungDuc.DataBind();
                        }
                        else
                        {
                            ThongBao.Style.Remove("display");
                        }
                    }
                }
                //nếu như giá trị min không được truyền vào
                else
                {
                    //nếu như giá trị min không được truyền vào và max được truyền vào thì load lại trang (đây là lỗi truy vấn)
                    if (min == null && max != null)
                    {
                        Response.Redirect("Duc.aspx");
                    }
                    //nếu min và max đều không được truyền vào thì lấy toàn bộ mỹ phẩm có giới tính là nam
                    else
                    {
                        ListViewThuCungDuc.DataSource = kn.ExecuteQuery("GetThuCung", new object[] { 1 }, new List<string> { "@bGioiTinh" });
                        ListViewThuCungDuc.DataBind();
                    }
                }
            }
            //nếu loại giày được truyền vào thì lọc theo loại mỹ phẩm
            else
            {
                using (DataTable dt = kn.ExecuteQuery("GetThuCung", new object[] { 1, type }, new List<string> { "@bGioiTinh", "@iMaLoai" }))
                {
                    if (dt != null)
                    {
                        //thay đổi title cho giống loại mỹ phẩm được chọn
                        Response.Write("<title>" + kn.lay1giatri("Select sTenLoai from tblLoaiThuCung where iMaLoai='" + type + "'") + " - ThuCung.VN</title>");
                        ListViewThuCungDuc.DataSource = dt;
                        ListViewThuCungDuc.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Duc.aspx");
                    }
                }
            }
        }




    }
}