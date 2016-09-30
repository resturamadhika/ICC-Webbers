<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="twitter_keyword.aspx.vb" Inherits="Helpdesk_Application.twitter_keyword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
   <script type="text/javascript">
       $(function () {
           var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "wizardContent1";
           $('#Tabs a[href="#' + tabName + '"]').tab('show');
           $("#Tabs a").click(function () {
               $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
           });

       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:HiddenField ID="hfTab" runat="server" />
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Twitter Keyword Setting</li>
        </ul>
    </div>
    <br />
    <div class="panel panel-default" id="Tabs">
        <div class="panel-tab">
            <ul class="wizard-steps wizard-demo" id="wizardDemo1">
                <li id="wizz1" class="active" runat="server">
                    <a href="#wizardContent1" data-toggle="tab">Universal Keyword</a>
                </li>
                <li id="wizz2" runat="server">
                    <a href="#wizardContent2" data-toggle="tab">Spesifikasi Keyword</a>
                </li>
            </ul>
        </div>

        <div class="panel-body">
            <div class="tab-content">
                <div class="tab-pane fade in active" id="wizardContent1">
                    <div class="row" id="as" runat="server">
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
                                </div>
                                <div class="panel-footer text-right">
                                     <asp:Button ID="Button1" runat="server" Text="zz" CssClass="btn btn-info"  />
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
                </div>
                <div class="tab-pane fade" id="wizardContent2">
                    <div class="row" id="x" runat="server">
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
                                    <asp:Button ID="btn_submit" runat="server" Text="Submitx" CssClass="btn btn-info"  />
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
                </div>
            </div>           
        </div>
    </div>
    <!-- /panel -->
</asp:Content>
