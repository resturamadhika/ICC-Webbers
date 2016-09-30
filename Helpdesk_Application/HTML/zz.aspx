<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="zz.aspx.vb" Inherits="Helpdesk_Application.zz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default" style="width: 500px; padding: 10px; margin: 10px">
        <div id="Tabs" role="tabpanel">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li><a href="#personal" aria-controls="personal" role="tab" data-toggle="tab">Personal
                </a></li>
                <li><a href="#employment" aria-controls="employment" role="tab" data-toggle="tab">Employment</a></li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content" style="padding-top: 20px">
                <div role="tabpanel" class="tab-pane active" id="personal">
                    This is Personal Information Tab
                </div>
                <div role="tabpanel" class="tab-pane" id="employment">
                    This is Employment Information Tab
                </div>
            </div>
        </div>
        <asp:Button ID="Button1" Text="Submit" runat="server" CssClass="btn btn-primary" />
        <asp:HiddenField ID="TabName" runat="server" />
    </div>

</asp:Content>
