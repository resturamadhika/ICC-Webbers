<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Helpdesk_Application.login1" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="documentation/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="HTML/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="HTML/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Endless -->
    <link href="HTML/css/endless.min.css" rel="stylesheet" />
</head>

<body>
    <form runat="server">
        <div class="login-wrapper">
            <div class="text-center">
                <h2 class="fadeInUp animation-delay8" style="font-weight: bold">
                    <span class="text-info">Invision</span> <span style="color: #ccc; text-shadow: 0 1px #fff">Helpdesk</span>
                </h2>
            </div>
            <div class="login-widget animation-delay1">
                <div class="panel panel-default">
                    <div class="panel-heading clearfix">
                        <div class="pull-left">
                            <i class="fa fa-lock fa-lg"></i>&nbsp;Login
				
                        </div>

                        <%--<div class="pull-right">
                        <span style="font-size: 11px;">Don't have any account?</span>
                        <a class="btn btn-default btn-xs login-link" href="register.html" style="margin-top: -2px;"><i class="fa fa-plus-circle"></i>Sign up</a>
                    </div>--%>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label>Username</label>
                            <%--                            <input type="text" placeholder="Username" class="form-control input-sm bounceIn animation-delay2">--%>
                            <asp:TextBox ID="txt_username" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <%--                            <input type="password" placeholder="Password" class="form-control input-sm bounceIn animation-delay4">--%>
                            <asp:TextBox ID="txt_password" runat="server" CssClass="form-control input-sm bounceIn animation-delay4"></asp:TextBox>
                        </div>
                        <div class="seperator"></div>
						<div class="form-group">
							Forgot your password?<br/>
							Click <a href="#">here</a> to reset your password
						</div>
                        <div class="panel-footer text-right">
                            <asp:Button ID="btn_login" runat="server" Text="Sign in" CssClass="btn btn-info pull-right" />
                        </div>
                        
                    </div>
                </div>
                <!-- /panel -->
            </div>
            <!-- /login-widget -->
        </div>
    </form>

    <!-- /login-wrapper -->

    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="HTML/js/jquery-1.10.2.min.js"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
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
</body>
</html>
