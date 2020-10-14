
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="MasterPageDemo.TimKiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>THUCUNG.VN  :3</title>
    <link rel="stylesheet" href="Style/StyleItemThuCung.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divListViewThuCung">
    <asp:ListView ID="ListViewThuCung" runat="server">
        <ItemTemplate>
            <div id="itemThuCung">
               <div id="divItemThuCungImg"><a href="ThongTinThuCung.aspx?ID=<%# Eval("iID")%>"> <img src="img/ThuCung/<%# Eval("sLinkImg") %>" id="itemThuCungImg" align="top"/> </a></div><br/>
            <p><%#Eval("sTenThuCung") %></p>
            <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><%#Eval("sMoTa") %></p>--%>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
&nbsp;
</asp:Content>
