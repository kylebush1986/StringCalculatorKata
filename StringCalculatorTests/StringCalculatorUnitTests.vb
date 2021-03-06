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

        <Fact>
        Sub NewlineDelimiter_ReturnsCorrectSum()
            _sum = _calculator.Add($"1{vbCrLf}2,3")

            Assert.Equal(6, _sum)
        End Sub

        <Fact>
        Sub CustomDelimiter_ReturnsCorrectSum()
            _sum = _calculator.Add($"//;{vbCrLf}1;2")

            Assert.Equal(3, _sum)
        End Sub

        <Theory>
        <InlineData("-2", "negatives not allowed: -2")>
        <InlineData("1, -2", "negatives not allowed: -2")>
        <InlineData("1, -2, 3, -4", "negatives not allowed: -2, -4")>
        Sub NegativeAddends_ThrowsNegativeNumberException(addends As String, expectedMessage As String)
            Dim ex = Assert.Throws(Of NegativeNumberException)(Function() _calculator.Add(addends))
            Assert.Equal(ex.Message, expectedMessage)
        End Sub

        <Theory>
        <InlineData("2, 1001", 2)>
        <InlineData("6, 1001, 4", 10)>
        Sub NumbersBiggerThan1000AreIgnored(addends As String, expectedSum As Integer)
            _sum = _calculator.Add(addends)
            Assert.Equal(expectedSum, _sum)
        End Sub

        <Fact>
        Sub CustomDelimiterOfVariableLength_ReturnsCorrectSum()
            _sum = _calculator.Add($"//[***]{vbCrLf}1***2***3")
            Assert.Equal(6, _sum)
        End Sub

        <Fact>
        Sub MultipleSingleCharacterCustomDelimiters_ReturnsCorrectSum()
            _sum = _calculator.Add($"//[*][%]{vbCrLf}1*2%3")
            Assert.Equal(6, _sum)
        End Sub

        <Fact>
        Sub MultipleVariableLengthCustomDelimiters_ReturnsCorrectSum()
            _sum = _calculator.Add($"//[***][%%]{vbCrLf}1***2%%3")
            Assert.Equal(6, _sum)
        End Sub
    End Class
End Namespace

