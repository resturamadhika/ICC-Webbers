<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="add_user.aspx.vb" Inherits="Helpdesk_Application.add_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_calltype_one" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Add User</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;" id="div_ticket" runat="server">
                    <dx:ASPxGridView ID="ASPxGridView1" KeyFieldName="UserId" Width="100%" runat="server" Theme="MetropolisBlue"
                        DataSourceID="sql_add_user" OnRowInserting="ASPxGridView1_RowInserting" SettingsPager-PageSize="10">
                        <SettingsPager>
                            <AllButton Text="All">
                            </AllButton>
                            <NextPageButton Text="Next &gt;">
                            </NextPageButton>
                            <PrevPageButton Text="&lt; Prev">
                            </PrevPageButton>
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />
                        <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowFilterBar="Hidden" ShowVerticalScrollBar="false"
                            VerticalScrollableHeight="150" ShowGroupPanel="false" />
                        <SettingsBehavior ConfirmDelete="true" />
                        <Columns>
                            <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                                ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                                <EditButton Visible="True">
                                    <Image ToolTip="Edit" Url="img/Icon/Text-Edit-icon2.png" />
                                </EditButton>
                                <NewButton Visible="True">
                                    <Image ToolTip="New" Url="img/Icon/Apps-text-editor-icon2.png" />
                                </NewButton>
                                <DeleteButton Visible="True">
                                    <Image ToolTip="Delete" Url="img/Icon/Actions-edit-clear-icon2.png" />
                                </DeleteButton>
                                <CancelButton>
                                    <Image ToolTip="Cancel" Url="img/Icon/cancel1.png">
                                    </Image>
                                </CancelButton>
                                <UpdateButton>
                                    <Image ToolTip="Update" Url="img/Icon/Updated1.png" />
                                </UpdateButton>
                                <CellStyle BackColor="#FFFFD6">
                                </CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption=" User Name  " Width="100px" FieldName="UserName" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Password" Width="100px" FieldName="Password" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Level User" FieldName="LevelUser" VisibleIndex="4"
                                HeaderStyle-HorizontalAlign="Center" Width="50px">
                                <PropertiesComboBox TextField="Name" ValueField="Name" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_level_user">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Level User" FieldName="Name" Width="100px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Division" FieldName="UnitKerja" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center"
                                Width="50px" Settings-AutoFilterCondition="Contains">
                                <PropertiesComboBox TextField="Divisi" ValueField="Divisi" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_unit_kerja">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Divisi" FieldName="Divisi" Width="200px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="NIK" FieldName="NIK" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"
                                Width="50px">
                                <PropertiesComboBox TextField="Description" ValueField="NIK" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_nik">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="NIK" FieldName="NIK" Width="100px" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="100px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="sql_add_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_user_sbg" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_unit_kerja" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_nik" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_level_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
