<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="SES.CMS.ofeditor.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .change-password-box
        {
            float: left;
            width: 100%;
        }
        .change-password-left
        {
            float: left;
            width: 350px;
            margin-left: 50px;
        }
        .change-password-left h2
        {
            color: #dd4b39;
            font-size: 16px;
            font-weight: normal;
            line-height: 24px;
            margin: 0 0 .46em;
        }
        .change-password-left span
        {
            font-size: 12px;
            line-height: 18px;
        }
        .content-password
        {
        }
        .change-password-right
        {
            float: left;
            width: 260px;
            margin: 10px;
            border: 1px solid #ccc;
            padding: 10px 20px;
            background: #f5f5f5;
        }
        .change-password-right p
        {
            font-size: 13px;
            font-weight: bold;
            margin-bottom: 10px;
            width: 100%;
            float: left;
            margin-top: 5px;
        }
        .password-input
        {
            display: inline-block;
            height: 29px;
            margin: 0;
            padding: 0 8px;
            background: #fff;
            border: 1px solid #d9d9d9;
            border-top: 1px solid #c0c0c0;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            width: 250px;
            outline: none;
        }
        .gg-button
        {
            border: 1px solid #3079ed;
            color: #fff;
            text-shadow: 0 1px rgba(0,0,0,0.1);
            background-color: #4d90fe;
            background-image: -webkit-gradient(linear,left top,left bottom,from(#4d90fe),to(#4787ed));
            background-image: -webkit-linear-gradient(top,#4d90fe,#4787ed);
            background-image: -moz-linear-gradient(top,#4d90fe,#4787ed);
            background-image: -ms-linear-gradient(top,#4d90fe,#4787ed);
            background-image: -o-linear-gradient(top,#4d90fe,#4787ed);
            background-image: linear-gradient(top,#4d90fe,#4787ed);
            cursor:pointer;
            padding:5px 10px;
        }
        .password-row
        {
            float: left;
            width: 100%;
        }
        .changepassword-button
        {
            float: left;
            width: 100%;
            margin: 10px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="change-password-box">
        <div class="change-password-left">
            <h2>
                Đổi mật khẩu</h2>
            <span class="content-password">Đổi mật khẩu cho tài khoản
                <asp:Label runat="server" ID="lblTaiKhoan" Style="font-weight: bold;"></asp:Label><br />
                Để đổi mật khẩu bạn vui lòng nhập mật khẩu cũ
                <br />
                Sau đó điền mật khẩu mới và xác nhận lại mật khẩu mới </span>
        </div>
        <div class="change-password-right">
            <div class="change-password">
                <p>
                    Mật khẩu hiện tại *</p>
                <div class="password-row">
                    <asp:TextBox runat="server" ID="txtOldPassword" CssClass="password-input" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ValidationGroup="group1" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator>
                </div>
                <p>
                    Mật khẩu mới *</p>
                <div class="password-row">
                    <asp:TextBox runat="server" ID="txtNewPassword" CssClass="password-input" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ValidationGroup="group1" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                </div>
                <p>
                    Nhập lại mật khẩu mới *</p>
                <div class="password-row">
                    <asp:TextBox runat="server" ID="txtReNewPassword" CssClass="password-input" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ValidationGroup="group1" ControlToValidate="txtReNewPassword"></asp:RequiredFieldValidator><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu nhập lại chưa đúng"
                        ControlToValidate="txtReNewPassword" ControlToCompare="txtNewPassword"></asp:CompareValidator>
                </div>
                <div class="changepassword-button">
                    <asp:Button runat="server" ID="btnChange" ValidationGroup="group1" Text="Đổi mật khẩu"
                        CssClass="gg-button" onclick="btnChange_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
