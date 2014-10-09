﻿Public Class SampleMembershipProvider
    Inherits MembershipProvider

    ''' <summary>
    ''' サンプル・メンバーシッププロバイダ
    ''' </summary>
    ''' <remarks>サポートしないメソッドはNotSupportedException例外をスローする</remarks>

    Public Overrides Property ApplicationName() As String
        Get
            Throw New NotSupportedException
        End Get
        Set(ByVal value As String)
            Throw New NotSupportedException
        End Set
    End Property

    Public Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean
        Throw New NotSupportedException
    End Function

    Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean
        Throw New NotSupportedException
    End Function

    Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, ByVal providerUserKey As Object, ByRef status As System.Web.Security.MembershipCreateStatus) As System.Web.Security.MembershipUser
        Throw New NotSupportedException
    End Function

    Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean
        Throw New NotSupportedException
    End Function

    Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Throw New NotSupportedException
    End Function

    Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Throw New NotSupportedException
    End Function

    Public Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Throw New NotSupportedException
    End Function

    Public Overrides Function GetNumberOfUsersOnline() As Integer
        Throw New NotSupportedException
    End Function

    Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String
        Throw New NotSupportedException
    End Function

    Public Overloads Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser
        Throw New NotSupportedException
    End Function

    Public Overloads Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser
        Throw New NotSupportedException
    End Function

    Public Overrides Function GetUserNameByEmail(ByVal email As String) As String
        Throw New NotSupportedException
    End Function

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordFormat() As System.Web.Security.MembershipPasswordFormat
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String
        Throw New NotSupportedException
    End Function

    Public Overrides Function UnlockUser(ByVal userName As String) As Boolean
        Throw New NotSupportedException
    End Function

    Public Overrides Sub UpdateUser(ByVal user As System.Web.Security.MembershipUser)
        Throw New NotSupportedException
    End Sub

    Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean

        '' 独自の認証ロジックを実装する
        '' 認証ＯＫはTrueを、認証ＮＧはFalseを返すようにする
        Return True

    End Function

End Class
