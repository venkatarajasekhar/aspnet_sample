Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common

Public Class SampleDAO

    Private _dataSet As DataSet

    Public Sub New()

        _dataSet = New DataSet
        _dataSet.Locale = Globalization.CultureInfo.InvariantCulture

        Dim filePath As String = HttpContext.Current.Server.MapPath("~/App_Data/Sample.xml")
        _dataSet.ReadXml(filePath)

    End Sub


    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Function GetData(ByVal startRowIndex As Integer, ByVal maximumRows As Integer) As DataSet

        Dim rows() As Data.DataRow = _dataSet.Tables(0).Select("ID>" & startRowIndex)

        Dim ds As New DataSet
        ds.Tables.Add("Sample")
        ds.Tables("Sample").Columns.Add("ID")
        ds.Tables("Sample").Columns.Add("NAME")

        For Each r In rows
            Dim row As Data.DataRow = ds.Tables("Sample").NewRow
            row("ID") = r("ID").ToString
            row("NAME") = r("NAME").ToString
            ds.Tables("Sample").Rows.Add(row)
        Next

        Return ds

    End Function

    <DataObjectMethod(DataObjectMethodType.Select, True)> _
Public Function GetRowCount() As Integer

        Dim rows() As Data.DataRow = _dataSet.Tables(0).Select

        Return rows.Count

    End Function
End Class
