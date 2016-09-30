<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inbox_facebook.aspx.vb" Inherits="Helpdesk_Application.inbox_facebook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Inbox Facebook</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div style="overflow: auto;">
                <dx:ASPxGridView ID="gv_inbox_facebook" runat="server" KeyFieldName="idTabel"
                    DataSourceID="sql_inbox_facebook" Width="100%" Theme="MetropolisBlue">
                    <SettingsPager>
                        <AllButton Text="All">
                        </AllButton>
                        <NextPageButton Text="Next &gt;">
                        </NextPageButton>
                        <PrevPageButton Text="&lt; Prev">
                        </PrevPageButton>
                    </SettingsPager>
                    <SettingsEditing Mode="Inline" />
                    <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true"
                        ShowVerticalScrollBar="false" ShowHorizontalScrollBar="false" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Action" FieldName="UserCreate" VisibleIndex="0"
                            Width="60px" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <a href="utama.aspx?channel=facebook&id=<%# Eval("facebook_ID")%>&account=<%# Eval("facebook_Name")%>">
                                    <img src='img/icon/Text-Edit-icon2.png' /></a>
                            </DataItemTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Account Name" FieldName="facebook_Name"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Message" FieldName="facebook_Message"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Date" FieldName="ddate"></dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="sql_inbox_facebook" runat="server" ConnectionString="<%$ ConnectionStrings:SosmedConnection %>"></asp:SqlDataSource>
            </div>
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
