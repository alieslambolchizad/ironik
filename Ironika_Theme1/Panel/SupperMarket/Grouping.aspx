<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/SupperMarket/Site1.Master" AutoEventWireup="true" CodeBehind="Grouping.aspx.cs" Inherits="Ironika_Theme1.Panel.SupperMarket.Grouping" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>دسته ها/پنل کاربری</title>
    <style>
        .RadToolTip, RadToolTip * {
            top: 25% !important;
        }

        #ctl00_ContentPlaceHolder_Body_TxtPrice {
            font-family: webyekan !important;
            height: 30px !important;
            padding: 4px 6px !important;
            width: 220px !important;
        }

        html body .RadInput_Default .riTextBox, html body .RadInputMgr_Default {
            background-color: #E5E5E5 !important;
            border: 0px !important;
        }

        .RadUpload .ruFileWrap {
            height: 46px !important;
        }

        .RadUpload_Default .ruButton {
            display: none !important;
        }

        .RadUpload .ruBrowse {
            background-position: unset !important;
            width: 100px !important;
        }

        .RadUpload input.ruFileInput {
            font: 20px monospace !important;
        }

        .RadUpload .ruStyled .ruFileInput {
            opacity: 1 !important;
        }

        .RadAsyncUpload span.ruFileWrap {
            width: 100% !important;
        }

        .RadUpload .ruFakeInput {
            height: 30px !important;
            border: 0px !important;
            background-color: #E5E5E5 !important;
        }

        .RadUpload_Default .ruStyled .ruFileInput {
            border: 0px !important;
        }

        .RadUpload {
            width: 100% !important;
        }

        .RadUpload_Default .ruDropZone, .RadUpload_Default_rtl .ruDropZone {
            color: #000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_TitlePage" runat="server">
    <li><a href="/">خانه</a> </li>
    <li class="active">لیست دسته ها</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_PageName" runat="server">
    <h1>لیست دسته ها</h1>
    <small class="subtitle">مدیریت دسته ها</small>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>

        <div class="panel-body">
            <h2 class="mgbt-xs-20">مدیریت دسته ها
            </h2>
            <div class="form-horizontal">

                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">گروه اصلی <span class="vd_red">*</span></label>
                        </div>
                        <div class="vd_input-wrapper" id="first-name-input-wrapper">
                            <asp:DropDownList runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpBig_SelectedIndexChanged" class="required" OnDataBound="DrpBig_DataBound" DataSourceID="ObjectDataSource_Big" DataTextField="Name" DataValueField="GroupId" ID="DrpBig"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource_Big" runat="server" SelectMethod="GetProvider_Big" TypeName="Ironika_Theme1.Models.Grouping_Manager"></asp:ObjectDataSource>
                            <asp:HiddenField ID="hi_Id" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">گروه میانی <span class="vd_red">*</span></label>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:DropDownList runat="server" AutoPostBack="True" class="required" OnSelectedIndexChanged="DrpParent_SelectedIndexChanged" OnDataBound="DrpParent_DataBound" DataSourceID="ObjectDataSource_Parent" DataTextField="Name" DataValueField="GroupId" ID="DrpParent"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource_Parent" OnSelecting="ObjectDataSource_Parent_Selecting" runat="server" SelectMethod="GetProvider_Node" TypeName="Ironika_Theme1.Models.Grouping_Manager">
                                <SelectParameters>
                                    <asp:Parameter Name="Parent" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">گروه محصول<span class="vd_red">*</span></label>
                        </div>
                        <div class="vd_input-wrapper" id="company-input-wrapper">
                            <asp:DropDownList runat="server" class="required"  OnDataBound="DrpGroup_DataBound" DataTextField="Name" DataValueField="GroupId"  DataSourceID="ObjectDataSource_Group" ID="DrpGroup"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource_Group" OnSelecting="ObjectDataSource_Group_Selecting" runat="server" SelectMethod="GetProvider_Node" TypeName="Ironika_Theme1.Models.Grouping_Manager">
                                <SelectParameters>
                                    <asp:Parameter Name="Parent" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            
                        </div>
                    </div>
                    <div class="col-md-6">
                      
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
            <h2 class="mgbt-xs-20">مدیریت لیست دسته ها</h2>
            <asp:GridView ID="List_Project" RowStyle-CssClass="GvGrid" runat="server" AllowPaging="True" PageSize="30" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_Project" DataKeyNames="OwnerGroupId" Width="90%" Style="margin-right: 5%; margin-left: 5%" GridLines="Horizontal" OnSelectedIndexChanged="List_Project_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Link" HeaderStyle-Width="120px" ItemStyle-CssClass="GridBtnDelete" NewText="<i class='icon-edit'></i>jhkjhjkhkj"
                        ShowSelectButton="True">

                        <HeaderStyle Width="80px"></HeaderStyle>

                        <ItemStyle CssClass="btn mini purple"></ItemStyle>
                        <ItemStyle Width="80px" />
                    </asp:CommandField>
                    <asp:TemplateField HeaderText="گروه اصلی">
                        <ItemTemplate>
                            <%# NumberFormat_Big(int.Parse(Eval("GroupId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="گروه میانی">
                        <ItemTemplate>
                            <%# NumberFormat_Parent(int.Parse(Eval("GroupId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="گروه محصول">
                        <ItemTemplate>
                            <%# NumberFormat_Group(int.Parse(Eval("GroupId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     
                    <asp:TemplateField>
                        <ItemTemplate>
                            <center>    
                         <asp:LinkButton id="BtnDelete" style="width:30px" cssclass="GridBtnDelete" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="javascript:return confirm('Do deletions occur?');" runat="server" ><i class="icon-trash"></i></asp:LinkButton>
                       </center>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>


                   


                </Columns>
                <HeaderStyle BackColor="#DDDDDD" ForeColor="#666666" HorizontalAlign="right" VerticalAlign="Middle" Height="40px" Font-Bold="True" Font-Size="14px" />
                <RowStyle CssClass="GridItemStyle" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black" Font-Size="14px" Height="35px" />
            </asp:GridView>

            <asp:ObjectDataSource ID="ObjectDataSource_Project" runat="server" EnablePaging="True" SelectMethod="GetProvider"
                SelectCountMethod="GetProvider_Count" TypeName="Ironika_Theme1.Models.Grouping_Manager" DeleteMethod="delete" OnSelecting="ObjectDataSource_Project_Selecting">
                <DeleteParameters>
                    <asp:Parameter Name="OwnerGroupId" Type="Int32" />
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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>


            <telerik:AjaxSetting AjaxControlID="DrpBig">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="DrpParent" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="DrpParent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="DrpGroup" LoadingPanelID="RadAjaxLoadingPanel1" />

                </UpdatedControls>
            </telerik:AjaxSetting>
            
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>


