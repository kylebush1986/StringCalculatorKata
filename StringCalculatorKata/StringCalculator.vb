Imports System.Text.RegularExpressions

Public Class StringCalculator

    Private _delimiters As List(Of String)

    Sub New()
        _delimiters = New List(Of String) From {",", vbCrLf}
    End Sub

    Public Function Add(addends As String) As Integer
        If addends.Equals(String.Empty) Then
            Return 0
        End If

        addends = ProcessCustomDelimiters(addends)

        Dim addendsAsIntegerList = GetAddendsAsIntegerList(addends)

        CheckForNegativeNumbers(addendsAsIntegerList)

        Return addendsAsIntegerList.Sum()
    End Function

    Private Shared Sub CheckForNegativeNumbers(addendsAsIntegerList As List(Of Integer))
        Dim negativeNumbers = addendsAsIntegerList.Where(Function(n) n < 0).ToList()

        If negativeNumbers.Count > 0 Then
            Throw New NegativeNumberException(negativeNumbers)
        End If
    End Sub

    Private Function GetAddendsAsIntegerList(addends As String) As List(Of Integer)
        Return addends.Split(_delimiters.ToArray(), StringSplitOptions.TrimEntries).Select(Function(n) Integer.Parse(n)).Where(Function(n) n < 1000).ToList()
    End Function

    Private Function ProcessCustomDelimiters(addends As String) As String
        If addends.StartsWith("//[") Then
            Dim matches = Regex.Matches(addends, "(?<=\[).+?(?=\])", RegexOptions.None)
            For Each match As Match In matches
                _delimiters.Add(match.Value)
            Next
            addends = addends.Split(vbCrLf)(1)
        ElseIf addends.StartsWith("//") Then
            _delimiters.Add(addends(2))
            addends = addends.Split(vbCrLf)(1)
        End If

        Return addends
    End Function
End Class
