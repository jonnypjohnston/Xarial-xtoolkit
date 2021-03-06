﻿//*********************************************************************
//xToolkit
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://xtoolkit.xarial.com
//License: https://xtoolkit.xarial.com/license/
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xarial.XToolkit.Wpf.Utils
{
    public class FileFilter
    {
        public static FileFilter AllFiles { get; } = new FileFilter("All Files", "*.*");
        public static FileFilter ImageFiles { get; } = new FileFilter("Image Files", "*.bmp", "*.png", "*.jpg", "*.jpeg", "*.gif", "*.tif", "*.tiff");

        public string Name { get; }
        public string[] Extensions { get; }

        public FileFilter(string name, params string[] exts)
        {
            Name = name;
            Extensions = exts;
        }
    }

    public static class FileSystemBrowser
    {
        public static bool BrowseFolder(out string path, string desc = "")
        {
            var dlg = new FolderBrowserDialog();
            dlg.Description = desc;
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                path = dlg.SelectedPath;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        public static string BuildFilterString(params FileFilter[] filters)
        {
            return string.Join("|", filters.Select(f =>
            {
                var exts = string.Join(";", f.Extensions);
                return $"{f.Name} ({exts})|{exts}";
            }));
        }

        public static bool BrowseFileOpen(out string path, string title = "", string filter = "")
        {
            var res = BrowseForFile(out string[] paths, new OpenFileDialog(), title, filter);
            path = paths?.FirstOrDefault();
            return res;
        }

        public static bool BrowseFilesOpen(out string[] paths, string title = "", string filter = "")
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            
            return BrowseForFile(out paths, dlg, title, filter);
        }

        public static bool BrowseFileSave(out string path, string title = "", string filter = "")
        {
            var res = BrowseForFile(out string[] paths, new SaveFileDialog(), title, filter);
            path = paths?.FirstOrDefault();
            return res;
        }

        private static bool BrowseForFile(out string[] paths, FileDialog dlg, string title, string filter)
        {
            dlg.Filter = filter;
            dlg.Title = title;
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                paths = dlg.FileNames;
                return true;
            }
            else
            {
                paths = null;
                return false;
            }
        }
    }
}
