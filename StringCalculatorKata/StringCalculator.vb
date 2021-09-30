Public Class StringCalculator
    Public Function Add(addends As String) As Integer
        If addends.Equals(String.Empty) Then
            Return 0
        End If

        Return addends.Split(",").Sum(Function(n) Integer.Parse(n))
    End Function
End Class
