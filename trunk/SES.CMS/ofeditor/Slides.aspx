<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="Slides.aspx.cs" Inherits="SES.CMS.ofeditor.Slides" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Danh sách Slide</h2>
    <asp:DataList ID="dlListSlide" runat="server" Width="100%" BackColor="White" BorderColor="#CC9966"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" RepeatColumns="5"
        RepeatDirection="Vertical" RepeatLayout="flow" DataKeyField="SlideID" OnDeleteCommand="dlListSlide_DeleteCommand"
        OnSelectedIndexChanged="dlListSlide_SelectedIndexChanged">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <ItemStyle BackColor="White" ForeColor="#330099" Width="150px" Height="140px" />
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <ItemTemplate>
                <div class="slide-wrap" style="">
                    <a class="fancyboxx" rel="group1" title="<%#Eval("Title")%>" href="<%#"/Media/" + (Eval("SlideImg")).ToString() %>">
                        <img width="100px" height="70px" src="<%#"/Media/" + (Eval("SlideImg")).ToString() %>" /></a>
                    <br />
                    <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/Images/edit_16x16.gif" />
                    <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("SlideID") %>'
                        CommandName="Delete" ImageUrl="~/AdminCP/Images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                    <br />
                    <%#Eval("Title")%>
                </div>
        </ItemTemplate>
    </asp:DataList>
    <div style="width: 100%; margin: 20px 0; float: right;">
        <div class="collection">
            <cp:CollectionPager LabelText="Page:&amp;nbsp;&amp;nbsp;" FirstText="&amp;nbsp;&amp;nbsp;<<"
                BackText="< &amp;nbsp;" LastText=">>" NextText=">" ShowFirstLast="True" ControlCssClass="collectionpager"
                PagingMode="PostBack" runat="server" BackNextLinkSeparator="" BackNextLocation="Right"
                PageNumbersDisplay="Numbers" ResultsLocation="None" BackNextDisplay="HyperLinks"
                ID="CollectionPager1" BackNextButtonStyle="" BackNextStyle="margin-left:5px;"
                ControlStyle="" PageNumbersSeparator="&amp;nbsp;" ShowLabel="True">
            </cp:CollectionPager>
            <div class="collectPage">
            </div>
        </div>
    </div>
    <br />
    <a class="button-gg-green" href="Slide.aspx" target="_self">Thêm slide</a>
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Thêm ảnh" Visible="false" />
    <br />
    <asp:Button Visible="false" ID="btnAddImages" runat="server" OnClick="btnAddImages_Click"
        Text="Thêm nhiều ảnh" />
</asp:Content>
