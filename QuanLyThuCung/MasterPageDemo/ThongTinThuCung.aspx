<%@ Page Title="THUCUNG.VN" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="ThongTinThuCung.aspx.cs" Inherits="MasterPageDemo.ThongTinThuCung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Style/StyleThingTinThuCung.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="ThongTinChiTiet">
        <asp:Image ID="imgMyPham" runat="server" CssClass="img" ImageAlign="Top"/>
        <div id="NoiDung">
            <asp:Label ID="lblTenThuCung" runat="server" Text="" CssClass="lblTenThuCung"></asp:Label><br/>
            <asp:Label ID="lblGia" runat="server" Text="" CssClass="lblGia"></asp:Label><br/>
            <asp:Label ID="lblGiongLoai" runat="server" Text="" CssClass="lblGiongLoai"></asp:Label><br/>
            <asp:Label ID="lblCuaHang" runat="server" Text="" CssClass="lblCuaHang"></asp:Label><br/>
            <asp:Label ID="lblMoTa" runat="server" Text="" CssClass="lblMoTa"></asp:Label><br/>
            <span>Tháng tuổi: </span><asp:DropDownList ID="DropDownListSize" runat="server" OnSelectedIndexChanged="DropDownListSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <span>Số lượng còn: </span> <asp:Label ID="lblSoLuong" runat="server" CssClass="lblMoTa" ForeColor="Red"></asp:Label>
            <br /><span>Số lượng Mua: </span>
            <asp:TextBox ID="TextBoxSoLuong" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RangeValidator ID="CheckSoLuong" runat="server" ControlToValidate="TextBoxSoLuong" Display="Dynamic" ErrorMessage="Số lượng mua không hợp lệ" Type="Integer" ForeColor="Red"></asp:RangeValidator>
            <br />
            <asp:RequiredFieldValidator ID="CheckNhapsoluong" runat="server" ControlToValidate="TextBoxSoLuong" ErrorMessage="Vui lòng nhập số lượng mua" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="CheckSoLuong_10" runat="server" ControlToValidate="TextBoxSoLuong" ValidationExpression="^[1-9]+[0-9]*$" ErrorMessage="số lượng cần lớn hơn 0" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
        </div>
    </div>
     <asp:ImageButton ID="img_btn_ThemGioHang" runat="server" Height="67px"  ImageUrl="~/img/add_your_cart.png" ImageAlign="AbsMiddle" OnClick="img_btn_ThemGioHang_Click" CssClass="btnGioHang"/>
</asp:Content>
