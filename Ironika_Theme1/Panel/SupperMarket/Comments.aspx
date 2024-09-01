<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/SupperMarket/Site1.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="Ironika_Theme1.Panel.SupperMarket.Comments" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> نظرات/پنل کاربری</title>
    <style>
        .RadToolTip, RadToolTip * {
            top: 25% !important;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_TitlePage" runat="server">
    <li><a href="/">خانه</a> </li>
    <li class="active">نظرات</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_PageName" runat="server">
    <h1>نظرات</h1>
    <small class="subtitle"> مدیریت نظرات</small>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>

        <div class="panel-body">
            <h2 class="mgbt-xs-20">مدیریت نظرات
            </h2>
            <div class="form-horizontal">

                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">وضعیت تایید </label>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:CheckBox runat="server" class="required" Text="تایید کامنت" ID="ChState" />

                            <asp:HiddenField ID="hi_Id" runat="server" />
                           
                           
                        </div>
                    </div>
                    <div class="col-md-6">
                        
                    </div>
                </div>
              
                <div class="form-group">
                    <div class="col-md-12">
                        <div class="label-wrapper">
                            <label class="control-label">متن کامنت </label>
                        </div>
                        <div class="vd_input-wrapper" >
                            <telerik:RadEditor ID="RadEditor_Description" runat="server"
                                CssClass="JustifyRight" Language="fr-FR"
                                SkinID="DefaultSetOfTools" Width="100%">
                                <Content>
                                </Content>
                                <ImageManager
                                    DeletePaths="~/UploadImage" UploadPaths="~/UploadImage"
                                    ViewPaths="~/UploadImage" />
                                <DocumentManager ViewPaths="~/Document" MaxUploadFileSize="150000000"
                                    UploadPaths="~/Document"
                                    DeletePaths="~/Document"></DocumentManager>
                                <FlashManager ViewPaths="~/Felash" MaxUploadFileSize="150000000"
                                    UploadPaths="~/Felash"
                                    DeletePaths="~/Felash" />

                                <MediaManager ViewPaths="~/Media" MaxUploadFileSize="150000000"
                                    UploadPaths="~/Media"
                                    DeletePaths="~/Media" />
                            </telerik:RadEditor>

                            
                        </div>
                    </div>
                    
                </div>
              



                <div class="form-group">

                    <div class="col-md-12 mgbt-xs-5" style="direction: rtl; text-align: center">


                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-green font-semibold" Width="120px" runat="server" ValidationGroup="as_Register" ID="submit_register" OnClick="submit_register_Click" Text="ثبت"></asp:Button>
                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-yellow font-semibold" Width="120px" runat="server" ID="BtnCancel" OnClick="BtnCancel_Click" Text="پاک کردن"></asp:Button>
                        <br />
                        <asp:Literal ID="Literal_Message" runat="server"></asp:Literal>
                        <telerik:RadToolTip ID="RadToolTip_Message" Position="Center" class="PopUpMy" runat="server"></telerik:RadToolTip>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>
        <div class="panel-body" style="direction: rtl; text-align: right">
            <h2 class="mgbt-xs-20">لیست کامنت ها</h2>
            <asp:GridView ID="List_Project" RowStyle-CssClass="GvGrid" runat="server" AllowPaging="True" PageSize="30" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_Project" DataKeyNames="ReviewId" Width="90%" Style="margin-right: 5%; margin-left: 5%" OnSelectedIndexChanged="List_Project_SelectedIndexChanged" GridLines="Horizontal">
                <Columns>
                    <asp:CommandField ButtonType="Link" HeaderStyle-Width="120px" ItemStyle-CssClass="GridBtnDelete" NewText="<i class='icon-edit'></i>jhkjhjkhkj"
                        ShowSelectButton="True">

                        <HeaderStyle Width="80px"></HeaderStyle>

                        <ItemStyle CssClass="btn mini purple"></ItemStyle>
                        <ItemStyle Width="80px" />
                    </asp:CommandField>
                   
                      <asp:TemplateField HeaderText="کاربر">
                        <ItemTemplate>
                            <%# NumberFormat_Register(int.Parse(Eval("UserId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="محصول">
                        <ItemTemplate>
                            <%# NumberFormat_Product(int.Parse(Eval("ProductId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Rating" HeaderText="تعداد ستاره" SortExpression="Rating" />
                   <asp:TemplateField HeaderText="تاریخ ثبت">
                        <ItemTemplate>
                            <%# NumberFormat_Date(DateTime.Parse(Eval("RegisterDate").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                </Columns>
                <HeaderStyle BackColor="#DDDDDD" ForeColor="#666666" HorizontalAlign="right" VerticalAlign="Middle" Height="40px" Font-Bold="True" Font-Size="14px" />
                <RowStyle CssClass="GridItemStyle" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black" Font-Size="14px" Height="35px" />
            </asp:GridView>

            <asp:ObjectDataSource ID="ObjectDataSource_Project" runat="server" EnablePaging="True" SelectMethod="GetProvider"
                SelectCountMethod="GetProvider_Count" TypeName="Ironika_Theme1.Models.Comment_Manager" DeleteMethod="delete" OnSelecting="ObjectDataSource_Project_Selecting" >
                <DeleteParameters>
                    <asp:Parameter Name="ReviewId" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="SupperId" Type="Int32" />
                    <asp:Parameter Name="Text" Type="String" />
                    <asp:Parameter Name="startRowIndex" Type="Int32" />
                    <asp:Parameter Name="maximumRows" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>