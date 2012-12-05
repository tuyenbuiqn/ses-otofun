<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListImages.ascx.cs"
    Inherits="SES.CMS.AdminCP.PageUC.ucListImages" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<style type="text/css">
    .collectionpager
    {
        float: right;
    }
    .collectionpager a
    {
        color: white;
        padding: 0px 4px;
        margin: 0 0px;
        background: #069;
        text-decoration: none;
    }
    .collectPage
    {
        float: right;
        width: 5%;
        margin-right: 5px;
        font-weight: bold;
    }
    .collection
    {
        float: right;
        width: 95%;
        margin-left: 5px;
    }
</style>
<h2>
    Danh sách ảnh tour</h2>
<div style="float: left; width: 100%; height: 30px; line-height: 25px;">
    <span style="float: left; width: 150px; font-weight: bold;">Chọn theo: </span><span
        style="float: right;">Danh mục:
        <asp:DropDownList runat="server" ID="ddlCate" AutoPostBack="true" Width="250px" OnSelectedIndexChanged="ddlCate_SelectedIndexChanged"
            AppendDataBoundItems="true">
            <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
        </asp:DropDownList>
        Bài viết:
        <asp:DropDownList runat="server" ID="ddlArticle" Width="250px" AutoPostBack="true"
            OnSelectedIndexChanged="ddlArticle_SelectedIndexChanged" AppendDataBoundItems="true">
            <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
        </asp:DropDownList>
        Slide:
        <asp:DropDownList runat="server" ID="ddlSlide" Width="250px" AutoPostBack="true"
            OnSelectedIndexChanged="ddlSlide_SelectedIndexChanged" AppendDataBoundItems="true">
            <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
        </asp:DropDownList>
    </span>
</div>
<div style="width:100%; float:left; margin-top:30px;">
    <asp:DataList ID="dlImages" runat="server" Width="100%" BackColor="White" BorderColor="#CC9966"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" RepeatColumns="7"
        RepeatDirection="Horizontal" DataKeyField="ImageID" OnDeleteCommand="dlImages_DeleteCommand"
        OnSelectedIndexChanged="dlImages_SelectedIndexChanged">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <ItemStyle BackColor="White" ForeColor="#330099" Width="120px" />
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <ItemTemplate>
            <center>
                <a class="fancyboxx" rel="group1" title="<%#Eval("Title")%>" href="<%#"/Media/" + (Eval("ImgFile")).ToString() %>">
                    <img width="100px" height="70px" src="<%#"/Media/" + (Eval("ImgFile")).ToString() %>" /></a>
                <br />
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("ImageID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                <br />
                <%#Eval("Title")%>
            </center>
        </ItemTemplate>
    </asp:DataList>
    <div style="width: 100%; margin-top: 10px;">
        <div class="collection">
            <cp:CollectionPager LabelText="" FirstText="&amp;nbsp;&amp;nbsp;<<" BackText="< &amp;nbsp;"
                LastText=">>" NextText=">" ShowFirstLast="True" ControlCssClass="collectionpager"
                PagingMode="PostBack" runat="server" BackNextLinkSeparator="" BackNextLocation="Split"
                PageNumbersDisplay="Numbers" ResultsLocation="None" BackNextDisplay="HyperLinks"
                ID="CollectionPager1" BackNextButtonStyle="" BackNextStyle="margin-left:5px;"
                ControlStyle="" PageNumbersSeparator="&amp;nbsp;">
            </cp:CollectionPager>
            <div class="collectPage">
                Page:</div>
        </div>
    </div>
</div>
