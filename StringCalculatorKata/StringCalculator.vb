Public Class StringCalculator
    Public Function Add(addends As String) As Integer
        If addends.Equals(String.Empty) Then
            Return 0
        End If

        Dim delimiters = New List(Of Char) From {",", vbCrLf}

        If addends.StartsWith("//") Then
            delimiters.Add(addends(2))
            addends = addends.Split(vbCrLf)(1)
        End If

        Return addends.Split(delimiters.ToArray()).Sum(Function(n) Integer.Parse(n))
    End Function
End Class
