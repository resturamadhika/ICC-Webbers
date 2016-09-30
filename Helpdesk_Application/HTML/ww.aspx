<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="ww.aspx.vb" Inherits="Helpdesk_Application.ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script type="text/javascript">
        // <![CDATA[
        function grid_SelectionChanged(s, e) {
            s.GetSelectedFieldValues("Name", GetSelectedFieldValuesCallback);
        }
        function GetSelectedFieldValuesCallback(values) {
            selList.BeginUpdate();
            try {
                selList.ClearItems();
                for (var i = 0; i < values.length; i++) {
                    selList.AddItem(values[i]);
                    //var array = values[i];
                    //alert(array)
                }
            } finally {
                selList.EndUpdate();
            }
            document.getElementById("selCount").innerHTML = array[0];
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="dd" runat="server" />
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="panel-heading">
                        <a href="#formModal" role="button" data-toggle="modal" class="btn btn-danger btn-small">Add Data</a>
                    </div>
                    <br />
                    <div style="float: left; width: 20%">
                        <div class="BottomPadding">
                            Selected values:
                        </div>
                        <dx:ASPxListBox ID="ASPxListBox1" ClientInstanceName="selList" runat="server" Height="250px"
                            Width="100%" />
                        <div class="TopPadding">
                            Selected count: <span id="selCount" style="font-weight: bold">0</span>
                        </div>
                    </div>
                    <p id="demo"></p>


                    <button onclick="myFunction()">Try it</button>
     
                    <div style="float: right; width: 78%">
                        <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" DataSourceID="sql_source"
                            KeyFieldName="TypeID"
                            Width="100%">
                            <Columns>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataColumn FieldName="TypeID" VisibleIndex="1" />
                                <dx:GridViewDataColumn FieldName="Name" VisibleIndex="2" />
                            </Columns>
                            <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
                        </dx:ASPxGridView>
                        <dx:ASPxButton ID="btn" Text="test" runat="server"></dx:ASPxButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sql_source" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
</asp:Content>
