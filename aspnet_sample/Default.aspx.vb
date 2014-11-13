Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ltrIsPostBack.Text = IsPostBack

        If Not IsPostBack Then
            ltrNonePostBack_DateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
            ltrNonePostBackDisabelViewState_DateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Else
            ltrPostBack_DateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        End If

    End Sub

    ' UpdatePanel1の中にあるボタン
    Private Sub btnApply1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply1.Click

        ltrPostBack_DateTime1.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        ltrIsPostBack1.Text = IsPostBack

        System.Threading.Thread.Sleep(1000)
    End Sub

    ' UpdatePanel1の外にあるボタン(UpdatePanel1のAsyncPostBackTriggerに指定されている)
    Private Sub btnApply1AsyncPostBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply1AsyncPostBack.Click

        ltrPostBack_DateTime1.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        ltrIsPostBack1.Text = IsPostBack

        System.Threading.Thread.Sleep(1000)
    End Sub

    ' UpdatePanel2の中にあるボタン
    Private Sub btnApply2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply2.Click

        ltrPostBack_DateTime2.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        ltrIsPostBack2.Text = IsPostBack

        System.Threading.Thread.Sleep(1000)
    End Sub

    Private Sub pagDataPager_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles pagDataPager.PreRender

        Dim p As DataPager = DirectCast(sender, DataPager)

        ' DataPager+Extension.vbに定義した拡張メソッドを呼び出して
        ' DataPagerの情報を表示する

        ' 「全データ数]を表示する(
        lblListViewInfo.Text = p.TotalRowCount


        ' DataPagerの中にあるTemplatePagerField内のコントロールを検索する
        Dim lblPageInfo As Literal = p.FindControlInTemplatePagerField("lblPageInfo")

        ' [現在のページ数 / 総ページ数]を表示する
        If p.TotalRowCount > 0 Then
            lblPageInfo.Text = p.CurrentPageNo & " / " & p.PageCount
        Else
            lblPageInfo.Text = "No Data Found"
        End If
        lblPageInfo.Text = p.TotalRowCount

    End Sub

End Class