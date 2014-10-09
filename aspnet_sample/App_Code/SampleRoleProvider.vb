Public Class SampleRoleProvider
    Inherits RoleProvider

    ''' <summary>
    ''' サンプル・ロールプロバイダ
    ''' </summary>
    ''' <remarks>サポートしないメソッドはNotSupportedException例外をスローする</remarks>

    Private mRoleNames() As String

    Public Sub New()
        Dim r As String() = {""}
        mRoleNames = r
    End Sub

    Public Overrides Sub AddUsersToRoles(ByVal usernames() As String, ByVal roleNames() As String)
        mRoleNames = roleNames
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
        Return mRoleNames
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
