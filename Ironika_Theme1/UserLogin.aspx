<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Ironika_Theme1.UserLogin" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>ورود به پنل </title>

    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />


    <!-- Fav and touch icons -->

    <link rel="shortcut icon" href="Content/images/icon.ico" />


    <!-- CSS -->

    <!-- Bootstrap & FontAwesome & Entypo CSS -->
    <link href="Content/AdminTheme/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/AdminTheme/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!--[if IE 7]><link type="text/css" rel="stylesheet" href="css/font-awesome-ie7.min.css"><![endif]-->
    <link href="Content/AdminTheme/css/font-entypo.css" rel="stylesheet" type="text/css" />

    <!-- Fonts CSS -->
    <link href="Content/AdminTheme/css/fonts.css" rel="stylesheet" type="text/css" />

    <!-- Plugin CSS -->
    <link href="Content/AdminTheme/plugins/jquery-ui/jquery-ui.custom.min.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/prettyPhoto-plugin/css/prettyPhoto.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/isotope/css/isotope.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/pnotify/css/jquery.pnotify.css" media="screen" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/google-code-prettify/prettify.css" rel="stylesheet" type="text/css">


    <link href="Content/AdminTheme/plugins/mCustomScrollbar/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/tagsInput/jquery.tagsinput.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/bootstrap-switch/bootstrap-switch.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/bootstrap-timepicker/bootstrap-timepicker.min.css" rel="stylesheet" type="text/css">
    <link href="Content/AdminTheme/plugins/colorpicker/css/colorpicker.css" rel="stylesheet" type="text/css">

    <!-- Specific CSS -->


    <!-- Theme CSS -->
    <link href="Content/AdminTheme/css/theme.min.css" rel="stylesheet" type="text/css">
    <!--[if IE]> <link href="css/ie.css" rel="stylesheet" > <![endif]-->
    <link href="Content/AdminTheme/css/chrome.css" rel="stylesheet" type="text/chrome">
    <!-- chrome only css -->



    <!-- Responsive CSS -->
    <link href="Content/AdminTheme/css/theme-responsive.min.css" rel="stylesheet" type="text/css">




    <!-- Custom CSS -->
    <link href="Content/AdminTheme/custom/custom.css" rel="stylesheet" type="text/css">



    <!-- Head SCRIPTS -->
    <script type="text/javascript" src="Content/AdminTheme/js/modernizr.js"></script>
    <script type="text/javascript" src="Content/AdminTheme/js/mobile-detect.min.js"></script>
    <script type="text/javascript" src="Content/AdminTheme/js/mobile-detect-modernizr.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script type="text/javascript" src="js/html5shiv.js"></script>
      <script type="text/javascript" src="js/respond.min.js"></script>     
    <![endif]-->
