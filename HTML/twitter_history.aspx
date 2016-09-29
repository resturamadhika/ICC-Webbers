<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="twitter_history.aspx.vb" Inherits="Helpdesk_Application.twitter_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-3">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="panel-heading">
                        Data Masuk
                    </div>
                    <br />
                    <table class="table table-striped" id="responsiveTable">
                        <thead>
                            <tr>
                                <th style="width: 50px;">Action</th>
                                <th style="width: 200px;">From</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                    <!-- /panel -->

                </div>
            </div>
        </div>
        <!-- /.col -->
        <div class="col-sm-9">
            <div class="tab-content">
                <div class="panel panel-default table-responsive">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-comment"></i>&nbsp; Interaction Twitter
										<div class="btn-group pull-right">
                                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                <i class="fa fa-chevron-down"></i>
                                            </button>
                                            <ul class="dropdown-menu slidedown">
                                                <li><a href="#"><i class="fa fa-refresh"></i>Refresh</a></li>
                                                <li><a href="#"><i class="fa fa-check-circle"></i>Available</a></li>
                                                <li><a href="#"><i class="fa fa-times-circle"></i>Busy</a></li>
                                                <li><a href="#"><i class="fa fa-clock-o"></i>Away</a></li>
                                                <li><a href="#"><i class="fa fa-sign-out"></i>Disconnect</a></li>
                                            </ul>
                                        </div>
                        </div>
                        <div class="panel-body">
                            <div id="chatScroll">
                                <ul class="chat">
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="img/user.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">John Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>12 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                            </p>
                                        </div>
                                    </li>
                                    <li class="right clearfix">
                                        <span class="chat-img pull-right">
                                            <img src="img/user2.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">Jane Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>13 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales at. 
                                            </p>
                                        </div>
                                    </li>
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="img/user.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">John Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>20 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                            </p>
                                        </div>
                                    </li>
                                    <li class="right clearfix">
                                        <span class="chat-img pull-right">
                                            <img src="img/user2.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">Jane Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>25 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales at. 
                                            </p>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="input-group">
                                <input id="btn-input" type="text" class="form-control input-sm" placeholder="type your message here...">
                                <span class="input-group-btn">
                                    <button class="btn btn-warning btn-sm" id="btn-chat">Send</button>
                                </span>
                            </div>
                            <!-- /input-group -->
                        </div>
                    </div>
                    <!-- /panel -->
                </div>

            </div>
            <!-- /panel -->
        </div>
        <!-- /.col -->
    </div>

</asp:Content>
