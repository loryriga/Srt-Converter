Imports System.IO

Public Class Form1

    'Global Tags
    Dim FilePath1 As String = ""
    Dim FilePath2 As String = ""

    Dim Ch As Boolean = False
    Dim Btrt As Boolean = False
    Dim Del As Boolean = False
    Dim GlsSgl As Boolean = False
    Dim UavBat As Boolean = False
    Dim GlsBat As Boolean = False
    Dim FltTim As Boolean = False
    Dim RcSgl As Boolean = False
    Dim GlsBatCells As Boolean = False
    Dim UavBatCells As Boolean = False

    Dim ColCnt As Int16 = 0

    Private Function Splitter(SrtRows() As String, FileNo As Int16)

        Dim Ind As Int16
        Dim Tmp As String
        Dim curr As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
        Dim nxt As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
        Dim interval As TimeSpan = New TimeSpan(0, 0, 0, 0, 1)
        Dim i As Int64 = 0
        Dim j As Int64 = 1
        Dim cnt As Int64 = 0
        Dim LastElem As Boolean = False

        'Creating "Output" Tag
        For i = 0 To (SrtRows.Length - 1)
            If InStr(SrtRows(i), "-->") <> 0 Then cnt += 1
        Next

        Dim Output(cnt + 1) As String

        'Generating .csv file header
        ColCnt = 0

        If GlsSgl Then
            Output(0) = Output(0) & ";Signal " & FileNo
            ColCnt += 1
        End If
        If Ch Then
            Output(0) = Output(0) & ";Channel " & FileNo
            ColCnt += 1
        End If
        If FltTim Then
            Output(0) = Output(0) & ";Flight Time " & FileNo
            ColCnt += 1
        End If
        If UavBat Then
            Output(0) = Output(0) & ";Uav Bat " & FileNo
            ColCnt += 1
        End If
        If GlsBat Then
            Output(0) = Output(0) & ";Goggles Bat " & FileNo
            ColCnt += 1
        End If
        If UavBatCells Then
            Output(0) = Output(0) & ";Uav Batt Cells " & FileNo
            ColCnt += 1
        End If
        If GlsBatCells Then
            Output(0) = Output(0) & ";Goggles Batt Cells " & FileNo
            ColCnt += 1
        End If
        If Del Then
            Output(0) = Output(0) & ";Delay " & FileNo
            ColCnt += 1
        End If
        If Btrt Then
            Output(0) = Output(0) & ";Bitrate " & FileNo
            ColCnt += 1
        End If
        If RcSgl Then
            Output(0) = Output(0) & ";RC Signal " & FileNo
            ColCnt += 1
        End If

        'Extracting data
        i = 0
        Do While i < SrtRows.Length - 1

            If InStr(SrtRows(i), "-->") <> 0 Then

                'Timestamp
                Ind = InStr(SrtRows(i), " ") - 1
                Output(j) = Microsoft.VisualBasic.Left(SrtRows(i), Ind)

