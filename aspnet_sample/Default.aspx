<%@ Page Title="Default" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="aspnet_sample._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function pageLoad() {
            // 非同期通信開始時と終了時の処理登録
            var manager = Sys.WebForms.PageRequestManager.getInstance();
            manager.add_beginRequest(OnBeginRequest);
            manager.add_endRequest(OnEndRequest);
        }

        // 非同期通信開始
        var currentPostBackElement;
        function OnBeginRequest(sender, args) {
            currentPostBackElement = args.get_postBackElement();
            if (typeof(currentPostBackElement) === "undefined") return;

            // UpdatePanelの中にあるボタンはリセット処理が無くても初期状態に戻る
            if (currentPostBackElement.id === "<%= btnApply1.ClientID %>") {
                $('#<%= btnApply1.ClientID %>').button('loading');
            }

            // UpdatePanelの外にあるボタンはリセット処理が必要
            if (currentPostBackElement.id === "<%= btnApply1AsyncPostBack.ClientID %>") {
                $('#<%= btnApply1AsyncPostBack.ClientID %>').button('loading');
            }
        }

        // 非同期通信終了
        function OnEndRequest(sender, args) {
            if (typeof (currentPostBackElement) === "undefined") return;
            
            // UpdatePanelの外にあるボタンのリセット処理
            if (currentPostBackElement.id === "<%= btnApply1AsyncPostBack.ClientID %>") {
                $('#<%= btnApply1AsyncPostBack.ClientID %>').button('reset');
            }
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
    
    <p>認証されていれば誰でも見れるページ</p>
    <br />
    
    <h3>ListViewとObjectDataSource</h3>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="SampleDAO" SelectMethod="GetData" EnablePaging="True" SelectCountMethod="GetRowCount"></asp:ObjectDataSource>
    
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" GroupItemCount="3">
        <LayoutTemplate>
        
            <table class="table">

                <tr ID="groupPlaceholder" runat="server">
                </tr>

            </table>            
        
        </LayoutTemplate>
        
        <GroupTemplate>
        
             <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                </tr>
             </thead>
            <tbody>
                <tr ID="itemPlaceholder" runat="server">
                </tr>
            </tbody>
        
        </GroupTemplate>
        
        <ItemTemplate>
                <tr>
                    <td><%#Eval("ID")%></td>
                    <td><%#Eval("NAME")%></td>
                </tr>
        </ItemTemplate>
        
    </asp:ListView>

    <div class="row">
        <div class="col-sm-6">
            <div class="pull-left">
                <span class="badge"><asp:Literal ID="lblListViewInfo" runat="server"></asp:Literal></span>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="pull-right">
    
                <div class="btn-group">
                    <asp:DataPager ID="pagDataPager" runat="server" PagedControlID="ListView1" PageSize="6">
                        <Fields>
                            <asp:TemplatePagerField>
                                <PagerTemplate>
                                    <span class="badge" style="margin-right: 5px;"><asp:Literal ID="lblPageInfo" runat="server"></asp:Literal></span>
                                </PagerTemplate>
                            </asp:TemplatePagerField>
                            <asp:NextPreviousPagerField ShowNextPageButton="False" ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="False" />
                            <asp:NumericPagerField NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary" RenderNonBreakingSpacesBetweenControls="False" />
                            <asp:NextPreviousPagerField ShowPreviousPageButton="False" ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            
            </div>

        </div>
    
    </div>
    
    <hr />
    
    <h3>None PostBack</h3>
    <p>IsPostBack = <asp:Literal ID="ltrIsPostBack" runat="server"></asp:Literal></p>
    <p>初期ロード時(IsPostBack = False)の日時：<asp:Literal ID="ltrNonePostBack_DateTime" runat="server"></asp:Literal></p>
    <p>初期ロード時(IsPostBack = False)の日時：<asp:Literal ID="ltrNonePostBackDisabelViewState_DateTime" runat="server" EnableViewState="False"></asp:Literal><br />
       ※ EnableViewState="False"
    </p>
    <br />

    <hr />

    <h3>PostBack</h3>
    <p>ポストバック(IsPostBack = True)での日時更新：<asp:Literal ID="ltrPostBack_DateTime" runat="server"></asp:Literal></p>
    ※一度ポストバックを行うと、以後のブラウザのリロードもIsPostBack = Trueになる。<br />
    <asp:Button ID="btnApply3" runat="server" CssClass="btn btn-primary" meta:resourcekey="btnApply3" /><%--btnApply3に暗黙的なローカル・リソースを適用してボタンのTextプロパティを設定している--%>
    <br />
    
    <br />
    <br />

    <hr />
    
    <div class="well">
        <h3>UpdatePanel 1</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <p>IsPostBack = <asp:Literal ID="ltrIsPostBack1" runat="server"></asp:Literal></p>

            <p>btnApply1.Clickイベントでの日時更新：<asp:Literal ID="ltrPostBack_DateTime1" runat="server"></asp:Literal></p>
            <br />
            <asp:Button ID="btnApply1" runat="server" CssClass="btn btn-primary" Text="btnApply1" /> ←ボタンのローディング中表示あり
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnApply1AsyncPostBack" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:Button ID="btnApply1AsyncPostBack" runat="server" CssClass="btn btn-primary" Text="btnApply1AsyncPostBack" /> ←ボタンのローディング中表示あり
    <br />

    <br />
    <br />

    <hr />
    
    <div class="well">
        <h3>UpdatePanel 2</h3>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <p>IsPostBack = <asp:Literal ID="ltrIsPostBack2" runat="server"></asp:Literal></p>

            <p>btnApply2.Clickイベントでの日時更新：<asp:Literal ID="ltrPostBack_DateTime2" runat="server"></asp:Literal></p>
            <br />
            <asp:Button ID="btnApply2" runat="server" CssClass="btn btn-primary" Text="btnApply2" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />

    </div>

</asp:Content>
