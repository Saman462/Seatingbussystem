Public Class Form1
    Dim availableicon As New System.Drawing.Bitmap(My.Resources.empty)

    Dim bookedMale As New System.Drawing.Bitmap(My.Resources.Male)
    Dim bookedFemale As New System.Drawing.Bitmap(My.Resources.Female)



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As Control
        For Each c In Me.Controls
            If TypeOf (c) Is PictureBox Then
                CType(c, PictureBox).Image = availableicon
                AddHandler c.Click, AddressOf PictureBox1_Click
            End If
        Next
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        If CType(sender, PictureBox).Image Is availableicon Then
            CType(sender, PictureBox).Image = bookedMale

        ElseIf CType(sender, PictureBox).Image Is bookedMale Then
            CType(sender, PictureBox).Image = bookedFemale
        ElseIf CType(sender, PictureBox).Image Is bookedMale Or CType(sender, PictureBox).Image Is bookedFemale Then

            CType(sender, PictureBox).Image = availableicon
        End If
    End Sub

    Private Sub Btn_Click(sender As Object, e As EventArgs) Handles Btn.Click
        Dim c As Control
        Dim bselected As Boolean
        For Each c In Me.Controls
            If TypeOf (c) Is PictureBox Then
                If CType(c, PictureBox).Image Is bookedFemale Or CType(c, PictureBox).Image Is bookedMale Then


                    bselected = True
                    Exit For
                End If

                AddHandler c.Click, AddressOf PictureBox1_Click
            End If
        Next
        If bselected = False Then
            MsgBox("please select one seat to book")
            Exit Sub
        End If
        Dim iseatnum As Integer
        For Each c In Me.Controls
            If TypeOf (c) Is PictureBox Then
                If CType(c, PictureBox).Image Is bookedFemale Or CType(c, PictureBox).Image Is bookedMale Then
                    iseatnum = Mid(CType(c, PictureBox).Name, 11)
                    MsgBox(iseatnum)

                End If
            End If
        Next
    End Sub
End Class

