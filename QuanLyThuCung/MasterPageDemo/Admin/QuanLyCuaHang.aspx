<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLyCuaHang.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLyCuaHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #QLSP{
            color: deepskyblue;
        }
        #aQLHG{
            font-weight:bold;
        }
     </style>
    <link href="Style/QuanLy.css" rel="stylesheet" />
    <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[Quản lý Cửa Hàng]</h3>
    <div id="FormThemCuaHang" class="FormNhap" runat="server">
        <span>Cửa Hàng </span><asp:TextBox ID="txtCuaHang" runat="server" Height="20px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCuaHang" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <span>Địa chỉ </span><asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Button ID="btnThemOK" runat="server" Text="Thêm" OnClick="btnThemOK_Click"/>
        <asp:Button ID="btnHuy" runat="server" Text="Hủy"  CausesValidation="false" OnClick="btnHuy_Click"/>
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" CssClass="btn"/>
    <asp:GridView ID="grvCuaHang" runat="server" AutoGenerateColumns="False" CssClass="tableGridView" DataKeyNames="iCuaHang" OnSelectedIndexCCuaHanged="grvCuaHang_SelectedIndexCuaHanged">
        <Columns>
            <asp:BoundField DataField="iCuaHang" HeaderText="ID" />
            <asp:BoundField DataField="sTenCuaHang" HeaderText="Tên Cửa Hàng" />
            <asp:BoundField DataField="sDiaChi" HeaderText="Địa chỉ" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True"/>
        </Columns>

    </asp:GridView>
</asp:Content>
