Imports System.IO

Public Class AuxCodeHandler

    'conjunto de metodos para tratar nome de arquivos , mover arquivos, separar arquivos duplicados 
    Sub WriteMDPInTxt(mt2 As String(,), path As String)

        'metodo que pega a listgem de arquivos em um txt e copia para uma determinada pasta
        'util para obter arquivos restantes para processar

        Dim file As System.IO.StreamWriter
        Dim arc(6000, 1)
        Dim u As Integer = 0
        Dim j As Integer = 0

        Dim reader As New System.IO.StreamReader("c:\Script\mdps2.txt")
        Dim allLines As List(Of String) = New List(Of String)

        Do While reader.Peek() <> -1

            arc(u, 0) = reader.ReadLine() & vbNewLine
            u += 1

        Loop


        reader.Close()

        While j < u


            My.Computer.FileSystem.CopyFile(arc(j, 0).Replace(";", ""), "E:\Transformar MDP\" + arc(j, 0).Replace("D:\INP. ULTRASSOM\", "").Replace(";", ""))
            j += 1

        End While


        file = My.Computer.FileSystem.OpenTextFileWriter("c:\Script\mdps.txt", True)

        Dim i As Integer = 0
        Dim dir As New DirectoryInfo(path)
        Dim fileList As List(Of FileInfo) = dir.GetFiles().ToList()
        Dim hora As Integer
        Dim duplicadoManha As Integer = 0
        Dim duplicadoTarde As Integer = 0

        fileList.Sort(AddressOf SortByDate)


        For Each F As FileInfo In fileList


            mt2(i, 0) = F.FullName.ToString()
            mt2(i, 1) = F.Length.ToString()
            mt2(i, 2) = F.Name()

            file.WriteLine(F.Name())
            i += 1



        Next
    End Sub
    Sub VerificaDuplicidade(mt2 As String(,), path As String)

        'metodo que compara o tamanho dos arquivos pra saber se em bytes, os arquivos estão duplicados
        Dim i As Integer = 0
        Dim dir As New DirectoryInfo(path)
        Dim fileList As List(Of FileInfo) = dir.GetFiles().ToList()
        Dim hora As Integer
        Dim duplicadoManha As Integer = 0
        Dim duplicadoTarde As Integer = 0

        fileList.Sort(AddressOf SortByDate)

        For Each F As FileInfo In fileList


            mt2(i, 0) = F.FullName.ToString()
            mt2(i, 1) = F.Length.ToString()
            mt2(i, 2) = F.Name()

            hora = Integer.Parse(F.Name().Substring(30, 2))

            If (i > 0) Then


                If (hora >= 7 And hora <= 19 And F.Length.ToString() = mt2(i - 1, 1)) Then
                    duplicadoManha += 1
                ElseIf (hora > 19 And hora < 23 And F.Length.ToString() = mt2(i - 1, 1)) Then
                    duplicadoTarde += 1
                ElseIf (hora > 1 And hora < 7 And F.Length.ToString() = mt2(i - 1, 1)) Then
                    duplicadoTarde += 1
                End If
            End If
            'My.Computer.FileSystem.CopyFile(mt2(i, 0), "C:\Dados\ultrassom\" & mt2(i, 2))
            i += 1



        Next
    End Sub

    Sub RenameWrongFile(mt2 As String(,), path As String)

        'metodo para renomear arquivos de amplitude e profundidade que foram escritos errados pelo processo de extração
        Dim i As Integer = 0
        Dim dir As New DirectoryInfo(path)
        Dim fileList As List(Of FileInfo) = dir.GetFiles().ToList()


        fileList.Sort(AddressOf SortByDate)

        For Each F As FileInfo In fileList

            If (F.Name.Contains("CScan_1")) Then

                mt2(i, 0) = F.FullName.ToString()
                mt2(i, 1) = F.Length.ToString()
                mt2(i, 2) = F.Name()

                'My.Computer.FileSystem.CopyFile(mt2(i, 0), "C:\Dados\ultrassom\" & mt2(i, 2))
                i += 1
            End If



        Next

        Dim p As Integer = 0
        Dim nome As String

        For Each F As FileInfo In fileList


            If (mt2(p, 0).ToString().Contains("CScan_1")) Then


                If (p Mod 2 = 1 And p > 0) Then

                    nome = mt2(p, 2).ToString().Replace("AMP", "TOF")
                    My.Computer.FileSystem.RenameFile(mt2(p, 0), nome)

                Else

                End If

            Else

            End If

            p += 1

        Next

    End Sub

    Sub MoveWrongFile(mt2 As String(,), path As String)

        'metodo que retira arquivos com o mesmo tamanho que sejam do grupo cscan1 
        Dim i As Integer = 0
        Dim dir As New DirectoryInfo(path)
        Dim fileList As List(Of FileInfo) = dir.GetFiles().ToList()


        fileList.Sort(AddressOf SortByDate)

        For Each F As FileInfo In fileList

            If (i = 0) Then

                mt2(i, 0) = F.FullName.ToString()
                mt2(i, 1) = F.Length.ToString()
                mt2(i, 2) = F.Name()

            Else

                mt2(i, 0) = F.FullName.ToString()
                mt2(i, 1) = F.Length.ToString()
                mt2(i, 2) = F.Name()

            End If

            i += 1

        Next

        Dim p As Integer = 0

        For Each F As FileInfo In fileList


            If (mt2(p + 1, 0).ToString().Contains("CScan_1") And mt2(p, 0).ToString().Contains("CScan_1") And mt2(p + 1, 1) = mt2(p, 1)) Then

                '  My.Computer.FileSystem.CopyFile(mt2(i - 1, 0), "C:\Dados\ultrassom\" & mt2(i - 1, 2))

                Try

                    My.Computer.FileSystem.CopyFile(mt2(p, 0), "C:\Dados\ultrassom\" & mt2(p, 2))
                    My.Computer.FileSystem.CopyFile(mt2(p + 1, 0), "C:\Dados\ultrassom\" & mt2(p + 1, 2))

                Catch ex As Exception

                End Try

            Else
                If (p > 1) Then
                    If (mt2(p - 1, 0).ToString().Contains("CScan_1") And mt2(p, 0).ToString().Contains("CScan_1") And mt2(p - 1, 1) = mt2(p, 1)) Then
                        Try
                            My.Computer.FileSystem.CopyFile(mt2(p, 0), "C:\Dados\ultrassom\" & mt2(p, 2))
                            My.Computer.FileSystem.CopyFile(mt2(p - 1, 0), "C:\Dados\ultrassom\" & mt2(p - 1, 2))
                        Catch ex As Exception

                        End Try


                    Else
                        My.Computer.FileSystem.CopyFile(mt2(p, 0), "C:\Dados\ultrassomVerificado\" & mt2(p, 2))
                    End If
                Else
                    My.Computer.FileSystem.CopyFile(mt2(p, 0), "C:\Dados\ultrassomVerificado\" & mt2(p, 2))
                End If


            End If

            p += 1




        Next

    End Sub

    Public Function SortByDate(X As FileInfo, Y As FileInfo) As Integer
        Return X.Name.CompareTo(Y.Name)
    End Function

    Public Function SortBySize(X As FileInfo, Y As FileInfo) As Integer
        Return X.Length.CompareTo(Y.Length)
    End Function


End Class
