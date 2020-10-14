using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyThuCung : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            if (Session["admin"].ToString().Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                    FormNhap.Visible = false;
                    SoLuong.Visible = false;
                    LoadGridView();
            }
        }
        }

        void LoadGridView()
        {
         
                BoundField ID = new BoundField();
                ID.HeaderText = "ID";
                ID.DataField = "iID";

                BoundField TenTC = new BoundField();
                TenTC.HeaderText = "Tên thú cưng";
                TenTC.DataField = "sTenThuCung";

                BoundField Gia = new BoundField();
                Gia.HeaderText = "Giá";
                Gia.DataField = "fGia";

                BoundField GiongLoai = new BoundField();
            GiongLoai.HeaderText = "Giống loài";
            GiongLoai.DataField = "sTenLoai";

                BoundField CuaHang = new BoundField();
            CuaHang.HeaderText = "Cửa hàng";
            CuaHang.DataField = "sTenCuaHang";

                BoundField GioiTinh = new BoundField();
                GioiTinh.HeaderText = "Giới tính";
                GioiTinh.DataField = "bGioiTinh";
                    

                //BoundField sMoTa = new BoundField();
                //ID.HeaderText = "Mô tả";
                //ID.DataField = "sMoTa";

                ImageField Img = new ImageField();
                Img.HeaderText = "Ảnh SP";
                Img.DataImageUrlField = "sLinkImg";
                Img.DataImageUrlFormatString = "../../img/ThuCung/{0}";

                CommandField Sua = new CommandField();
                Sua.ButtonType = ButtonType.Button;
                Sua.SelectText = "Sửa";
                Sua.ShowSelectButton = true;

                grv1.Columns.Add(ID);
                grv1.Columns.Add(TenTC);
                grv1.Columns.Add(Gia);
                grv1.Columns.Add(GiongLoai);
                grv1.Columns.Add(CuaHang);
                grv1.Columns.Add(GioiTinh);
                grv1.Columns.Add(Img);
                grv1.Columns.Add(Sua);

                grv1.DataKeyNames = new string[] { "iID" };
                grv1.DataSource = kn.ExecuteQuery("GetThuCungAdmin", null, null);
                grv1.DataBind();
        }


        protected void grv1_SelectedIndexChanged(object sender, EventArgs e)
        {

                //Khi bấm sửa, tắt nút theemm, xác nhận thêm
                //enable nút ok

                btnThemOK.Enabled = false;
                btnThemOK.Visible = false;
                btnThem.Enabled = false;
                btnThem.Visible = false;

                btnOK.Enabled = true;
                btnOK.Visible = true;

                FormNhap.Visible = true;
                SoLuong.Visible = false;

                DataTable dt = new DataTable();
                dt.Clear();
                dt = kn.ExecuteQuery("XemTTThuCung", new object[] { grv1.SelectedDataKey.Value },new List<string> { "@id"});

                lblID.Text = dt.Rows[0][0].ToString();
                txtTenThuCung.Text = dt.Rows[0][1].ToString();
                txtGia.Text = dt.Rows[0][2].ToString();

                ddGiongLoai.ClearSelection();
            ddGiongLoai.DataSource = kn.laybang("Select * from tblGiongLoai");
            ddGiongLoai.DataTextField = "sTenLoai";
            ddGiongLoai.DataValueField = "iMaLoai";
            ddGiongLoai.DataBind();
            ddGiongLoai.Items.FindByText(dt.Rows[0][3].ToString()).Selected = true;
                //dlTest.Items.FindByValue(string val).Selected = true;


                ddGioiTinh.ClearSelection();      
                ddCuaHang.DataSource = kn.laybang("Select * from tblCuaHang");
            ddCuaHang.DataTextField = "sTenCuaHang";
            ddCuaHang.DataValueField = "iCuaHang";
            ddCuaHang.DataBind();
            ddCuaHang.Items.FindByText(dt.Rows[0][4].ToString()).Selected = true;

                ddGioiTinh.ClearSelection();
                ddGioiTinh.Items.FindByValue(dt.Rows[0][5].ToString()).Selected = true;

                txtMoTa.Text = dt.Rows[0][6].ToString();
                ImgSP.ImageUrl = "../../img/ThuCung/"+dt.Rows[0][7].ToString();
                ImgSP.Width = 350;

                dt.Dispose();
         }
        

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (imgUpload.HasFile)
            {
                string allowEx = ".jpg .png .gif .tiff .bmp";
                string extension = Path.GetExtension(imgUpload.FileName);

                if (allowEx.Contains(extension))
                {
                    string filePath = Server.MapPath("../img/ThuCung/" + imgUpload.FileName);
                    imgUpload.SaveAs(filePath);

                    object[] param = new object[] { grv1.SelectedDataKey.Value, txtTenThuCung.Text, txtGia.Text, ddGiongLoai.SelectedValue, ddCuaHang.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, imgUpload.FileName };
                    List<string> paramList = new List<string> { "@iID", "@sTenThuCung", "@fGia", "@iMaLoai", "@iCuaHang", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                    int kq = kn.ExecuteNonQuery("UpdateThuCungAdmin", param, paramList);
                    if (kq != 0)
                    {
                        Response.Write("<script>alert('Cập nhật thành công');</script>");
                        Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                    }
                    else
                    {
                        Response.Write("<script>alert('Lỗi');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Mởi bạn tải lên file ảnh *.jpg, png, gif, tiff, bmp');</script>");
                }
            }
            else
            {
                string sLinkImg = kn.lay1giatri("Select sLinkImg from tblThuCung where iID ='" + grv1.SelectedDataKey.Value + "'");
                object[] param = new object[] { grv1.SelectedDataKey.Value, txtTenThuCung.Text, txtGia.Text, ddGiongLoai.SelectedValue, ddCuaHang.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, sLinkImg };
                List<string> paramList = new List<string> { "@iID", "@sTenThuCung", "@fGia", "@iMaLoai", "@iCuaHang", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                int kq = kn.ExecuteNonQuery("UpdateThuCungAdmin", param, paramList);
                if (kq != 0)
                {
                    Response.Write("<script>alert('Cập nhật thành công');</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('Lỗi');</script>");
                }
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            //Khi bấm thêm SP, tắt nút ok của cập nhật đi, 
            //Enable cái form nhập
            //Enable nút xác nhận thêm]

            FormNhap.Visible = true;

            btnThem.Visible = false;
            btnThem.Enabled = false;

            btnOK.Enabled = false;
            btnOK.Visible = false;

            btnThemOK.Enabled = true;
            btnThemOK.Visible = true;

            btnSuaSoLuong.Visible = false;
            btnSuaSoLuong.Enabled = false;
            SoLuong.Visible = false;

            ddGiongLoai.ClearSelection();
            ddGiongLoai.DataSource = kn.laybang("Select * from tblGiongLoai");
            ddGiongLoai.DataTextField = "sTenLoai";
            ddGiongLoai.DataValueField = "iMaLoai";
            ddGiongLoai.DataBind();

            ddGioiTinh.ClearSelection();
            ddCuaHang.DataSource = kn.laybang("Select * from tblCuaHang");
            ddCuaHang.DataTextField = "sTenCuaHang";
            ddCuaHang.DataValueField = "iCuaHang";
            ddCuaHang.DataBind();

            ddGioiTinh.ClearSelection();

        }

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            if (imgUpload.HasFile)
            {
                string allowEx = ".jpg .png .gif .tiff .bmp";
                string extension = Path.GetExtension(imgUpload.FileName);

                if (allowEx.Contains(extension))
                {
                    string filePath = Server.MapPath("../img/ThuCung/" + imgUpload.FileName);
                    imgUpload.SaveAs(filePath);

                    object[] param = new object[] { txtTenThuCung.Text, txtGia.Text, ddGiongLoai.SelectedValue, ddCuaHang.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, imgUpload.FileName };
                    List<string> paramList = new List<string> { "@sTenThuCung", "@fGia", "@iMaLoai", "@iCuaHang", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                    int kq = kn.ExecuteNonQuery("InsertThuCungAdmin", param, paramList);
                    if (kq != 0)
                    {
                        Response.Write("<script>alert('Thêm thành công');</script>");
                        Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                    }
                    else
                    {
                        Response.Write("<script>alert('Lỗi');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Mởi bạn tải lên file ảnh *.jpg, png, gif, tiff, bmp');</script>");
                }
            }
            else
            {
                object[] param = new object[] { txtTenThuCung.Text, txtGia.Text, ddGiongLoai.SelectedValue, ddCuaHang.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, "0.jpg" };
                List<string> paramList = new List<string> { "@sTenThuCung", "@fGia", "@iMaLoai", "@iCuaHang", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                int kq = kn.ExecuteNonQuery("InsertThuCungAdmin", param, paramList);
                if (kq != 0)
                {
                    Response.Write("<script>alert('Thêm thành công');</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('Lỗi');</script>");
                }
            }

        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            FormNhap.Visible = false;
            btnThem.Visible = true;
            btnThem.Enabled = true;

            lblID.Text = "";
            txtTenThuCung.Text = "";
            txtMoTa.Text = "";
            txtGia.Text = "";
            ImgSP.ImageUrl = "";
        }

        protected void btnSuaSoLuong_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = kn.laybang("Select * from tblThuCung_ChiTiet where iID ='"+grv1.SelectedDataKey.Value+"'");
            if (dt != null && dt.Rows.Count == 9)
            {
                btnSuaSoLuong.Visible = false;
                btnSuaSoLuong.Enabled = false;
                SoLuong.Visible = true;
                txtSoLuong36.Text = dt.Rows[0]["iSoLuong"].ToString();
                txtSoLuong37.Text = dt.Rows[1]["iSoLuong"].ToString();
                txtSoLuong38.Text = dt.Rows[2]["iSoLuong"].ToString();
                txtSoLuong39.Text = dt.Rows[3]["iSoLuong"].ToString();
                txtSoLuong40.Text = dt.Rows[4]["iSoLuong"].ToString();
                txtSoLuong41.Text = dt.Rows[5]["iSoLuong"].ToString();
                txtSoLuong42.Text = dt.Rows[6]["iSoLuong"].ToString();
                txtSoLuong43.Text = dt.Rows[7]["iSoLuong"].ToString();
                txtSoLuong44.Text = dt.Rows[8]["iSoLuong"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi đường truyền');</script>");
            }
        }

        protected void btnUpdateSoLuong_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { grv1.SelectedDataKey.Value, txtSoLuong36.Text, txtSoLuong37.Text, txtSoLuong38.Text, txtSoLuong39.Text,
            txtSoLuong40.Text,txtSoLuong41.Text,txtSoLuong42.Text,txtSoLuong43.Text,txtSoLuong44.Text};

            List<string> paramList = new List<string> {"@iID", "@iSoLuong36", "@iSoLuong37", "@iSoLuong38", "@iSoLuong39", "@iSoLuong40", "@iSoLuong41",
                "@iSoLuong42", "@iSoLuong43", "@iSoLuong44" };
            kn.ExecuteNonQuery("SuaSoLuongThuCungAdmin", param, paramList);



            Response.Write("<script>alert('Thêm thành công');</script>");
            Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
        }


        protected void btnHuySoLuong_Click(object sender, EventArgs e)
        {
            SoLuong.Visible = false;
            btnSuaSoLuong.Visible = true;
            btnSuaSoLuong.Enabled = true;
        }
    }
}
