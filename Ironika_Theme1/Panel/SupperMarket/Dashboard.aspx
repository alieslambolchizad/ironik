<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/SupperMarket/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Ironika_Theme1.Panel.SupperMarket.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>پنل کاربری/داشبورد</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_TitlePage" runat="server">
    <li><a href="/">خانه</a> </li>
    <li class="active">داشبورد</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_PageName" runat="server">
    <h1>داشبورد</h1>
    <small class="subtitle">دسترسی سریع</small>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="row">

        <div class="col-lg-4 col-md-6 col-sm-6 mgbt-sm-15">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="vd_status-widget vd_bg-red widget">
                    <a class="panel-body" href="AllOrder.aspx">
                        <div class="clearfix">
                            <span class="menu-icon">
                                <i class="icon-cart"></i>
                            </span>
                            <span class="menu-value" id="DivDay_Order" runat="server">
                            </span>
                        </div>
                        <div class="menu-text clearfix">
                          فروش امروز
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-6 mgbt-xs-15">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="vd_status-widget vd_bg-googleplus widget">
                    <a class="panel-body" href="AllOrder.aspx">
                        <div class="clearfix">
                            <span class="menu-icon">
                                <i class="icon-cart"></i>
                            </span>
                            <span class="menu-value" id="DivWeek_Order" runat="server">
                            </span>
                        </div>
                        <div class="menu-text clearfix">
                           فروش این هفته
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-6 mgbt-xs-15">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="vd_status-widget vd_bg-yellow widget">
                    <a class="panel-body" href="AllOrder.aspx">
                        <div class="clearfix">
                            <span class="menu-icon">
                                <i class="icon-cart"></i>
                            </span>
                            <span class="menu-value" id="DivAll_Order" runat="server">
                            </span>
                        </div>
                        <div class="menu-text clearfix">
                            فروش کل
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>

    </div>
    <div class="row">

        <div class="col-lg-4 col-md-6 col-sm-6 mgbt-sm-15">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="vd_status-widget vd_bg-soft-yellow widget">                   
                    <a class="panel-body" href="Product.aspx">
                        <div class="clearfix">
                            <span class="menu-icon">
                                <i class="fa fa-plus-square-o"></i>
                            </span>
                            <span class="menu-value" >
                            </span>
                        </div>
                        <div class="menu-text clearfix">
                            محصولات
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-6 mgbt-xs-15">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="vd_status-widget vd_bg-twitter widget">                   
                    <a class="panel-body" href="Grouping.aspx">
                        <div class="clearfix">
                            <span class="menu-icon">
                                <i class="fa  fa-folder-open-o"></i>
                            </span>
                            <span class="menu-value">
                            </span>
                        </div>
                        <div class="menu-text clearfix">
                          دسته ها
                        </div>
                    </a>
                </div>
            </div>
        <div class="col-md-2"></div>
    </div>
    <div class="col-lg-4 col-md-6 col-sm-6 mgbt-xs-15">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="vd_status-widget vd_bg-dark-red widget">               
                <a class="panel-body" href="OrderFilter.aspx">
                    <div class="clearfix">
                        <span class="menu-icon">
                            <i class="icon-cart"></i>
                        </span>
                        <span class="menu-value">
                        </span>
                    </div>
                    <div class="menu-text clearfix">
                     گزارش فروش
                    </div>
                </a>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
    </div>
</asp:Content>


