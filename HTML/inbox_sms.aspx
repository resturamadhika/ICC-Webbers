<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inbox_sms.aspx.vb" Inherits="Helpdesk_Application.inbox_sms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Inbox Sms</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <table class="table table-striped" id="dataTable">
                <thead>
                    <tr>
                        <%--  <th style="width: 50px;">Action</th>--%>
                        <th>Nomor</th>
                        <th>Message</th>
                        <th style="width: 150px;">Date</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="ltr_twitter" runat="server"></asp:Literal>
                </tbody>
            </table>
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