</head>
<body id="pages" class="full-layout no-nav-left no-nav-right  nav-top-fixed background-login     responsive remove-navbar login-layout   clearfix" data-active="pages " data-smooth-scrolling="1">
    <form id="form1" runat="server">
        <div class="vd_body">
            <!-- Header Start -->

            <!-- Header Ends -->
            <div class="content">
                <div class="container">

                    <!-- Middle Content Start -->

                    <div class="vd_content-wrapper">
                        <div class="vd_container">
                            <div class="vd_content clearfix">
                                <div class="vd_content-section clearfix">
                                    <div class="vd_login-page">
                                        <div class="heading clearfix">

                                            <h4 class="text-center font-semibold vd_grey">ورود به پنل کاربری</h4>
                                        </div>
                                        <div class="panel widget">
                                            <div class="panel-body">
                                                <div class="login-icon entypo-icon"><i class="icon-key"></i></div>
                                                <div class="form-horizontal" id="login-form">

                                                    <div class="form-group  mgbt-xs-20">
                                                        <div class="col-md-12">
                                                            <div class="label-wrapper sr-only">
                                                                <label class="control-label" for="email">نام کاربری</label>
                                                            </div>
                                                            <div class="vd_input-wrapper" id="email-input-wrapper">
                                                                <span class="menu-icon"><i class="fa fa-envelope"></i></span>
                                                                <asp:TextBox runat="server" placeholder="نام کاربری" ID="txtEmail" class="required"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="نام کاربری را وارد کنید"></asp:RequiredFieldValidator>
                                                            <div class="label-wrapper">
                                                                <label class="control-label sr-only" for="password">کلمه عبور</label>
                                                            </div>
                                                            <div class="vd_input-wrapper" id="password-input-wrapper">
                                                                <span class="menu-icon"><i class="fa fa-lock"></i></span>
                                                                <asp:TextBox runat="server" type="password" placeholder="کلمه عبور" ID="TxtPass" class="required"></asp:TextBox>

                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="کلمه عبور را وارد کنید"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <div class="col-md-12 text-center mgbt-xs-5">
                                                            <asp:Button class="btn vd_bg-green vd_white width-100" OnClick="login_submit_Click1" runat="server" ID="login_submit" ValidationGroup="as_Register" Text="ورود"></asp:Button>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                                <div class="col-xs-6">
                                                                </div>
                                                                <div class="col-xs-6 text-right">
                                                                    <div class="vd_checkbox">
                                                                        <input type="checkbox" id="checkbox-1" value="1">
                                                                        <label for="checkbox-1">مرا به خاطر بسپار</label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Panel Widget -->
                                        <div class="register-panel text-center font-semibold">
                                            <asp:Literal ID="ls_Message" runat="server"></asp:Literal></div>
                                    </div>
                                    <!-- vd_login-page -->

                                </div>
                                <!-- .vd_content-section -->

                            </div>
                            <!-- .vd_content -->
                        </div>
                        <!-- .vd_container -->
                    </div>
                    <!-- .vd_content-wrapper -->

                    <!-- Middle Content End -->

                </div>
                <!-- .container -->
            </div>
            <!-- .content -->

            <!-- Footer Start -->
            <footer class="footer-2" id="footer">
                <div class="vd_bottom ">
                    <div class="container">
                        <div class="row">
                            <div class=" col-xs-12">
                                <div class="copyright text-center">
                                    Copyright &copy;2014 Venmond Inc. All Rights Reserved 
                                </div>
                            </div>
                        </div>
                        <!-- row -->
                    </div>
                    <!-- container -->
                </div>
            </footer>
            <!-- Footer END -->

        </div>

        <!-- .vd_body END  -->
        <a id="back-top" href="#" data-action="backtop" class="vd_back-top visible"><i class="fa  fa-angle-up"></i></a>
        <!--
<a class="back-top" href="#" id="back-top"> <i class="icon-chevron-up icon-white"> </i> </a> -->

        <!-- Javascript =============================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script type="text/javascript" src="Content/AdminTheme/js/jquery.js"></script>
        <!--[if lt IE 9]>
  <script type="text/javascript" src="js/excanvas.js"></script>      
<![endif]-->
        <script type="text/javascript" src="Content/AdminTheme/js/bootstrap.min.js"></script>
        <script type="text/javascript" src='Content/AdminTheme/plugins/jquery-ui/jquery-ui.custom.min.js'></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js"></script>

        <script type="text/javascript" src="Content/AdminTheme/js/caroufredsel.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/js/plugins.js"></script>

        <script type="text/javascript" src="Content/AdminTheme/plugins/breakpoints/breakpoints.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/dataTables/jquery.dataTables.min.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/prettyPhoto-plugin/js/jquery.prettyPhoto.js"></script>

        <script type="text/javascript" src="Content/AdminTheme/plugins/mCustomScrollbar/jquery.mCustomScrollbar.concat.min.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/tagsInput/jquery.tagsinput.min.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/bootstrap-switch/bootstrap-switch.min.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/blockUI/jquery.blockUI.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/plugins/pnotify/js/jquery.pnotify.min.js"></script>

        <script type="text/javascript" src="Content/AdminTheme/js/theme.js"></script>
        <script type="text/javascript" src="Content/AdminTheme/custom/custom.js"></script>
        <script src="js/jquery.validate.js"></script>

        
        <script src="js/jquery.validate.min.js"></script>
        <script src="js/jquery.validate.unobtrusive.js"></script>
        <script src="js/jquery.validate.unobtrusive.min.js"></script>
        
    </form>
</body>
</html>

