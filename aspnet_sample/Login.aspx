<%@ Page Title="Login" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="aspnet_sample.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-8 col-sm-offset-2" >

            <!-- フォーム認証 -->
            <asp:Login ID="Login" runat="server" CssClass="col-xs-12">
            
                <%--ログインボタンを押すと、Web.configで定義したSampleMembershipProviderが自動的に呼ばれます--%>
            
                <LayoutTemplate>
                    <asp:Panel ID="PnlLogin" Height="100%" runat="server" DefaultButton="LoginButton" CssClass="form-horizontal">
                
                        <div class="form-group has-feedback">
                            <label for="<%= Login.FindControl("UserName").ClientID %>" class="control-label col-sm-3"><%=GetLocalResourceObject("strUserId")%></label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ValidationGroup="LoginUserValidationGroup" Display="Dynamic" CssClass="has-error" ForeColor="" SetFocusOnError="True"><span class="glyphicon glyphicon-remove form-control-feedback"></span></asp:RequiredFieldValidator>
                            </div>
                        </div>    
                        
                        <div class="form-group has-feedback">
                            <label for="<%= Login.FindControl("Password").ClientID %>" class="control-label col-sm-3"><%=GetLocalResourceObject("strPassword")%></label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ValidationGroup="LoginUserValidationGroup" Display="Dynamic" CssClass="has-error" ForeColor="" SetFocusOnError="True"><span class="glyphicon glyphicon-remove form-control-feedback"></span></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <div class="col-sm-9 col-sm-offset-3 col-sm-pull-1">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="form-control col-sm-offset-1 col-sm-10 btn btn-primary" ValidationGroup="LoginUserValidationGroup" Text="Login" />
                        </div>

                    </asp:Panel>
                </LayoutTemplate>
            </asp:Login>

        </div>
    </div>
    
</asp:Content>
