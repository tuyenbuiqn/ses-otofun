<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCategory.aspx.cs" Inherits="SES.CMS.AdminCP.ListCategory" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chọn Danh mục</title>
    <script type="text/javascript">
        function ReturnToParentPage() {
            var parentWindow = window.parent;
            parentWindow.SelectAndClosePopup(tlCategory.GetFocusedNodeKey());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dxwtl:ASPxTreeList ID="tlCategory" runat="server" 
            AutoGenerateColumns="False" Width="100%" ClientInstanceName="tlCategory" 
            KeyFieldName="CategoryID" ParentFieldName="ParentID">
            <SettingsPager Mode="ShowPager" PageSize="100">
<AllButton Text="All"></AllButton>

<NextPageButton Text="Next &gt;"></NextPageButton>

<PrevPageButton Text="&lt; Prev"></PrevPageButton>
            </SettingsPager>
            <SettingsBehavior AllowFocusedNode="True" />
            
            <SettingsPager ShowDefaultImages="False">
                <AllButton Text="All">
                </AllButton>
                <NextPageButton Text="Next &gt;">
                </NextPageButton>
                <PrevPageButton Text="&lt; Prev">
                </PrevPageButton>
            </SettingsPager>
            <Columns>
                <dxwtl:TreeListTextColumn FieldName="CategoryID" Name="clCategoryID" 
                    Visible="False" VisibleIndex="0">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn Caption="Tiêu đề" Width="70%" Name="Title" 
                    VisibleIndex="0" FieldName="Title">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn Caption="Trang chủ" Width="10%" FieldName="IsHomePage" 
                    Name="clIsHomePage" VisibleIndex="1">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn Caption="Hiển thị" Width="10%" FieldName="IsPublish" 
                    Name="clIsPublish" VisibleIndex="2">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn Caption="Thứ tự" Width="10%" FieldName="OrderID" Name="clOrderID" 
                    VisibleIndex="3">
                </dxwtl:TreeListTextColumn>
            </Columns>
        </dxwtl:ASPxTreeList>
    
    </div>
    <div>
        <asp:Button ID="btChon" runat="server" Text="Chọn" OnClientClick="ReturnToParentPage()" />
    
    </div>
    </form>
</body>
</html>
