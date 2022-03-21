Imports System.IO

Public Class Form1

    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8
    Private Const MOUSEEVENTF_RIGHTUP = &H10

    Private Const MOUSEWHEEL = &H20A

    Public YData = 233

    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean


    Public mt(15000, 1)
    Public mt2(50000, 3)
    Public i As Integer
    Public count As Integer


    Dim value As Point
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        TextBox1.Text = "D:\AB"
        TextBox2.Text = "C:\Test\Apps\Eixo_Vale_2_Grupos\Data"

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick






        If (verifyMentorUp()) Then



        Else

            'se o mentor nao esta up abrir cmd e executar o programa, se nao for dessa forma o mentor abre sem o app configurado
            Process.Start("CMD.exe", "/C cd C:\Program Files\Waygate Technologies\Mentor PC && MentorPC.exe")


            value.X = 140
            value.Y = 202

            Cursor.Position = value
            Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
            Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


            WaitForTime("00:00:08")


            value.X = 1080
            value.Y = 584

            Cursor.Position = value

            Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
            Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


            WaitForTime("00:00:06")


            Timer1.Enabled = False
            Timer2.Enabled = False


        End If





        'load data

        value.X = 1174
        value.Y = 690

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:02")

        'Select Location

        value.X = 1129
        value.Y = 593

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:02")


        'select usb
        value.X = 1110
        value.Y = 127

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:02")


        'select usb
        value.X = 1009
        value.Y = 209
        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:02")


        'select USB
        value.X = 286
        value.Y = 252

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)



        WaitForTime("00:00:02")


        value.X = 313
        value.Y = 211

        'End If



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:02")


        'load
        value.X = 1013
        value.Y = 590

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:13")



        '----------------------



        '

        'select left 
        value.X = 146
        value.Y = 569



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:01")


        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        '

        'load
        value.X = 1174
        value.Y = 699

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:01")

        'save csv
        value.X = 1150
        value.Y = 469



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        WaitForTime("00:00:02")


        value.X = 1014
        value.Y = 594



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:06")

        'renomear csv
        renamecsv(mt(count, 0), "AMP", mt(count, 1))

        Timer1.Enabled = False


        Timer2.Enabled = True

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dir As New DirectoryInfo(TextBox1.Text)
        Dim fileList As List(Of FileInfo) = dir.GetFiles().ToList()
        Dim Aux As New AuxCode


        fileList.Sort(AddressOf Aux.SortByDate)

        For Each F As FileInfo In fileList

            mt(i, 0) = F.FullName.Substring(45, 7).ToString()
            mt(i, 1) = F.FullName.ToString()

            i += 1

        Next


        Timer1.Enabled = True



    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick


        WaitForTime("00:00:06")


        value.X = 1177
        value.Y = 154


        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:02")


        value.X = 1209
        value.Y = 283



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        '---------------- left and rigth

        WaitForTime("00:00:06")



        'select right 
        value.X = 728
        value.Y = 571



        Cursor.Position = value

        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:02")


        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        'select left

        value.X = 139
        value.Y = 568

        Cursor.Position = value

        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:02")


        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)



        'load
        value.X = 1169
        value.Y = 690

        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)

        '
        WaitForTime("00:00:01")


        'save csv
        value.X = 1131
        value.Y = 469



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)



        WaitForTime("00:00:02")




        value.X = 1017
        value.Y = 593



        Cursor.Position = value
        Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
        Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)


        WaitForTime("00:00:06")


        renamecsv(mt(count, 0), "TOF", mt(count, 1))

        My.Computer.FileSystem.DeleteFile(mt(count, 1))

        count += 1

        Timer2.Enabled = False

        Timer1.Enabled = True

    End Sub

    Public Sub getMDPToText()

        For Each file In Directory.EnumerateFiles(TextBox2.Text, "*.mdp")
            If (file.Length <= 87) Then

            End If
        Next
    End Sub

    Public Sub renamecsv(wagon As String, tipo As String, mdp As String)

        For Each file In Directory.EnumerateFiles(TextBox2.Text, "*.csv")
            If (file.Length <= 87) Then
                My.Computer.FileSystem.RenameFile(file, mdp.Substring(6, mdp.Length - 6).Replace(".mdp", "") + "_" + file.ToString().Substring(37, 46) + "_" + wagon + "_" + tipo + ".csv")
            End If
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Aux As New AuxCode
        Aux.MoveWrongFile(mt2, TextBox1.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Aux As New AuxCode
        Aux.RenameWrongFile(mt2, TextBox1.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Aux As New AuxCode
        Aux.WriteMDPInTxt()
    End Sub

    Public Sub WaitForTime(time As String)

        Dim dt As TimeSpan

        Dim timme As Date

        dt = TimeSpan.Parse(time)
        timme = Now + dt

        Do While Now < timme


        Loop


    End Sub

    Public Function verifyMentorUp()
        Dim mentorup As Boolean = True
        For Each x In Process.GetProcessesByName("MentorPC")
            If (x.ToString() <> "") Then
                mentorup = True
            Else
                mentorup = False

            End If
        Next

        verifyMentorUp = mentorup

    End Function
End Class
