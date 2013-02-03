<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true" CodeBehind="Slide.aspx.cs" Inherits="SES.CMS.ofeditor.Slide" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 195px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField runat="server" ID="hdfID1"></asp:HiddenField>
<asp:HiddenField runat="server" ID="hdfIMG"></asp:HiddenField>
<asp:HiddenField runat="server" ID="hdfURL"></asp:HiddenField>
<asp:HiddenField runat="server" ID="hdfTitle"></asp:HiddenField>
  <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="RNServices.asmx" />
        </Services>
    </telerik:RadScriptManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
        //<![CDATA[


            var currentID = null;
            var notSelect = 0;

            function ShowDialog() 
            {
                var returnPopup = window.open('Child.aspx', '_blank', 'scrollbars=10, width=820,height=900');
                //          var txtPopup = document.getElementById(txtPopup).value;
                //          txtPopup.value = returnPopup;
            }
                function checkMaxLen(txt, maxLen) 
                {
                    try {
                        if (txt.value.length > (maxLen - 1)) 
                        {
                            var cont = txt.value;
                            txt.value = cont.substring(0, (maxLen - 1));
                            return false;
                        };
                    } 
                    catch (e) {
                    }
                }



                
                function openWinNews() {

                    //SetDataCurrent();

                    var oWnd = radopen("TinNoiBatForm.aspx", "RadWindow1");
                }

                function openSelectIMG() {
                    if (notSelect != 1) {
                        alert("Hãy chọn bài viết trước tiên rồi chọn ảnh!");
                        return;
                     }
                    var oWnd2 = radopen("SelectIMG.aspx?ID="+currentID, "RadWindow2");
                }



                function OnClientClose(oWnd, args) 
                {


                    var arg = args.get_argument();

                    if (arg) {


                        var ID = arg.ID;
                        args = null;
                        oWnd = null;
                        
                        //$get("order").innerHTML = "You chose to fly to " + cityName;
                        if (ID == "1") {
                            currentID = arg.cityName;
                            notSelect = 1;
                            updateChangesURL(arg.cityName);

                        }
                        else {
                            updateChangeIMG(arg.cityName2);
                        }
                    }

                }



                //Get data key (ArticleID)
                function getDataItemKeyValue(radGrid, item) {
                    return parseInt(radGrid.get_masterTableView().getCellByColumnUniqueName(item, "ArticleID").innerHTML);
                }




                function OnError(result) {
                    alert("Error: " + result.get_message());
                }

                function updateChangesURL(stringID) {
                    SES.CMS.ofeditor.RNServices.GetNewsURL(stringID, updateTXT, OnError);
                    SES.CMS.ofeditor.RNServices.GetNewsTitle(stringID, updateTitle, OnError);
                    document.getElementById("<%= hdfID1.ClientID %>").value = stringID;
              
                }

                function updateChangeIMG(stringID) {
                    document.getElementById("<%= imgSlide.ClientID %>").src = stringID;
                    document.getElementById("<%= hdfIMG.ClientID %>").value = stringID;

                }

               


                function OnError(result) {
                    alert("Error: " + result.get_message());
                }
                function updateTXT(result) {
                    document.getElementById("<%= txtSlideURL.ClientID %>").value = result;
                    document.getElementById("<%= hdfURL.ClientID %>").value = result;
                }
                function updateTitle(result) {
                    document.getElementById("<%= txtTitle.ClientID %>").value = result;
                    document.getElementById("<%= hdfTitle.ClientID %>").value = result;
                }

                function updateGrid2(result) {
               
                }

            var firstRun = 1;
                function OnReplaceComplete(result) {
               
                }
                function OnReplaceComplete2(result1) {
              
                }

                function deleteCurrent() {
                
                }

                function deleteCurrent2() {
               
                }


           

        //]]>
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" AutoSize="true" Modal="true"
                OnClientClose="OnClientClose" NavigateUrl="TinNoiBatForm.aspx">
            </telerik:RadWindow>
            <telerik:RadWindow ID="RadWindow2" runat="server" AutoSize="true" Modal="true"
                OnClientClose="OnClientClose" NavigateUrl="RelatedNews2.aspx">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
<div style="width:98%; float:left; margin-left:5px;">
<h2>
    Cập nhật Slide</h2>
<table width="100%" class="tstyle2">
    <tr>
        <td class="style8">
            Tiêu đề:
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle" runat="server" ReadOnly="true" Width="330px" 
                ValidationGroup="submitGrp"></asp:TextBox> &nbsp; <input type="submit" value="Chọn Tin" onclick="openWinNews(); return false;" />
           
        </td>
    </tr>
    <tr>
        <td class="style8">
            URL</td>
        <td class="style9">
           <asp:TextBox ID="txtSlideURL" runat="server" Width="439px" ReadOnly="true"
                ValidationGroup="submitGrp" ></asp:TextBox> </td>
    </tr>
    <tr>
        <td class="style8">
            Ảnh tin:
        </td>
        <td class="style9">
            <table><tr><td>
                <asp:Image ID="imgSlide" runat="server" Height="79px" Width="129px" />
                </td><td class="style1"><input type="submit"    onclick="openSelectIMG(); return false;"  value="Chọn Ảnh" /></td></tr></table>
        </td>
    </tr>
    
    <tr>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="submitGrp" CssClass="button" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy" CssClass="button" />
        </td>
    </tr>
</table>
</div>
</asp:Content>
