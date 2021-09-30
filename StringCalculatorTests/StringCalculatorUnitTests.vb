Imports StringCalculatorKata
Imports Xunit

Namespace String_calculatorTests
    Public Class String_calculatorUnitTests
        Private _calculator As StringCalculator
        Private _sum As Integer

        Public Sub New()
            _calculator = New StringCalculator
            _sum = 0
        End Sub

        <Fact>
        Sub EmptyString_ReturnsZero()
            _sum = _calculator.Add("")

            Assert.Equal(0, _sum)
        End Sub


        <Theory>
        <InlineData("2", 2)>
        <InlineData("5", 5)>
        Sub SingleAddend_ReturnsSingleAddendAsSum(addend As String, expectedSum As Integer)
            _sum = _calculator.Add(addend)

            Assert.Equal(expectedSum, _sum)
        End Sub

        <Theory>
        <InlineData("1,2", 3)>
        <InlineData("4,5", 9)>
        Sub TwoAddends_ReturnsSumOfTwoAddends(addends As String, expectedSum As Integer)
            _sum = _calculator.Add(addends)

            Assert.Equal(expectedSum, _sum)
        End Sub

        <Theory>
        <InlineData("1,2,3", 6)>
        <InlineData("1,2,3,4", 10)>
        <InlineData("1,2,3,4,5", 15)>
        Sub UnknownNumberOfAddends_ReturnsSumOfAllAddends(addends As String, expectedSum As Integer)
            _sum = _calculator.Add(addends)

            Assert.Equal(expectedSum, _sum)
        End Sub
    End Class
End Namespace

