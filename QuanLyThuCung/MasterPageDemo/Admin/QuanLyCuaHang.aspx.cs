using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyCuaHang : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"].ToString().Equals(""))
                {
                    Response.Redirect("DangNhap.aspx");
                }
                else
                {
                    FormThemCuaHang.Visible = false;
                    LoadGridView();
                }
            }
        }
        void LoadGridView()
        {
            DataTable dt = new DataTable();
            dt = kn.ExecuteQuery("GetCuaHangAdmin", null, null);
            if (dt != null)
            {
                grvCuaHang.DataSource = dt;
                grvCuaHang.DataBind();
            }
        }

        protected void grvCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThemOK.Enabled = false;
            btnThemOK.Visible = false;

            btnOK.Enabled = true;
            btnOK.Visible = true;

            btnThem.Enabled = false;
            btnThem.Visible = false;

            FormThemCuaHang.Visible = true;

            string id = grvCuaHang.SelectedDataKey.Value.ToString();
            DataTable dt = kn.ExecuteQuery("GetCuaHangAdmin", new object[] { id }, new List<string> { "@iCuaHang" });
            if (dt != null)
            {
                txtCuaHang.Text = dt.Rows[0]["sTenCuaHang"].ToString();
                txtDiaChi.Text = dt.Rows[0]["sDiaChi"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("UpdateCuaHangAdmin", new object[] { grvCuaHang.SelectedDataKey.Value, txtCuaHang.Text, txtDiaChi.Text }, new List<string> { "@iCuaHang", "@sTenCuaHang", "@sDiaChi" });
            if (kq != 0)
            {
                Response.Write("<script>alert('Update thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("InsertCuaHangAdmin", new object[] { txtCuaHang.Text, txtDiaChi.Text }, new List<string> { "@sTenCuaHang", "@sDiaChi" });
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

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            FormThemCuaHang.Visible = false;

            btnThem.Visible = true;
            btnThem.Enabled = true;

            txtCuaHang.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            FormThemCuaHang.Visible = true;
            btnThem.Enabled = false;
            btnThem.Visible = false;

            btnOK.Enabled = false;
            btnOK.Visible = false;

            btnThemOK.Enabled = true;
            btnThemOK.Visible = true;
        }


    }
}