Public Class Form1
    Private BackgroundBlue As Integer = 255
    Private BackgroundGreen As Integer = 255
    Private BackgroundRed As Integer = 255
    Private Buttons As Button()() = CreateArray(Function(i As Integer) CreateArray(Function(j As Integer) New Button, 5), 5)
    Private ButtonSize As Integer = 20
    Private Colors() As Color
    Private e As Integer = 6
    Private FormSkip As Integer = 10
    Private FractalBlue As Integer = 87
    Private FractalGreen As Integer = 139
    Private FractalRed As Integer = 46
    Private Skip As Integer = 10
    Private Sub Click1()
        If Buttons(0)(0).BackColor = Colors(0) Then
            Buttons(0)(0).BackColor = Colors(e)
            Buttons(0)(4).BackColor = Colors(e)
            Buttons(4)(0).BackColor = Colors(e)
            Buttons(4)(4).BackColor = Colors(e)
        Else
            Buttons(0)(0).BackColor = Colors(0)
            Buttons(0)(4).BackColor = Colors(0)
            Buttons(4)(0).BackColor = Colors(0)
            Buttons(4)(4).BackColor = Colors(0)
        End If
        DataAndDraw()
    End Sub
    Private Sub Click2()
        If Buttons(0)(1).BackColor = Colors(0) Then
            Buttons(0)(1).BackColor = Colors(e)
            Buttons(0)(3).BackColor = Colors(e)
            Buttons(1)(0).BackColor = Colors(e)
            Buttons(1)(4).BackColor = Colors(e)
            Buttons(3)(0).BackColor = Colors(e)
            Buttons(3)(4).BackColor = Colors(e)
            Buttons(4)(1).BackColor = Colors(e)
            Buttons(4)(3).BackColor = Colors(e)
        Else
            Buttons(0)(1).BackColor = Colors(0)
            Buttons(0)(3).BackColor = Colors(0)
            Buttons(1)(0).BackColor = Colors(0)
            Buttons(1)(4).BackColor = Colors(0)
            Buttons(3)(0).BackColor = Colors(0)
            Buttons(3)(4).BackColor = Colors(0)
            Buttons(4)(1).BackColor = Colors(0)
            Buttons(4)(3).BackColor = Colors(0)
        End If
        DataAndDraw()
    End Sub
    Private Sub Click3()
        If Buttons(0)(2).BackColor = Colors(0) Then
            Buttons(0)(2).BackColor = Colors(e)
            Buttons(2)(0).BackColor = Colors(e)
            Buttons(2)(4).BackColor = Colors(e)
            Buttons(4)(2).BackColor = Colors(e)
        Else
            Buttons(0)(2).BackColor = Colors(0)
            Buttons(2)(0).BackColor = Colors(0)
            Buttons(2)(4).BackColor = Colors(0)
            Buttons(4)(2).BackColor = Colors(0)
        End If
        DataAndDraw()
    End Sub
    Private Sub Click4()
        If Buttons(1)(1).BackColor = Colors(0) Then
            Buttons(1)(1).BackColor = Colors(e)
            Buttons(1)(3).BackColor = Colors(e)
            Buttons(3)(1).BackColor = Colors(e)
            Buttons(3)(3).BackColor = Colors(e)
        Else
            Buttons(1)(1).BackColor = Colors(0)
            Buttons(1)(3).BackColor = Colors(0)
            Buttons(3)(1).BackColor = Colors(0)
            Buttons(3)(3).BackColor = Colors(0)
        End If
        DataAndDraw()
    End Sub
    Private Sub Click5()
        If Buttons(1)(2).BackColor = Colors(0) Then
            Buttons(1)(2).BackColor = Colors(e)
            Buttons(2)(1).BackColor = Colors(e)
            Buttons(2)(3).BackColor = Colors(e)
            Buttons(3)(2).BackColor = Colors(e)
        Else
            Buttons(1)(2).BackColor = Colors(0)
            Buttons(2)(1).BackColor = Colors(0)
            Buttons(2)(3).BackColor = Colors(0)
            Buttons(3)(2).BackColor = Colors(0)
        End If
        DataAndDraw()
    End Sub
    Private Sub Click6()
        If Buttons(2)(2).BackColor = Colors(0) Then
            Buttons(2)(2).BackColor = Colors(e)
        Else
            Buttons(2)(2).BackColor = Colors(0)
        End If
        DataAndDraw()
    End Sub
    Private Function CreateArray(Of T)(f As Func(Of Integer, T), n As Integer) As T()
        If n = 0 Then
            Return {}
        Else
            Dim Ret(n - 1) As T
            For i As Integer = 1 To n
                Ret(i - 1) = f(i)
            Next
            Return Ret
        End If
    End Function
    Private Sub DataAndDraw()
        Dim Canvas As Graphics = Me.CreateGraphics
        Canvas.Clear(Colors(0))
        Dim FractalCorner As Integer = Math.Round((3 ^ (e - 1) - 1) / 2)
        Draw(2 * Skip + 5 * ButtonSize + FractalCorner, Skip + FractalCorner, e, New Tuple(Of Boolean, Boolean, Boolean, Boolean, Boolean, Boolean)(Ive(Buttons(0)(0)), Ive(Buttons(0)(1)), Ive(Buttons(0)(2)), Ive(Buttons(1)(1)), Ive(Buttons(1)(2)), Ive(Buttons(2)(2))))
    End Sub
    Private Sub Draw(x As Integer, y As Integer, i As Integer, f As Tuple(Of Boolean, Boolean, Boolean, Boolean, Boolean, Boolean))
        Dim a As Integer = 3 ^ (i - 1)
        Dim Canvas As Graphics = Me.CreateGraphics
        Canvas.FillRectangle(New SolidBrush(Colors(e - i + 1)), New Rectangle(x, y, a, a))
        If i > 1 Then
            Dim c As Integer = a \ 3
            Dim xPoints() As Integer = {x - c, x, x + c, x + a - c, x + a}
            Dim yPoints() As Integer = {y - c, y, y + c, y + a - c, y + a}
            If f.Item1 Then
                Draw(xPoints(0), yPoints(0), i - 1, f)
                Draw(xPoints(4), yPoints(0), i - 1, f)
                Draw(xPoints(0), yPoints(4), i - 1, f)
                Draw(xPoints(4), yPoints(4), i - 1, f)
            End If
            If f.Item2 Then
                Draw(xPoints(1), yPoints(0), i - 1, f)
                Draw(xPoints(3), yPoints(0), i - 1, f)
                Draw(xPoints(0), yPoints(1), i - 1, f)
                Draw(xPoints(4), yPoints(1), i - 1, f)
                Draw(xPoints(0), yPoints(3), i - 1, f)
                Draw(xPoints(4), yPoints(3), i - 1, f)
                Draw(xPoints(1), yPoints(4), i - 1, f)
                Draw(xPoints(3), yPoints(4), i - 1, f)
            End If
            If f.Item3 Then
                Draw(xPoints(2), yPoints(0), i - 1, f)
                Draw(xPoints(0), yPoints(2), i - 1, f)
                Draw(xPoints(4), yPoints(2), i - 1, f)
                Draw(xPoints(2), yPoints(4), i - 1, f)
            End If
            If f.Item4 Then
                Draw(xPoints(1), yPoints(1), i - 1, f)
                Draw(xPoints(3), yPoints(1), i - 1, f)
                Draw(xPoints(1), yPoints(3), i - 1, f)
                Draw(xPoints(3), yPoints(3), i - 1, f)
            End If
            If f.Item5 Then
                Draw(xPoints(2), yPoints(1), i - 1, f)
                Draw(xPoints(1), yPoints(2), i - 1, f)
                Draw(xPoints(3), yPoints(2), i - 1, f)
                Draw(xPoints(2), yPoints(3), i - 1, f)
            End If
            If f.Item6 Then
                Draw(xPoints(2), yPoints(2), i - 1, f)
            End If
        End If
    End Sub
    Private Function Ive(MyButton As Button) As Boolean
        Return Not MyButton.BackColor = Colors(0)
    End Function
    Private Sub MeLoad() Handles Me.Load
        Colors = CreateArray(Function(i As Integer) Color.FromArgb(Weighted(BackgroundRed, FractalRed, e + 1, i), Weighted(BackgroundGreen, FractalGreen, e + 1, i), Weighted(BackgroundBlue, FractalBlue, e + 1, i)), e + 1)
        Dim ButtonAreaSize As Integer = 5 * ButtonSize
        Dim FractalSize As Integer = 2 * 3 ^ (e - 1) - 1
        Me.BackColor = Colors(0)
        Me.ClientSize = New Size(3 * Skip + ButtonAreaSize + FractalSize, 2 * Skip + FractalSize)
        Me.Text = "Fractals!!!"
        Dim ButtonAreaHeight As Integer = Math.Round((Me.Height - ButtonAreaSize) / 2)
        AddHandler Buttons(0)(0).Click, AddressOf Click1
        AddHandler Buttons(0)(1).Click, AddressOf Click2
        AddHandler Buttons(0)(2).Click, AddressOf Click3
        AddHandler Buttons(0)(3).Click, AddressOf Click2
        AddHandler Buttons(0)(4).Click, AddressOf Click1
        AddHandler Buttons(1)(0).Click, AddressOf Click2
        AddHandler Buttons(1)(1).Click, AddressOf Click4
        AddHandler Buttons(1)(2).Click, AddressOf Click5
        AddHandler Buttons(1)(3).Click, AddressOf Click4
        AddHandler Buttons(1)(4).Click, AddressOf Click2
        AddHandler Buttons(2)(0).Click, AddressOf Click3
        AddHandler Buttons(2)(1).Click, AddressOf Click5
        AddHandler Buttons(2)(2).Click, AddressOf Click6
        AddHandler Buttons(2)(3).Click, AddressOf Click5
        AddHandler Buttons(2)(4).Click, AddressOf Click6
        AddHandler Buttons(3)(0).Click, AddressOf Click2
        AddHandler Buttons(3)(1).Click, AddressOf Click4
        AddHandler Buttons(3)(2).Click, AddressOf Click5
        AddHandler Buttons(3)(3).Click, AddressOf Click4
        AddHandler Buttons(3)(4).Click, AddressOf Click2
        AddHandler Buttons(4)(0).Click, AddressOf Click1
        AddHandler Buttons(4)(1).Click, AddressOf Click2
        AddHandler Buttons(4)(2).Click, AddressOf Click3
        AddHandler Buttons(4)(3).Click, AddressOf Click2
        AddHandler Buttons(4)(4).Click, AddressOf Click1
        For i As Integer = 0 To 4
            For j As Integer = 0 To 4
                Buttons(i)(j).BackColor = Colors(0)
                Buttons(i)(j).Height = ButtonSize
                Buttons(i)(j).Left = Skip + j * ButtonSize
                Buttons(i)(j).Top = ButtonAreaHeight + i * ButtonSize
                Buttons(i)(j).Width = 20
                Controls.Add(Buttons(i)(j))
            Next
        Next
        DataAndDraw()
    End Sub
    Private Function Weighted(m As Integer, n As Integer, l As Integer, i As Integer) As Integer
        Return Math.Round(((l - i) * m + (i - 1) * n) / (l - 1))
    End Function
End Class