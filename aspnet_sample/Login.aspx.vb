Public Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' ユーザーＩＤにフォーカスをセット
        DirectCast(Login.FindControl("UserName"), TextBox).Focus()

    End Sub

    '' 認証ＯＫ
    Private Sub Login_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login.LoggedIn

        Dim l As System.Web.UI.WebControls.Login = DirectCast(sender, System.Web.UI.WebControls.Login)

        ' ロールプロバイダを自作してロジックでロールを付与することもできる
        ' 例えば、adminで始まるユーザーＩＤの場合はadminロールを付与する
        ' それ以外のユーザーＩＤの場合はuserロールを付与する
        If LCase(l.UserName) Like "admin*" Then
            Dim r As String() = {"admin"}
            Roles.AddUserToRoles(l.UserName, r)
        Else
            Dim r As String() = {"user"}
            Roles.AddUserToRoles(l.UserName, r)
        End If

    End Sub

    '' 認証ＮＧ
    Private Sub Login_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login.LoginError

    End Sub

End Class