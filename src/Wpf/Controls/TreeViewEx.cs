﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Xarial.XToolkit.Wpf.Controls
{
    public class TreeViewEx : TreeView
    {
        public TreeViewEx()
            : base()
        {
            SelectedItemChanged += OnSelectedItemChanged;
        }

        private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetValue(SelectedItemProperty, e.NewValue);
        }

        public new object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly new DependencyProperty SelectedItemProperty
            = DependencyProperty.Register(nameof(SelectedItem), typeof(object),
                typeof(TreeViewEx), new FrameworkPropertyMetadata(
                    null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnSelectedItemPropertyChanged));

        private static void OnSelectedItemPropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var treeViewItem = (d as TreeView).ItemContainerGenerator
                    .ContainerFromItem(e.NewValue) as TreeViewItem;

                if (treeViewItem != null)
                {
                    treeViewItem.IsSelected = true;
                }
            }
        }
    }
}
