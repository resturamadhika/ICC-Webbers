<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="allpostMP.aspx.vb" Inherits="Helpdesk_Application.allpostMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Post Facebook & Twitter</li>
        </ul>
    </div>
    <br />
    <div class="row">
        <!-- /panel -->
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                		Post Something on your wall facebook		
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <textarea class="form-control" rows="6" placeholder="Whats on your mind?"></textarea>
                    </div>
                    <div class="form-group">
                        <div class="text-right m-bottom-md">
                            <button class="btn btn-info">Submit Post</button>
                        </div>
                    </div>
                    <!-- /form-group -->
                </div>
            </div>
        </div>
        <!-- /panel -->
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                   Post Something on your timeline twitter		
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <textarea class="form-control" rows="6" placeholder="What happening?"></textarea>
                    </div>
                    <div class="form-group">
                        <div class="text-right m-bottom-md">
                            <button class="btn btn-info">Submit Post</button>
                        </div>
                    </div>
                    <!-- /form-group -->
                </div>
            </div>
        </div>
        <!-- /.col -->
        <div class="col-md-6">
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</asp:Content>
