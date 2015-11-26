Imports System.IO

Public Class Form1
    Private aPricesGrid(,) As TextBox
    Private aAverages() As TextBox
    Private aNames() As TextBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aPricesGrid = {{txtCut0, txtColor0, txtUpdo0},
                       {txtCut1, txtColor1, txtUpdo1},
                       {txtCut2, txtColor2, txtUpdo2},
                       {txtCut3, txtColor3, txtUpdo3},
                       {txtCut4, txtColor4, txtUpdo4}}
        aAverages = {txtAvg0, txtAvg1, txtAvg2}
        aNames = {txtName0, txtName1, txtName2, txtName3, txtName4}
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For nCol As Integer = 0 To 2
            Dim nColTotal As Integer = 0
            Dim nColItems As Integer = 0
            For nRow As Integer = 0 To 4
                Try
                    nColTotal += aPricesGrid(nRow, nCol).Text
                    nColItems += 1
                Catch ex As Exception

                End Try
            Next
            aAverages(nCol).Text = nColTotal / nColItems

        Next

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim oSaveFileDialog As New SaveFileDialog()
        'Display the Common file Dialopg to user 
        oSaveFileDialog.Filter = "Text Files (*.txt)|*.txt"
        If oSaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ' Retrieve Name and open it 
            Dim fileName As String = oSaveFileDialog.FileName
            Dim outputFile As StreamWriter = File.CreateText(fileName)
            For nRow As Integer = 0 To 4
                outputFile.Write(aNames(nRow).Text)
                For nCol As Integer = 0 To 2
                    outputFile.Write(", " & aPricesGrid(nRow, nCol).Text)
                Next
                outputFile.WriteLine()
            Next
            outputFile.Close()
        End If
    End Sub
End Class
