<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadEditorForm.aspx.cs" Inherits="RadEditorForm" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	
</head>
<body>
    <form id="form1" runat="server">
	    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

                <script type="text/javascript">
                    var popUp;
                    function PopUpShowing(sender, eventArgs) {
                        var message = document.getElementById("message");
                        message.innerHTML = "";
                        message.innerHTML = "<br/>Message from OnPopUpShowing: get_masterTableView() retuned " + sender.get_masterTableView();
                        popUp = eventArgs.get_popUp();
                        var gridWidth = sender.get_element().offsetWidth;
                        var gridHeight = sender.get_element().offsetHeight;
                        var popUpWidth = popUp.style.width.substr(0, popUp.style.width.indexOf("px"));
                        var popUpHeight = popUp.style.height.substr(0, popUp.style.height.indexOf("px"));
                        popUp.style.left = ((gridWidth - popUpWidth) / 2 + sender.get_element().offsetLeft).toString() + "px";
                        popUp.style.top = ((gridHeight - popUpHeight) / 2 + sender.get_element().offsetTop).toString() + "px";
                    }
                    function GridCreated(sender, eventArgs) {
                        var message = document.getElementById("message");
                        message.innerHTML += "<br/>Message from OnGridCerated: get_masterTableView() retuned " + sender.get_masterTableView();
                    }
                </script>

            </telerik:RadCodeBlock>
            <telerik:RadAjaxPanel ID="RadAjaxPanel" runat="server">
                <telerik:RadGrid ID="RadGrid1" AutoGenerateEditColumn="true" runat="server" AllowAutomaticDeletes="True"
                    AllowAutomaticInserts="True" AllowAutomaticUpdates="True" DataSourceID="SqlDataSource1"
                    AllowSorting="true" AllowPaging="true">
                    <MasterTableView EditMode="PopUp" CommandItemDisplay="Top" DataKeyNames="ProductID">
                        <EditFormSettings PopUpSettings-Height="260px" PopUpSettings-Width="500px" />
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnPopUpShowing="PopUpShowing" OnGridCreated="GridCreated" />
                        <Selecting AllowRowSelect="true" />
                    </ClientSettings>
                </telerik:RadGrid>
            </telerik:RadAjaxPanel>
            <span id="message"></span>
            <asp:AccessDataSource ID="SqlDataSource1" runat="server" DataFile="~/App_Data/Nwind.mdb"
                SelectCommand="SELECT ProductID, ProductName, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, Discontinued FROM [Products]"
                DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = ?" InsertCommand="INSERT INTO Products(ProductName, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, Discontinued) VALUES (?, ?, ?, ?, ?, ?)"
                UpdateCommand="UPDATE [Products] SET [ProductName] = ?, [CategoryID] = ?, [QuantityPerUnit] = ?, [UnitPrice] = ?, [UnitsInStock] = ?, [Discontinued] = ? WHERE [ProductID] = ? AND [ProductName] = ? AND [CategoryID] = ? AND [QuantityPerUnit] = ? AND [UnitPrice] = ? AND [UnitsInStock] = ? AND [Discontinued] = ?">
            </asp:AccessDataSource>
        </div>
	</form>
</body>
</html>
