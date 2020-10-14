<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="MasterPageDemo.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>THUCUNG.VN </title>
    <link rel="stylesheet" href="Style/StyleItemThuCung.css" />
    <style>

        @media screen and (min-width : 768px){
            .banner{
                width: 100%;
                margin:-1em auto 1em auto;
            }
            .banner img{
                width: 100%;
            }
            .divListViewThuCungTrangChu{
                width: 90%;
                margin: 1em auto 5em auto;
            }
        }
        @media screen and (max-width : 768px){
            banner{
                width: 100%;
                margin:0 auto 1em auto;
            }
            .banner img{
                width: 100%;
            }
            .divListViewThuCungTrangChu{
                width: 90%;
                margin: 1em auto 5em auto;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner">
    <img src="img/bannerNam.png"/>
    <h3 style="background-color: whitesmoke; text-align:center; line-height:50px; margin-top:-5px">MỸ PHẨM NAM</h3>
    </div>
    <div class="divListViewThuCungTrangChu">
    <asp:ListView ID="ListViewThuCungDuc" runat="server">
        <ItemTemplate>
            <div id="itemThuCung">
            <a href="ThongTinThuCung.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divItemThuCungImg"><img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemThuCungImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenThuCung") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
    </asp:ListView>
</div>


    <div class="banner">
        <img src="img/bannerNu.png"/>
            <h3 style="background-color: whitesmoke; text-align:center; line-height:50px; margin-top:-5px">MỸ PHẨM NỮ</h3>
    </div>


    <div class="divListViewThuCungTrangChu">
    <asp:ListView ID="ListViewThuCungCai" runat="server">
        <ItemTemplate>
            <div id="itemThuCung">
            <a href="ThongTinThuCung.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divitemThuCungImg"><img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemThuCungImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenThuCung") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
    </asp:ListView>
</div>
&nbsp;
</asp:Content>
