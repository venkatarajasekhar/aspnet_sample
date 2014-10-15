Public Class SampleRoleProvider
    Inherits RoleProvider

    ''' <summary>
    ''' サンプル・ロールプロバイダ
    ''' </summary>
    ''' <remarks>サポートしないメソッドはNotSupportedException例外をスローする</remarks>

    Private Const COOKIE_ROLENAMES = "RoleNames"

    Public Overrides Sub AddUsersToRoles(ByVal usernames() As String, ByVal roleNames() As String)

        ' ロールはCookieに保存する
        Dim cookie As HttpCookie = New HttpCookie(COOKIE_ROLENAMES)
        With cookie
            .Value = Join(roleNames, ",")
        End With
        HttpContext.Current.Response.SetCookie(cookie)

    End Sub

    Public Overrides Property ApplicationName() As String
        Get
            Throw New NotSupportedException
        End Get
        Set(ByVal value As String)
            Throw New NotSupportedException
        End Set
    End Property

    Public Overrides Sub CreateRole(ByVal roleName As String)
        Throw New NotSupportedException
    End Sub

    Public Overrides Function DeleteRole(ByVal roleName As String, ByVal throwOnPopulatedRole As Boolean) As Boolean
        Throw New NotSupportedException
    End Function

    Public Overrides Function FindUsersInRole(ByVal roleName As String, ByVal usernameToMatch As String) As String()
        Throw New NotSupportedException
    End Function

    Public Overrides Function GetAllRoles() As String()
        Throw New NotSupportedException
    End Function

    Public Overrides Function GetRolesForUser(ByVal username As String) As String()

        ' Cookieからロールを取得する
        Try
            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies(COOKIE_ROLENAMES)
            Return cookie.Value.Split(",")
        Catch ex As Exception
            Dim roleNames() As String = {""}
            Return roleNames
        End Try

    End Function

    Public Overrides Function GetUsersInRole(ByVal roleName As String) As String()
        Throw New NotSupportedException
    End Function

    Public Overrides Function IsUserInRole(ByVal username As String, ByVal roleName As String) As Boolean
        Throw New NotSupportedException
    End Function

    Public Overrides Sub RemoveUsersFromRoles(ByVal usernames() As String, ByVal roleNames() As String)
        Throw New NotSupportedException
    End Sub

    Public Overrides Function RoleExists(ByVal roleName As String) As Boolean
        Throw New NotSupportedException
    End Function

End Class
