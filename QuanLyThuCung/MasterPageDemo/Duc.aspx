<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="Duc.aspx.cs" Inherits="MasterPageDemo.Duc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thú Cưng Giống Đực</title>
    <style>
        #Duc{
            color:deepskyblue;
        }

    </style>
    <link rel="stylesheet" href="Style/StyleItemGiongLoai.css" runat="server"/>
    <link rel="stylesheet" href="Style/StyleItemThuCung.css" runat="server"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">
    <div id="divListViewLoaiThuCung">
        <p>GIONG LOAI</p>
        <asp:ListView ID="ListViewLoaiThuCungDuc" runat="server" ClientIDMode="Static" >
                <ItemTemplate>
                    <div id="ItemLoaiThuCung">
                        <a href="Duc.aspx?type=<%# Eval("iMaLoai")%>"><%#Eval("sTenLoai") %></a>
                    </div>
                </ItemTemplate>
        </asp:ListView>
    </div>
        <div id="divLocTheoGia">
                <p>GIÁ TIỀN</p>
                <a href="Duc.aspx?min=0&max=200000">Dưới 200k</a>
                <a href="Duc.aspx?min=200000&max=500000">Từ 200k - 500k</a>
                <a href="Duc.aspx?min=500000&max=1000000">Từ 500k - 1 triệu</a>
                <a href="Duc.aspx?min=1000000&max=3000000">Từ 1 triệu - 3 triệu</></a>
                <a href="Duc.aspx?min=3000000&max=0">Trên 3 triệu</a>
        </div>
    </div>
    <div id="divListViewThuCung">
        <h1 id="ThongBao" runat="server" style="color:red; display:none; text-align: center;">KHÔNG CÓ DỮ LIỆU PHÙ HỢP</h1>
        <asp:ListView ID="ListViewThuCungDuc" runat="server">
             <ItemTemplate>
            <div id="itemThuCung">
            <a href="ThongTinThuCung.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divItemThuCungImg"><img src="img/ThuCung/<%# Eval("sLinkImg") %>" id="itemThuCungImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenThuCung") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