Data:           i += 1

                'Goggles signal
                If GlsSgl Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "signal:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 7 - 2))
                    Ind = InStr(Tmp, " ") - 1
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'Channel
                If Ch Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "ch:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 3 - 2))
                    Ind = InStr(Tmp, " ") - 1
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'Flight time:
                If FltTim Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "flightTime:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 11 - 2))
                    Ind = InStr(Tmp, " ") - 1
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'uavBat:
                If UavBat Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "uavBat:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 7 - 2))
                    Ind = InStr(Tmp, " ") - 2
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'glsBat:
                If GlsBat Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "glsBat:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 7 - 2))
                    Ind = InStr(Tmp, " ") - 2
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If


                'UavBat Cells Count
                If UavBatCells Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "uavBatCells:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 12 - 2))
                    Ind = InStr(Tmp, " ") - 1
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'GlsBat Cells Count
                If GlsBatCells Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "glsBatCells:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 12 - 2))
                    Ind = InStr(Tmp, " ") - 1
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'Delay
                If Del Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "delay:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 6 - 2))
                    Ind = InStr(Tmp, " ") - 3
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Tmp
                End If

                'Bitrate
                If Btrt = True Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "bitrate:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 8 - 2))
                    Ind = InStr(Tmp, " ") - 5
                    Tmp = Microsoft.VisualBasic.Left(Tmp, Ind)
                    Output(j) = Output(j) + ";" + Replace(Tmp, ".", ",")
                End If

                'RcSgl
                If RcSgl = True Then
                    Tmp = ""
                    Ind = InStr(SrtRows(i), "rcSignal:")
                    Tmp = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - (Ind + 9 - 2))
                    Output(j) = Output(j) + ";" + Replace(Tmp, ".", ",")
                End If

                j += 1

            End If

            i += 1

            'Handling last TimeStamp
            If i = SrtRows.Length - 1 And Not LastElem Then
                i -= 2
                Ind = InStr(SrtRows(i), "-->") + 2
                Output(j) = Microsoft.VisualBasic.Right(SrtRows(i), SrtRows(i).Length - 1 - Ind)
                LastElem = True
                GoTo Data
            End If

        Loop

        Return Output

    End Function

    Private Function Filler(DataArr() As String)

        Dim DiffTime As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
        Dim Out As Boolean
        Dim i As Int64 = 1
        Dim ElemsCnt = 0
        Dim CurrElems(5)
        Dim NxtElems(5)
        Dim curr As TimeSpan = New TimeSpan(0, 0, 1, 1, 1)
        Dim nxt As TimeSpan = New TimeSpan(0, 0, 1, 1, 1)
        Dim interval As TimeSpan = New TimeSpan(0, 0, 0, 0, 1)

        'Filling Loop
        Do While Not Out

            'Splitting current and next row
            CurrElems = DataArr(i).Split(";")
            NxtElems = DataArr(i + 1).Split(";")

            'Converting the data timestamp from string to TimeSpan
            curr = TimeSpan.Parse(CurrElems(0))
            nxt = TimeSpan.Parse(NxtElems(0))

            'Resetting  missing elements count
            ElemsCnt = 0

            'Verifying if there are missing elements
            If nxt.Subtract(curr) <> interval Then
                'Calculating missing elements count
                DiffTime = nxt.Subtract(curr)
                ElemsCnt = DiffTime.Days * 3600000 * 24
                ElemsCnt += DiffTime.Hours * 3600000
                ElemsCnt += DiffTime.Minutes * 60000
                ElemsCnt += DiffTime.Seconds * 1000
                ElemsCnt += DiffTime.Milliseconds
                ElemsCnt -= 1

                'Adding elements to the data array
                ReDim Preserve DataArr(DataArr.Length - 1 + ElemsCnt)

                'Shifting elements in the data array
                For j = (DataArr.Length - 1) To (i + ElemsCnt) Step -1
                    DataArr(j) = DataArr(j - ElemsCnt)
                Next

                'Filling added elements
                For j = i To i + ElemsCnt - 1
                    DataArr(j + 1) = ""

                    'calculating updated timestamp
                    curr += interval
                    DataArr(j + 1) = Replace(Convert.ToString(curr), ".", ",")

                    For k = 1 To ColCnt
                        DataArr(j + 1) += ";" + CurrElems(k)
                    Next
                Next
            End If

            'Updating loop index
            If ElemsCnt <> 0 Then
                i += ElemsCnt
            Else
                i += 1
            End If

            'Evaluating exit from loop
            If i >= DataArr.Length - 1 Then
                Out = True
            End If

        Loop

        Return DataArr

    End Function

    Private Function TsRemover(DataArr() As String)

        Dim Ind As Int16

        For i = 0 To DataArr.Length - 1
            Ind = InStr(DataArr(i), ";") - 1
            DataArr(i) = Microsoft.VisualBasic.Right(DataArr(i), DataArr(i).Length - 1 - Ind)
        Next

        Return DataArr

    End Function

    Private Function TsGen(MaxLen As Int64)

        Dim Ts As TimeSpan = New TimeSpan(0, 0, 0, 0, 50)
        Dim Interval As TimeSpan = New TimeSpan(0, 0, 0, 0, 1)
        Dim TsArr(MaxLen) As String

        TsArr(0) = ""

        'Generating Timestamps
        TsArr(1) = Replace(Convert.ToString(Ts), ".", ",")

        For i = 2 To MaxLen
            Ts += Interval
            TsArr(i) = Replace(Convert.ToString(Ts), ".", ",")
        Next

        Return TsArr

    End Function

    Private Function RowsGen(TsArr() As String, DataArr1() As String, DataArr2() As String, LongerArr As Int16)

        Dim CsvRows(TsArr.Length) As String
        Dim FillingStr As String = ""

        'Merging files
        For i = 0 To ColCnt
            FillingStr = FillingStr & ";"
        Next

        If Not DataArr1 Is Nothing And Not DataArr2 Is Nothing Then
            For i = 0 To TsArr.Length - 1
                If (LongerArr = 1 And i < DataArr2.Length) Then
                    CsvRows(i) = TsArr(i) & ";" & DataArr1(i) & ";" & DataArr2(i)
                ElseIf (LongerArr = 1 And i >= DataArr2.Length) Then
                    CsvRows(i) = TsArr(i) & ";" & DataArr1(i)
                ElseIf (LongerArr = 2 And i < DataArr1.Length) Then
                    CsvRows(i) = TsArr(i) & ";" & DataArr1(i) & ";" & DataArr2(i)
                ElseIf (LongerArr = 2 And i >= DataArr1.Length) Then
                    CsvRows(i) = TsArr(i) & FillingStr & DataArr2(i)
                End If
            Next
        End If

        'Processing only file 1
        If Not DataArr1 Is Nothing And DataArr2 Is Nothing Then
            For i = 0 To TsArr.Length - 1
                CsvRows(i) = TsArr(i) & ";" & DataArr1(i)
            Next
        End If

        'Processing only file 2
        If DataArr1 Is Nothing And Not DataArr2 Is Nothing Then
            For i = 0 To TsArr.Length - 1
                CsvRows(i) = TsArr(i) & FillingStr & DataArr2(i)
            Next
        End If

        Return CsvRows

    End Function

    Private Sub SaveFile(CsvRows() As String)
        Dim DestPath As String

        SaveFileDialog1.Filter = "Comma Separated Values files (*.csv) | *.csv"
        SaveFileDialog1.Title = "Save File"
        SaveFileDialog1.FileName = "Out.csv"
        SaveFileDialog1.RestoreDirectory = True
        SaveFileDialog1.ShowDialog()

        If Windows.Forms.DialogResult.OK Then
            DestPath = SaveFileDialog1.FileName.ToString()
            System.IO.File.WriteAllLines(DestPath, CsvRows)
        End If
    End Sub

    Private Sub Main()

        'Declaring Tags
        Dim Main_DataArr1() As String
        Dim Main_DataArr2() As String
        Dim Main_TsArr() As String
        Dim Main_CsvRows() As String
        Dim Main_MaxLen As Int64
        Dim Main_LongerArr As Int16
        Dim SrtRows1 As String()
        Dim SrtRows2 As String()
        Dim SkipFile1 = False
        Dim SkipFile2 = False

        'No file selected
        If FilePath1 = "" And FilePath2 = "" Then
            MsgBox("No File Selected", MsgBoxStyle.OkOnly, "Warning!")
            Exit Sub

            'Reading only file 1
        ElseIf FilePath1 <> "" And FilePath2 = "" Then
            Select Case MsgBox("Only one file selected, proceed anyway?", MsgBoxStyle.YesNo, "Warning!")
                Case MsgBoxResult.Yes
                    SrtRows1 = File.ReadAllLines(FilePath1)
                    SkipFile2 = True
                Case MsgBoxResult.No
                    Exit Sub
            End Select

            'Reading only file 2
        ElseIf FilePath1 = "" And FilePath2 <> "" Then
            Select Case MsgBox("Only one file selected, proceed anyway?", MsgBoxStyle.YesNo, "Warning!")
                Case MsgBoxResult.Yes
                    SrtRows2 = File.ReadAllLines(FilePath2)
                    SkipFile1 = True
                Case MsgBoxResult.No
                    Exit Sub
            End Select

            'Reading both files
        Else
            SrtRows1 = File.ReadAllLines(FilePath1)
            FilePath1_lbl.Text = (FilePath1)
            SrtRows2 = File.ReadAllLines(FilePath2)
            FilePath2_lbl.Text = (FilePath2)
        End If

        'Processing File 1
        If Not SkipFile1 Then
            Main_DataArr1 = Splitter(SrtRows1, 1)
            Main_DataArr1 = Filler(Main_DataArr1)
            Main_DataArr1 = TsRemover(Main_DataArr1)
        End If

        'Processing File 2
        If Not SkipFile2 Then
            Main_DataArr2 = Splitter(SrtRows2, 2)
            Main_DataArr2 = Filler(Main_DataArr2)
            Main_DataArr2 = TsRemover(Main_DataArr2)
        End If

        'Calculating max array lenght
        If Not SkipFile1 And Not SkipFile2 Then
            If Main_DataArr1.Length >= Main_DataArr2.Length Then
                Main_MaxLen = Main_DataArr1.Length - 1
                Main_LongerArr = 1
            Else
                Main_MaxLen = Main_DataArr2.Length - 1
                Main_LongerArr = 2
            End If
            '
        ElseIf Not SkipFile1 And SkipFile2 Then
            Main_MaxLen = Main_DataArr1.Length - 1
            Main_LongerArr = 1

        ElseIf SkipFile1 And Not SkipFile2 Then
            Main_MaxLen = Main_DataArr2.Length - 1
            Main_LongerArr = 2
        End If

        'Generating common TimeStamps
        Main_TsArr = TsGen(Main_MaxLen)

        'Writing output .csv file
        Main_CsvRows = RowsGen(Main_TsArr, Main_DataArr1, Main_DataArr2, Main_LongerArr)
        SaveFile(Main_CsvRows)

    End Sub

    'WinForm 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog2.Filter = "Srt files (*.srt) | *.srt"
        OpenFileDialog2.Title = "Select File 1"
        OpenFileDialog2.FileName = ""
        OpenFileDialog2.RestoreDirectory = True
        OpenFileDialog2.ShowDialog()

        If Windows.Forms.DialogResult.OK Then FilePath1 = OpenFileDialog2.FileName.ToString()
        FilePath1_lbl.Text = (FilePath1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog2.Filter = "Srt files (*.srt) | *.srt"
        OpenFileDialog2.Title = "Select File 2"
        OpenFileDialog2.FileName = ""
        OpenFileDialog2.RestoreDirectory = True
        OpenFileDialog2.ShowDialog()

        If Windows.Forms.DialogResult.OK Then FilePath2 = OpenFileDialog2.FileName.ToString()
        FilePath2_lbl.Text = (FilePath2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Btrt = True
        Else
            Btrt = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            Del = True
        Else
            Del = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            GlsSgl = True
        Else
            GlsSgl = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            RcSgl = True
        Else
            RcSgl = False
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            UavBat = True
        Else
            UavBat = False
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked Then
            FltTim = True
        Else
            FltTim = False
        End If
    End Sub
    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked Then
            GlsBat = True
        Else
            GlsBat = False
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked Then
            UavBatCells = True
        Else
            UavBatCells = False
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked Then
            GlsBatCells = True
        Else
            GlsBatCells = False
        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked Then
            Ch = True
        Else
            Ch = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class
