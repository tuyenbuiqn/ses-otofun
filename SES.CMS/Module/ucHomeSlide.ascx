<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHomeSlide.ascx.cs"
    Inherits="SES.CMS.Module.ucHomeSlide" %>
<div class="cpslide">
    <div class="wt-rotator">
        <a href="/Default.aspx"></a>
        <div class="desc">
        </div>
        <div class="preloader">
        </div>
        <div class="c-panel">
            <div class="buttons">
                <div class="prev-btn">
                </div>
                <div class="play-btn" style="display:none;">
                </div>
                <div class="next-btn">
                </div>
            </div>
            <div class="thumbnails">
                <ul>
                    <asp:Repeater ID="rptSlide" runat="server">
                        <ItemTemplate>
                            <li><a href='/Media/<%#Eval("SlideImg") %>' title='<%#Eval("Title") %>' /><a href='<%#Eval("SlideUrl") %>'>
                            </a>
                                <div style="height: 40px; width: 455px;">
                                    <span class="cap-title"><a href="<%#Eval("SlideUrl") %>">
                                        <%#Eval("Title") %>
                                    </a></span>
                                    <br />
                                    <%#Eval("Description")%>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</div>
