Module DataPagerExtension

    ' .NET FrameworkのDataPagerクラスの拡張メソッド

    ' カレントのページ番号を返す
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentPageNo(ByVal dp As DataPager) As Integer

        Return Math.Ceiling(dp.StartRowIndex / dp.MaximumRows) + 1

    End Function

    ' カレントのページ番号を設定する
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub SetCurrentPageNo(ByVal dp As DataPager, ByVal pageNo As Integer)

        Dim startIndex As Integer = (pageNo - 1) * dp.PageSize
        dp.SetPageProperties(startIndex, dp.PageSize, True)

    End Sub

    ' 全ページ数を返す
    <System.Runtime.CompilerServices.Extension()> _
    Public Function PageCount(ByVal dp As DataPager) As Integer

        Return Math.Ceiling(dp.TotalRowCount / dp.PageSize)

    End Function


    ' TemplatePagerField内からコントロールを探す
    <System.Runtime.CompilerServices.Extension()> _
    Public Function FindControlInTemplatePagerField(ByVal dp As DataPager, ByVal id As String) As Control

        Dim ctrl As Control = Nothing

        For Each c In dp.Controls
            Dim field As DataPagerFieldItem = DirectCast(c, DataPagerFieldItem)
            If TypeOf field.PagerField Is TemplatePagerField Then
                ctrl = field.FindControl(id)
                If ctrl IsNot Nothing Then
                    Exit For
                End If
            End If
        Next

        Return ctrl

    End Function

End Module
