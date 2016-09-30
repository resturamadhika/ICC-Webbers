<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inputsentimenMP.aspx.vb" Inherits="Helpdesk_Application.inputsentimenMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Twitter Sentiment Setting</li>
        </ul>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Input your Sentimen Data
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label class="control-label">Sentimen</label>
                        <input type="text" placeholder="Sentimen" class="form-control input-sm" data-required="true" data-minlength="8">
                    </div>
                    <!-- /form-group -->

                    <div class="form-group">
                        <label class="control-label">Description</label>
                        <input type="text" placeholder="Description" class="form-control input-sm" data-required="true" data-minlength="8">
                    </div>
                    <!-- /.row -->
                </div>
                <div class="panel-footer text-right">
                    <button type="submit" class="btn btn-info">Submit</button>
                </div>
            </div>
            <!-- /panel -->
        </div>
        <!-- /.col-->
        <div class="col-md-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Data Sentimen
                </div>
                <div class="panel-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Channel</th>
                                <th style="width: 85px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email">01</a>
                                </td>
                                <td>Twitter
										</td>
                                <td>10-08-16
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email">02</a>
                                </td>
                                <td>Twitter
										</td>
                                <td>10-07-16
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email">03</a>
                                </td>
                                <td>Facebook
										</td>
                                <td>03-07-16
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email">04</a>
                                </td>
                                <td>Email
										</td>
                                <td>09-06-16
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email">05</a>
                                </td>
                                <td>Voice
										</td>
                                <td>17-05-16
										</td>

                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
            <!-- /panel -->
        </div>
        <!-- /.col-->
    </div>
</asp:Content>
