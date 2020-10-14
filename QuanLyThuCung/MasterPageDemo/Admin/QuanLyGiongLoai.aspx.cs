using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyGiongLoai : System.Web.UI.Page
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
                    FormNhapGiongLoai.Visible = false;
                    LoadGridView();
                }
            }
        }

        void LoadGridView() {
            DataTable dt = new DataTable();
            dt = kn.ExecuteQuery("GetGiongLoaiAdmin", null, null);
            if (dt != null)
            {
                grvGiongLoai.DataSource = dt;
                grvGiongLoai.DataBind();
            }
        }

        protected void grvGiongLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThemOK.Enabled = false;
            btnThemOK.Visible = false;

            btnOK.Enabled = true;
            btnOK.Visible = true;

            btnThem.Enabled = false;
            btnThem.Visible = false;

            FormNhapGiongLoai.Visible = true;

            string id = grvGiongLoai.SelectedDataKey.Value.ToString();
            DataTable dt = kn.ExecuteQuery("GetGiongLoaiAdmin", new object[] { id }, new List<string> {"@iMaLoai" });
            if (dt != null)
            {
                txtGiongLoai.Text = dt.Rows[0]["sTenLoai"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("UpdateGiongLoaiAdmin", new object[] { grvGiongLoai.SelectedDataKey.Value, txtGiongLoai.Text }, new List<string> {"@iMaLoai", "@sTenLoai" });
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

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("InsertGiongLoaiAdmin", new object[] { txtGiongLoai.Text }, new List<string> {"@sTenLoai" });
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
            FormNhapGiongLoai.Visible = false;

            btnThem.Visible = true;
            btnThem.Enabled = true;

            txtGiongLoai.Text = string.Empty;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            FormNhapGiongLoai.Visible = true;

            btnThem.Enabled = false;
            btnThem.Visible = false;

            btnOK.Enabled = false;
            btnOK.Visible = false;

            btnThemOK.Enabled = true;
            btnThemOK.Visible = true;
        }
    }
}