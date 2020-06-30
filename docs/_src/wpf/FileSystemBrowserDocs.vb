﻿Imports System
Imports Xarial.XToolkit.Wpf.Utils

Namespace Wpf.Docs

    Module FileSystemBrowserDocs

        Sub BrowseFolder()

            '--- browse-folder
            Dim path As String = Nothing

            If FsoBrowser.BrowseForFolder(path, "Select sample folder") Then
                Console.WriteLine($"Selected path: {path}")
            Else
                Console.WriteLine("User has cancelled the folder browsing")
            End If
            '---

        End Sub

        Sub BrowseFile()

            '--- browse-file-filter
            Dim filters = FsoBrowser.BuildFilterString(
                New FileFilter("Text Files", "*.txt", "*.doc", "*.md"),
                FileFilter.ImageFiles,
                FileFilter.AllFiles)
            '---

            '--- browse-file-open
            Dim fileIn As String = Nothing

            If FsoBrowser.BrowseForFileOpen(fileIn, "Select input file", filters) Then
                Console.WriteLine($"Selected path: {fileIn}")
            Else
                Console.WriteLine("User has cancelled the file browsing")
            End If
            '---

            '--- browse-file-save
            Dim fileOut As String = Nothing

            If FsoBrowser.BrowseForFileSave(fileOut, "Select output file", filters) Then
                Console.WriteLine($"Selected path: {fileOut}")
            Else
                Console.WriteLine("User has cancelled the file browsing")
            End If
            '---

        End Sub

    End Module

End Namespace
