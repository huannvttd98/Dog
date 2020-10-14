<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLyGiongLoai.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLyGiongLoai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #QLSP{
            color: deepskyblue;
        }
        #aQLLG{
            font-weight:bold;
        }

    </style>
    <link href="Style/QuanLy.css" rel="stylesheet" />
    <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[Quản lý Giống Loài]</h3>
    <div id="FormNhapGiongLoai" runat="server" class="FormNhap">
        <span>Tên giống loài: </span>
        <asp:TextBox ID="txtGiongLoai" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGiongLoai" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Button ID="btnThemOK" runat="server" Text="Thêm" OnClick="btnThemOK_Click" />
        <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn"/>
    <asp:GridView ID="grvGiongLoai" runat="server" CssClass="tableGridView" AutoGenerateColumns="False" OnSelectedIndexChanged="grvGiongLoai_SelectedIndexChanged" DataKeyNames="iMaLoai">
        <Columns>
            <asp:BoundField DataField="iMaLoai" HeaderText="ID" />
            <asp:BoundField DataField="sTenLoai" HeaderText="Tên giống loài" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
