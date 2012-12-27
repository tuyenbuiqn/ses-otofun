<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="ListArticles.aspx.cs" Inherits="SES.CMS.ofeditor.ListArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pad20">
            <h2><asp:Label runat="server" ID="lblAction" Text=""></asp:Label>
                </h2>
            <div style="width: 90%; float: left; margin-bottom: 10px;">
                Lựa chọn theo Danh mục:
                </div>
            <div visible="false" runat="server" id="divPV" class="article-action">
                <asp:Button runat="server" ID="btnXoaPV" Text="Xóa bài đã chọn" CssClass="button-article"
                    OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" 
                    onclick="btnXoaPV_Click" />
                <asp:Button runat="server" ID="btnGuiBTV" Text="Gửi Biên tập" CssClass="button-article"
                    
                    OnClientClick="return confirm('Xác nhận gửi Biên tập? Nhấn OK để đồng ý!')" 
                    onclick="btnGuiBTV_Click" />
            </div>
            <div visible="false" runat="server" id="divBTV" class="article-action">
                <asp:Button runat="server" ID="btnXoaBTV" Text="Xóa bài đã chọn" CssClass="button-article"
                    OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" 
                    onclick="btnXoaBTV_Click" />
                <asp:Button runat="server" ID="btnGuiXuatBan" Text="Gửi xuất bản" CssClass="button-article"
                    OnClick="btnGuiXuatBan_Click" OnClientClick="return confirm('Xác nhận gửi xuất bản? Nhấn OK để đồng ý!')" />
                    <asp:Button runat="server" ID="btnTraLaiPhongVien" Text="Trả lại bài cho phóng viên" CssClass="button-article"
                     OnClick="btnTraLaiPhongVien_Click" OnClientClick="return confirm('Xác nhận trả lại bài viết cho phóng viên? Nhấn OK để đồng ý!')"  />
                    <asp:Button runat="server" ID="btnChiuTrachNhiem" Text="Chịu trách nhiệm bài này" CssClass="button-article"
                    OnClick="btnBTVChiuTrachNhiem_Click" OnClientClick="return confirm('Xác nhận chịu trách nhiệm? Nhấn OK để đồng ý!')"  />
            </div>
            <div visible="false" runat="server" id="divTK" class="article-action">
                <asp:Button runat="server" ID="btnXoaTK" Text="Xóa bài đã chọn" CssClass="button-article"
                    OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" 
                    onclick="btnXoaTK_Click" />
                <asp:Button runat="server" ID="btnDuyetXuatBan" Text="Duyệt Xuất bản" CssClass="button-article"
                     
                    OnClientClick="return confirm('Xác nhận Duyệt xuất bản? Nhấn OK để đồng ý!')" 
                    onclick="btnDuyetXuatBan_Click" />
                     <asp:Button runat="server" ID="btnHuyDuyetXB" Text="Gỡ bài" CssClass="button-article"
                     OnClientClick="return confirm('Xác nhận Gỡ bài? Nhấn OK để đồng ý!')" 
                    onclick="btnHuyDuyetXB_Click" />
                       <asp:Button runat="server" ID="btnTKTraPV" 
                    Text="Trả lại bài cho phóng viên" CssClass="button-article"
                    
                    OnClientClick="return confirm('Xác nhận trả lại bài viết cho phóng viên? Nhấn OK để đồng ý!')" 
                    onclick="btnTKTraPV_Click"  />
                    <asp:Button runat="server" ID="btnTraBTV" Text="Trả bài Biên tập lại" CssClass="button-article"
                    
                    OnClientClick="return confirm('Xác nhận trả bài viết cho Biên tập lại? Nhấn OK để đồng ý!')" 
                    onclick="btnTraBTV_Click"  />
            </div>
            

            <asp:GridView ID="grvListArticle" DataKeyNames="ArticleID" runat="server" AutoGenerateColumns="False"
                OnRowDeleting="grvListArticle_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="grvListArticle_SelectedIndexChanged"
                PageSize="35" AllowPaging="true" Width="100%" PagerStyle-CssClass="pgr" 
                OnPageIndexChanging="grvListArticle_PageIndexChanging" 
                OnDataBound="grvListArticle_DataBound" 
                onrowdatabound="grvListArticle_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this);"
                                runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ArticleID" HeaderText="ID" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="5%" Visible="false" />
                    <asp:BoundField DataField="Title" HeaderText="Tiêu đề" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="35%" />
                    <asp:BoundField DataField="Username" HeaderText="Tác giả" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Ngày viết" ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreateDate" Text='<%# (bool)(Eval("CreateDate")==null)==true?"":Eval("CreateDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Ngày gửi biên tập" ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreateDate2" Text='<%# (bool)(Eval("ThoiGianGui")==null)==true?"":Eval("ThoiGianGui","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày gửi xuất bản" ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreateDate3" Text='<%# (bool)(Eval("ThoiGianGuiXuatBan")==null)==true?"":Eval("ThoiGianGuiXuatBan","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Ngày xuất bản" ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreateDate4" Text='<%# (bool)(Eval("ThoiGianXuatBan")==null)==true?"":Eval("ThoiGianXuatBan","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="LuotView" HeaderText="Lượt view" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="10%" />
                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Thao tác"  ItemStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CommandName="Select" ImageUrl="~/ofeditor/images/edit_16x16.gif" />
                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("ArticleID") %>'
                                CommandName="Delete" ImageUrl="~/ofeditor/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
          
            <div style="width: 100%; float: left;">
                <a href="/ofeditor/AddNews.aspx" class="button-gg-green" title="Thêm bài viết">Thêm
                    bài viết</a>
            </div>
    </div>
</asp:Content>
