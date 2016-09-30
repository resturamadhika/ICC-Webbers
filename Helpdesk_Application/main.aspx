<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="main.aspx.vb" Inherits="Helpdesk_Application.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="HTML/js/jquery-1.10.2.min.js"></script>
    <script src="HTML/bootstrap/js/bootstrap.min.js"></script>
    <link href="HTML/css/endless.min.css" rel="stylesheet" />
    <link href="HTML/css/endless-skin.css" rel="stylesheet" />
    <link href="HTML/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="documentation/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="HTML/css/font-awesome.min.css" rel="stylesheet" />
    <link href="HTML/css/pace.css" rel="stylesheet" />
    <link href="HTML/css/colorbox/colorbox.css" rel="stylesheet" />
    <link href="HTML/css/morris.css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" runat="server" class="form-horizontal form-border">
        <div class="padding-md">
            <div class="row">
                <div class="col-md-4 col-sm-4">
                    <div class="row">
                        <div class="col-xs-6 col-sm-12 col-md-6 text-center">
                            <a href="#">
                                <img src="HTML/img/user.jpg" alt="User Avatar" class="img-thumbnail">
                            </a>
                            <div class="seperator"></div>
                            <div class="seperator"></div>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-6 col-sm-12 col-md-6">
                            <strong class="font-14">
                                <a href="utama.aspx">
                                    <asp:Label ID="lbl_nama" runat="server"></asp:Label></a></strong>
                            <small class="block text-muted">
                                <asp:Label ID="lbl_email" runat="server"></asp:Label>
                            </small>
                            <small class="block text-muted">
                                <asp:Label ID="lbl_tlp" runat="server"></asp:Label>
                            </small>
                            <div class="seperator"></div>
                            <div class="seperator"></div>
                            <%--<div class="seperator"></div>--%>
                            <a href="#" class="social-connect tooltip-test facebook-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Facebook"><i class="fa fa-facebook"></i></a>
                            <a href="#" class="social-connect tooltip-test twitter-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Twitter"><i class="fa fa-twitter"></i></a>
                            <a href="#" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="tooltip" data-original-title="Google Plus"><i class="fa fa-google-plus"></i></a>
                            <a href="#" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="tooltip" data-original-title="Instagram"><i class="fa fa-instagram"></i></a>

                            <div class="seperator"></div>
                        </div>
                        <!-- /.col -->
                    </div>

                    <!-- /.row -->
                    <div class="panel m-top-md">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                    <ul class="nav-notification clearfix" style="list-style: none;">
                                        <li class="dropdown">
                                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                                <i class="fa fa-folder fa-lg" title="History Customer Ticket"></i>
                                                <%--                                                        <span class="label label-info pull-left">History Customer Ticket</span>--%>
                                            </a>
                                            <ul class="dropdown-menu notification dropdown-3">
                                                <li><a href="#">You have 5 last ticket</a></li>
                                                <li>
                                                    <%--                                                    <asp:Literal ID="ltr_history_ticket" runat="server"></asp:Literal>--%>
                                                    <a href="#">
                                                        <span class="notification-icon bg-warning">
                                                            <i class="fa fa-warning"></i>
                                                        </span>
                                                        <span class="m-left-xs">Server #2 not responding.</span>
                                                        <%--  <span class="time text-muted">Just now</span>--%>
                                                    </a>
                                                </li>
                                                <li><a href="#">Close</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                    <div class="form-group">
                                        <div class="col-lg-6  col-sm-6">
                                            <label for="exampleInputEmail1" title="Source Type Atau Channel">Source Type</label>
                                            <dx:ASPxComboBox ID="cmb_source_type" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_source_type" TextField="Name" ValueField="TicketIDCode" CssClass="form-control chzn-select">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="TicketIDCode" FieldName="ID" Width="80px" Visible="false" />
                                                    <dx:ListBoxColumn Caption="Source Name" FieldName="Name" Width="150px" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_source_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <div class="col-lg-6  col-sm-6">
                                            <label for="exampleInputEmail1">Group Type</label>
                                            <dx:ASPxComboBox ID="cmb_group_type" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_group_type" TextField="GroupName" ValueField="GroupCode" CssClass="form-control chzn-select">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="GroupCode" FieldName="GroupCode" Width="80px" Visible="false" />
                                                    <dx:ListBoxColumn Caption="Group Name" FieldName="GroupName" Width="150px" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_group_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12  col-sm-12">
                                            <label for="exampleInputEmail1">Transaction Type</label>
                                            <dx:ASPxComboBox ID="cmb_transaction_type" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_transaction_type" TextField="Name" ValueField="CategoryID" CssClass="form-control chzn-select">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="CategoryID" FieldName="CategoryID" Width="80px" Visible="false" />
                                                    <dx:ListBoxColumn Caption="Transaction Name" FieldName="Name" Width="150px" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_transaction_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>

                                        <!-- /.col -->
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6  col-sm-6">
                                            <label for="exampleInputEmail1">Brand</label>
                                            <dx:ASPxComboBox ID="cmb_brand" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_brand" TextField="SubCategory1Name" ValueType="System.String" CssClass="form-control chzn-select">
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_brand" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <div class="col-lg-6  col-sm-6">
                                            <label for="exampleInputEmail1">Product</label>
                                            <dx:ASPxComboBox ID="cmb_product" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_product" TextField="SubCategory2Name" CssClass="form-control chzn-select">
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_product" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12  col-sm-12">
                                            <label for="exampleInputEmail1">Problem</label>
                                            <dx:ASPxComboBox ID="cmb_problem" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_problem" TextField="SubCategory3Name" CssClass="form-control chzn-select">
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_problem" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6  col-sm-6">
                                            <label for="exampleInputEmail1">Priority</label>
                                            <dx:ASPxComboBox ID="cmb_priority" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_priority" TextField="jenis" ValueField="jenis" CssClass="form-control chzn-select">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="Priority" FieldName="jenis" Width="150px" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_priority" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <div class="col-lg-6  col-sm-6">
                                            <label for="exampleInputEmail1">Severity</label>
                                            <dx:ASPxComboBox ID="cmb_severity" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_severity" TextField="jenis" ValueField="jenis" CssClass="form-control chzn-select">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="Severity" FieldName="jenis" Width="150px" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_severity" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12  col-sm-12">
                                            <label for="exampleInputEmail1">Status</label>
                                            <dx:ASPxComboBox ID="cmb_status" Height="30px" runat="server" Theme="MetropolisBlue"
                                                DataSourceID="sql_status" TextField="status" ValueField="status" CssClass="form-control chzn-select">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="Status" FieldName="status" Width="150px" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="sql_status" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                    </div>
                    <!-- /panel -->
                    <div class="seperator"></div>
                </div>
                <!-- /.col -->
                <div class="col-md-8 col-sm-8">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="overview">
                            <div class="clearfix">
                                <div class="pull-left">
                                    <div class="pull-right m-right-sm">
                                        <h5 class="m-bottom-xs m-top-xs">
                                            <asp:Label ID="lbl_agent" runat="server"></asp:Label></h5>
                                        <span class="text-muted">
                                            <asp:Label ID="lbl_nik_agent" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div class="pull-right">
                                    <h5 class="m-bottom-xs m-top-xs">#Date</h5>
                                    <%--<strong>16 Aug 2016</strong>--%>
                                    <span class="text-muted">
                                        <asp:Label ID="lbl_date_create" runat="server"></asp:Label></span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="btn-group">
                                                <button class="btn btn-default dropdown-toggle" style="height: 30px" data-toggle="dropdown"><span class="caret"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li><a href="utama.aspx">Inbox Ticket</a></li>
                                                    <li><a href="utama.aspx?id=todo">Todolist Ticket</a></li>
                                                    <li class="divider"></li>
                                                    <li><a href="#">Inbox Twitter</a></li>
                                                    <li><a href="#">Inbox Facebook</a></li>
                                                    <li><a href="#">Inbox Instagram</a></li>
                                                    <li class="divider"></li>
                                                    <li><a href="#">Inbox Email</a></li>
                                                    <li><a href="#">Sent Email</a></li>
                                                    <li class="divider"></li>
                                                    <li><a href="#">Inbox Sms</a></li>
                                                    <li><a href="#">Sent Sms</a></li>
                                                    <li class="divider"></li>
                                                    <li><a href="#">Inbox Fax</a></li>
                                                    <li><a href="#">Sent Fax</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <!-- /form-group -->
                                            <div class="form-group" id="div_interaction" runat="server">
                                                <label class="col-lg-2 control-label"></label>
                                                <div class="col-lg-10">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading clearfix">
                                                            <span class="pull-left">History Interaction Agent</span>
                                                            <ul class="tool-bar">
                                                                <%--                                                                <li><a href="#" class="refresh-widget" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Refresh"><i class="fa fa-refresh"></i></a></li>--%>
                                                                <li><a href="#collapseWidget" data-toggle="collapse"><i class="fa fa-arrows-v"></i></a></li>
                                                            </ul>
                                                        </div>
                                                        <div class="panel-body no-padding collapse in" id="collapseWidget">
                                                            <div class="padding-md">
                                                                <table class="table table-hover table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Name</th>
                                                                            <th>Reponse Complaint</th>
                                                                            <th>Date</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Literal runat="server" ID="ltr_interaction"></asp:Literal>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                        <div class="loading-overlay">
                                                            <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                                                        </div>
                                                    </div>
                                                    <!-- /.col -->
                                                    <!-- /.col -->
                                                </div>
                                            </div>
                                            <!-- /form-group -->
                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">Description</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" class="form-control"
                                                        Rows="6" placeholder="Enter your description ..."></asp:TextBox>
                                                </div>
                                                <!-- /.col -->
                                                <!-- /.col -->
                                            </div>
                                            <!-- /form-group -->
                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">WYSIHTML5</label>
                                                <div class="col-lg-10">
                                                    <textarea id="wysihtml5-textarea" placeholder="Enter your text ..." class="form-control" rows="6"></textarea>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!
                                            <!-- /form-group -->
                                            <div class="form-group">
                                                <label class="control-label col-lg-2  col-sm-2"></label>
                                                <div class="row">
                                                    <div class="col-xs-3 text-center">
                                                        <div class="alert alert-info">
                                                            <strong>SLA
                                                                <asp:Label ID="lbl_sla" runat="server"></asp:Label></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.row -->
                                            </div>

                                            <!-- /panel -->
                                            <%-- <div class="form-group">
                                                <label class="control-label col-lg-2  col-sm-2"></label>
                                                <div class="col-lg-4  col-sm-4">
                                                    <asp:Button ID="btn_simpan" runat="server" Text="Simpan" CssClass="btn btn-info" />
                                                </div>
                                                <!-- /.col -->
                                            </div>--%>
                                        </div>
                                    </div>


                                    <!-- /panel -->
                                </div>
                                <!-- /.col -->

                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /tab1 -->

                    </div>
                    <!-- /tab-content -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->



        </div>
    </form>
</body>
</html>
