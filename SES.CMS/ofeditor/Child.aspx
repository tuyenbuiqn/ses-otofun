<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Child.aspx.cs" Inherits="SES.CMS.ofeditor.Child" %>


<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <%--DateControl--%>
    
    <script type="text/javascript">
        $(function () {
            $("#txtSearchDateStart").datepicker({
                showOn: "button",
                buttonImage: "/images/calendar.gif",
                buttonImageOnly: true
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtSearchDateEnd").datepicker({
                showOn: "button",
                buttonImage: "/images/calendar.gif",
                buttonImageOnly: true
            });
        });
    </script>
    <%--DateControl--%>
    <%--Trả về giá trị cho form cha--%>
    <script  type="text/javascript">
        function Done() {
            var ListArticlesId = document.getElementById("<%=hdfListArticlesId.ClientID%>");
            window.opener.document.getElementById("txtPopup").value = ListArticlesId.value;
            close();
        }  
   </script>  
   <%--end Trả về giá trị cho form cha--%>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div id="Child">
        <p>
            <asp:Label ID="lblMessenger" CssClass="lblMess" runat="server" Text=""></asp:Label></p>
        <asp:HiddenField ID="hdfListArticlesId" runat="server" />
        <asp:HiddenField ID="hdfListArticlesName" runat="server" />
        <asp:HiddenField ID="hdfSearchDateStart" runat="server" />
        <asp:HiddenField ID="hdfSearchDateEnd" runat="server" />
        <asp:HiddenField ID="hdfSearchCategoryId" runat="server" />
        <asp:HiddenField ID="hdfSearchKey" runat="server" />
        <div id="ListArticlesAndSearch">
            <div id="Search">
                <table>
                    <tr>
                        <td>
                            &nbsp; Key: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchKey" CssClass="Textbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSearchCategory" CssClass="ddl"  runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Chọn ngày: Từ
                            <asp:TextBox ID="txtSearchDateStart" CssClass="Textbox"  runat="server"></asp:TextBox>
                            Đến
                            <asp:TextBox ID="txtSearchDateEnd" CssClass="Textbox"  runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkSearch" ToolTip="Tìm Kiếm" CssClass="Buttom" runat="server" onclick="lnkSearch_Click">
                                <img alt="Select" src="/images/Search.png" border="0" style="width: 32px; height: 32px;" />
                            </asp:LinkButton>
                        </td>
                        
                    </tr>
                </table>
            </div>
            <div id="ListArticles">
                <asp:Panel ID="pnlTitle01" runat="server">
                    <p class="Title">Danh sách tin bài</p>
                </asp:Panel>
                <asp:Repeater ID="rptListArticles" runat="server" 
                    onitemdatabound="rptListArticles_ItemDataBound" 
                    onitemcommand="rptListArticles_ItemCommand">
                    <HeaderTemplate>
                        <table class="classListArticles">
                            <tr>
                                <th>Mã</th>
                                <th>Tên bài viết</th>
                                <th>Danh mục</th>
                                <th>Ngày viết</th>
                                <th>Action</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblArticleId" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblArticleName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblArticleCategory" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblArticleTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkSelectItem" ToolTip="Chọn" runat="server">
                                    <img alt="Select" src="/images/rt.gif" border="0" style="width: 16px; height: 16px;" />
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="ArticlesSelect">
            <div id="ListArticlesSelect">
                <asp:Panel ID="pnlTitle02" runat="server">
                    <p class="Title">Danh sách tin đã chọn</p>
                </asp:Panel>
                <asp:Repeater ID="rptListArticlesSelect" runat="server" 
                    onitemdatabound="rptListArticlesSelect_ItemDataBound" 
                    onitemcommand="rptListArticlesSelect_ItemCommand">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>
                                    Tên bài viết
                                </th>
                                <th style="width: 45px;">
                                    Action
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblArticleSelect" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" ToolTip="Xóa" runat="server">
                                    <img alt="Delete" src="/images/action_delete.png"border="0" style="width: 16px; height: 16px;" />
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <input type='button' class="inputButtom" name = 'button' value='HOÀN THÀNH' onclick='Done();' /> 
        </div>
    </div>
    </form>
</body>
</html>

