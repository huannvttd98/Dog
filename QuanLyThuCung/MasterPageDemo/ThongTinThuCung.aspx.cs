using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class ThongTinThuCung : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("Trangchu.aspx");
                }
                else
                {
                    string idThuCung = Request.QueryString["ID"];
                    DataTable dt = new DataTable();
                    dt = kn.ExecuteQuery("XemTTThuCung", new object[] { idThuCung }, new List<string> { "@id" });
                    if (dt == null)
                    {
                        Response.Write("lỗi đường truyền");
                    }
                    else
                    {

                        Response.Write("<title>" + dt.Rows[0]["sTenThuCung"].ToString() + " - THUCUNG.VN </title>");
                        imgMyPham.ImageUrl = "img/SanPham/" + dt.Rows[0]["sLinkImg"].ToString();
                        lblTenThuCung.Text = "Thú Cưng: " + dt.Rows[0]["sTenThuCung"].ToString();
                        lblGia.Text = "Giá: " + string.Format("{0:n0}",float.Parse(dt.Rows[0]["fGia"].ToString())) + "₫";
                        lblCuaHang.Text = "Cửa hàng: " + dt.Rows[0]["sTenCuaHang"].ToString();
                        lblMoTa.Text = "Mô tả: " + dt.Rows[0]["sMoTa"].ToString();
                        lblGiongLoai.Text = "Giống loài: " + dt.Rows[0]["sTenLoai"].ToString();

                        //Lấy size từ db 
                        dt.Clear();
                        dt = kn.laybang("Select * from tblThuCung_ChiTiet where iID ='" + idThuCung + "'");
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            DropDownListSize.DataSource = dt;
                            DropDownListSize.DataTextField = "iTuoi";
                            DropDownListSize.DataValueField = "iSTT";
                            DropDownListSize.DataBind();

                            //ràng buộc dữ liệu
                            CheckSoLuong.Type = ValidationDataType.Integer;
                            CheckSoLuong.MinimumValue = "0";
                            CheckSoLuong.MaximumValue = dt.Rows[0][3].ToString();
                            if (int.Parse(dt.Rows[0][3].ToString()) == 0)
                            {
                                lblSoLuong.Text = "Hết hàng";
                            }
                            else { lblSoLuong.Text = dt.Rows[0][3].ToString(); }
                        }
                        else
                        {
                            //ràng buộc dữ liệu
                            CheckSoLuong.Type = ValidationDataType.Integer;
                            CheckSoLuong.MinimumValue = "0";
                            CheckSoLuong.MaximumValue = "0";
                            lblSoLuong.Text = "Hết hàng";
                        }
                    }
                }
            }
        }

        protected void DropDownListSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = kn.laybang("Select * from tblThuCung_ChiTiet where iID ='" + Request.QueryString["ID"] + "' and iSTT = '" + DropDownListSize.SelectedValue + " '");
            CheckSoLuong.MinimumValue = "0";
            CheckSoLuong.MaximumValue = dt.Rows[0][3].ToString();
            if (int.Parse(dt.Rows[0][3].ToString()) == 0)
            {
                lblSoLuong.Text = "Hết hàng";
            }
            else
            {
                lblSoLuong.Text = dt.Rows[0][3].ToString();

            }
        }

        protected void img_btn_ThemGioHang_Click(object sender, ImageClickEventArgs e)
        {
            string size = DropDownListSize.SelectedItem.ToString();
            string idGiay = Request.QueryString["ID"];
            string soluongmua = TextBoxSoLuong.Text;
            if (Session["name"].Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                //lấy id khách hàng từ username
                DataTable dt = kn.laybang("SELECT iID FROM dbo.tblUser WHERE sUsername =N'" + Session["name"].ToString() + "'");
                int iMaKH = int.Parse(dt.Rows[0][0].ToString());
                //lấy mã giỏ hàng từ id khách hàng
                DataTable dt2 = kn.laybang("SELECT iMaGH FROM dbo.tblGioHang WHERE iMaKH = '" + iMaKH+"'");
                int iMaGH = int.Parse(dt2.Rows[0][0].ToString());
                int temp = kn.ExecuteNonQuery("sp_ThemChiTietGioHang", new object[] { iMaGH, idGiay, size, soluongmua }, new List<string> { "@iMaGH", "@iID", "@iTuoi", "@isoluong" });
                if (temp != 0)
                {
                    Response.Write("<script>alert('đã thêm vào giỏ hàng');</script>");
                }
                else { Response.Write("<script>alert('sản phẩm này đã có trong giỏ hàng của bạn hoặc đường truyền của bạn gặp trục trặc');</script>"); }
            }

        }


    }
}
