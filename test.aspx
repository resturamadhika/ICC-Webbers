<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="Helpdesk_Application.test" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Endless Admin</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="documentation/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="HTML/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Pace -->
    <link href="HTML/css/pace.css" rel="stylesheet" />
    <!-- Endless -->
    <link href="HTML/css/endless.min.css" rel="stylesheet" />
    <link href="HTML/css/endless-skin.css" rel="stylesheet" />

    <!-- Gritter -->
    <link href="HTML/css/gritter/jquery.gritter.css" rel="stylesheet" />
    <!-- Google Code Prettify -->
    <link href="HTML/css/prettify.css" rel="stylesheet" />


</head>

<body class="overflow-hidden">
    <!-- Overlay Div -->
    <div id="overlay" class="transparent"></div>
    <div id="wrapper" class="preload">
        <!-- /top-nav-->
        <div id="main-container">
            <div class="padding-md">
                <div class="row">
                    <div class="col-md-6">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Modal
						
                            </div>
                            <div class="panel-body">
                                <a href="#simpleModal" role="button" data-toggle="modal" class="btn btn-primary btn-small">Simple Modal</a>
                                <a href="#formModal" role="button" data-toggle="modal" class="btn btn-danger btn-small">Modal With Form</a>
                                <div class="seperator"></div>
                                <a href="#darkCustomModal" class="btn btn-success btn-small darkCustomModal_open">Dark Custom Modal</a>
                                <a href="#lightCustomModal" class="btn btn-warning btn-small lightCustomModal_open">Light Custom Modal</a>
                            </div>
                        </div>
                        <!-- panel -->
                        <!-- panel -->
                        <!-- /panel -->
                    </div>
                    <!-- /.col -->
                </div>

                <div class="row">
                    <div class="btn-group">
                        <button class="btn btn-default dropdown-toggle" data-toggle="dropdown">Action <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading clearfix">
                                <span class="pull-left">To Do List <span class="text-success m-left-xs"><i class="fa fa-check"></i></span>
                                </span>
                                <ul class="tool-bar">
                                    <li><a href="#" class="refresh-widget" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Refresh"><i class="fa fa-refresh"></i></a></li>
                                    <li><a href="#toDoListWidget" data-toggle="collapse"><i class="fa fa-arrows-v"></i></a></li>
                                </ul>
                            </div>
                            <div class="panel-body no-padding collapse in" id="toDoListWidget">
                                <ul class="list-group task-list no-margin collapse in">
                                    <li class="list-group-item">
                                        <label class="label-checkbox inline">
                                            <input type="checkbox" class="task-finish">
                                            <span class="custom-checkbox"></span>
                                        </label>
                                        Unit Testing
											
                                                <span class="pull-right">
                                                    <a href="#" class="task-del"><i class="fa fa-trash-o fa-lg text-danger"></i></a>
                                                </span>
                                    </li>
                                    <li class="list-group-item">
                                        <label class="label-checkbox inline">
                                            <input type="checkbox" class="task-finish">
                                            <span class="custom-checkbox"></span>
                                        </label>
                                        Mobile Development 
											
                                                <span class="pull-right">
                                                    <a href="#" class="task-del"><i class="fa fa-trash-o fa-lg text-danger"></i></a>
                                                </span>
                                        <span class="badge badge-success m-right-xs">3</span>
                                    </li>
                                </ul>
                                <!-- /list-group -->
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.padding-md -->
        </div>
        <!-- /main-container -->

        <!-- 
        <!--Modal-->
        <div class="modal fade" id="simpleModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4>Modal header</h4>
                    </div>
                    <div class="modal-body">
                        <p>One fine body...</p>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                        <a href="#" class="btn btn-danger btn-sm">Save changes</a>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

        <div class="modal fade" id="formModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4>Register Form</h4>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <label>Username</label>
                                <input type="text" class="form-control input-sm" placeholder="Username">
                            </div>
                            <!-- /form-group -->
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Password</label>
                                        <input type="password" class="form-control input-sm" placeholder="Password">
                                    </div>
                                </div>
                                <!-- /.col -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Confirm Password</label>
                                        <input type="password" class="form-control input-sm" placeholder="Password">
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->


                            <div class="form-group">
                                <label>Email</label>
                                <input type="text" class="form-control input-sm" placeholder="test@example.com">
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="label-checkbox">
                                    <input type="checkbox" class="regular-checkbox" />
                                    <span class="custom-checkbox"></span>
                                    I accept the user agreement.
							
                                </label>
                            </div>
                            <!-- /form-group -->
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                        <a href="#" class="btn btn-danger btn-sm">Submit</a>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>

    <!-- /wrapper -->
</body>

<script src="HTML/js/jquery-1.10.2.min.js"></script>
<!-- Bootstrap -->
<script src="HTML/bootstrap/js/bootstrap.min.js"></script>

<!-- Modernizr -->
<script src="HTML/js/modernizr.min.js"></script>

<!-- Pace -->
<script src="HTML/js/pace.min.js"></script>

<!-- Popup Overlay -->
<script src="HTML/js/jquery.popupoverlay.min.js"></script>

<!-- Slimscroll -->
<script src="HTML/js/jquery.slimscroll.min.js"></script>

<!-- Cookie -->
<script src="HTML/js/jquery.cookie.min.js"></script>

<!-- Endless -->
<script src="HTML/js/endless/endless.js"></script>

<script src="HTML/js/uncompressed/holder.js"></script>
<!-- Gritter -->
<script src="HTML/js/jquery.gritter.min.js"></script>

<!-- Google Code Prettify -->
<script src="HTML/js/uncompressed/run_prettify.js"></script>

</html>


