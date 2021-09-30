Imports StringCalculatorKata
Imports Xunit

Namespace StringCalculatorTests
    Public Class StringCalculatorUnitTests
        <Fact>
        Sub EmptyString_ReturnsZero()
            Dim calculator = New StringCalculator

            Dim sum = calculator.Add("")

            Assert.Equal(0, sum)
        End Sub


        <Theory>
        <InlineData("2", 2)>
        <InlineData("5", 5)>
        Sub SingleAddend_ReturnsSingleAddendAsSum(addend As String, expectedSum As Integer)
            Dim calculator = New StringCalculator

            Dim sum = calculator.Add(addend)

            Assert.Equal(expectedSum, sum)
        End Sub
    End Class
End Namespace

