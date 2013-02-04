<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBTVPermission.ascx.cs"
    Inherits="SES.CMS.AdminCP.PageUC.ucBTVPermission" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<div style="float: left; width: 100%; margin: 10px 0 10px 10px;">
    Chọn biên tập viên
    <asp:DropDownList runat="server" ID="ddlBTV" AutoPostBack="true" Width="250px" AppendDataBoundItems="true" 
        onselectedindexchanged="ddlBTV_SelectedIndexChanged">
        <asp:ListItem Text=".: Chọn biên tập viên :." Value="0"></asp:ListItem>
    </asp:DropDownList>
</div>
<div style="float: left; width: 100%; margin: 0px 0 10px 10px;">
    <p style="margin: 0;">
        Chọn chuyên mục</p>
    <dxwtl:ASPxTreeList ID="tlCategory" runat="server" AutoGenerateColumns="False" CssClass="tbdatdichvu"
        ClientInstanceName="tlCategory" KeyFieldName="CategoryID" ParentFieldName="ParentID"
        EnableCallbackCompression="False" Width="530px">
        <SettingsSelection AllowSelectAll="False" Enabled="True" Recursive="False"   />
        <SettingsPager Mode="ShowPager" PageSize="70">
            <AllButton Text="Tất cả">
            </AllButton>
            <NextPageButton Text="Tiếp theo &gt;">
            </NextPageButton>
            <PrevPageButton Text="&lt; Trước">
            </PrevPageButton>
        </SettingsPager>
        <SettingsBehavior AllowFocusedNode="True" />
        <SettingsPager ShowDefaultImages="False">
            <AllButton Text="Tất cả">
            </AllButton>
            <NextPageButton Text="Tiếp theo &gt;">
            </NextPageButton>
            <PrevPageButton Text="&lt; Trước">
            </PrevPageButton>
        </SettingsPager>
        <Columns>
            <dxwtl:TreeListTextColumn FieldName="CategoryID" Name="clCategoryID" Visible="False"
                VisibleIndex="0">
            </dxwtl:TreeListTextColumn>
            <dxwtl:TreeListTextColumn Caption="Chuyên mục" Width="90%" Name="Title" VisibleIndex="1"
                FieldName="Title">
            </dxwtl:TreeListTextColumn>
        </Columns>
    </dxwtl:ASPxTreeList>
</div>
<div style="float: left; width: 100%; margin: 0px 0 10px 10px;">

    <asp:Button runat="server" ID="btnSave" Text="Lưu" OnClick="btnSave_Click" />
</div>
