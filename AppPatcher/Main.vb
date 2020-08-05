'AppPatcher created for replacing Files with supplied Files
'created by: Steven Dietz (dAr2q)
'Date: 05/08/2020
'Updated: 06/08/2020
Imports System.Xml

Public Class MainForm
    Dim CFG As String = "config.xml"
    Dim AppName As String
    Dim xmlDoc As New XmlDocument()
    Dim i As Integer
    Dim xmlnode As XmlNodeList

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Computer.FileSystem.FileExists(CFG) = False Then
            MsgBox("Datei: " & CFG & " fehlt bitte Ordner kontrollieren", MsgBoxStyle.Critical, "Fehler")
            Application.Exit()
        End If
        Try
            xmlDoc.Load(CFG)
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/Patcher/App")
            For Each node As XmlNode In nodes
                If node.SelectSingleNode("title") Is Nothing Then
                    MsgBox("Keine gültige Konfig gefunden.", vbCritical, "Error")
                    Application.Exit()
                Else
                    Debugger1.Items.Add("Patcher für: " & node.SelectSingleNode("title").InnerText)
                    Debugger1.Items.Add("")
                    If node.SelectSingleNode("rep") Is Nothing Then
                        MsgBox("Keine gültige Konfig gefunden.", vbCritical, "Error")
                        Application.Exit()
                    End If
                    xmlnode = xmlDoc.GetElementsByTagName("rep")
                    Debugger1.Items.Add("Diese Dateien wurden gefunden: ")
                    Debugger1.Items.Add("")
                    For i = 0 To xmlnode.Count - 1
                        If My.Computer.FileSystem.FileExists(xmlnode(i).ChildNodes.Item(0).InnerText.Trim) = False Then
                            MsgBox("Nicht alle erforderlichen Dateien wurden gefunden." & vbNewLine & "Fehlende Datei: " & xmlnode(i).ChildNodes.Item(0).InnerText.Trim, vbCritical)
                            Application.Exit()
                        End If
                        Debugger1.Items.Add(xmlnode(i).ChildNodes.Item(0).InnerText.Trim())
                    Next
                    If node.SelectSingleNode("path") Is Nothing Then
                        MsgBox("Keine gültige Konfig gefunden.", MsgBoxStyle.Critical, "Error")
                        Application.Exit()
                    Else
                        Dim PPath As String = node.SelectSingleNode("path").InnerText
                        If My.Computer.FileSystem.DirectoryExists(PPath) = False Then
                            MsgBox("Der Zielordner existiert nicht. Bitte Hauptprogramm installieren.", vbCritical)
                            Application.Exit()
                        End If
                        Debugger1.Items.Add("")
                        Debugger1.Items.Add("Zielordner wurde gefunden unter:")
                        Debugger1.Items.Add(PPath)
                    End If
                End If
            Next
            Main_text.Text = "Bereit zum Patchen."
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub start_patch_Click(sender As Object, e As EventArgs) Handles start_patch.Click
        start_patch.Enabled = False
        ProgressBar1.Value = 0
        Try
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/Patcher/App")
            For Each node As XmlNode In nodes
                xmlnode = xmlDoc.GetElementsByTagName("rep")
                Debugger1.Items.Add("")
                For i = 0 To xmlnode.Count - 1
                    Dim PPath As String = node.SelectSingleNode("path").InnerText
                    Dim file_node As String = xmlnode(i).ChildNodes.Item(0).InnerText.Trim
                    Dim TR_text As String = file_node.Substring(file_node.IndexOf("files\") + 6)
                    'MsgBox(xmlnode(i).ChildNodes.Item(0).InnerText.Trim & vbNewLine & PPath & "\" & TR_text)
                    My.Computer.FileSystem.MoveFile(PPath & "\" & TR_text, PPath & "\" & TR_text & ".u2l", True)
                    Debugger1.Items.Add("Alte Datei unter " & TR_text & ".u2l" & " gesichert")
                    Debugger1.SelectedIndex = -1
                    ProgressBar1.Increment(25)
                    My.Computer.FileSystem.CopyFile(xmlnode(i).ChildNodes.Item(0).InnerText.Trim, PPath & "\" & TR_text, True)
                    Debugger1.Items.Add("Neue Datei: " & TR_text & " kopiert")
                    Debugger1.SelectedIndex = -1
                    ProgressBar1.Increment(25)
                Next
            Next
            Main_text.Text = "Dateien erfolgreich kopiert"
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Main_text.Text = "Fehler beim kopieren der Dateien."
        End Try
    End Sub
End Class
