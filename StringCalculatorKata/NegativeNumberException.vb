Public Class NegativeNumberException
    Inherits ApplicationException

    Sub New(negativeNumbers As List(Of Integer))
        MyBase.New($"negatives not allowed: {String.Join(", ", negativeNumbers)}")
    End Sub
End Class
