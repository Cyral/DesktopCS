﻿using System;
using System.Windows;
using DesktopCS.Controls;
using DesktopCS.MVVM;
using DesktopCS.ViewModels;
using DesktopCS.Views;

namespace DesktopCS.Models
{
    public class Tab
    {
        private readonly ChatTabContentViewModel _tabVM;
        
        public string Header
        {
            get { return (string)this.TabItem.Header; }
            set
            {
                var original = (string)this.TabItem.Header;
                if (original == value) return;

                this.TabItem.Header = value;
                this.OnHeaderChange(original);
            }
        }

        public CSTabItem TabItem { get; private set; }

        public bool IsSelected
        {
            get
            {
                return this.TabItem.IsSelected;
            }
            set
            {
                this.TabItem.IsSelected = value;
            }
        }

        public delegate void HeaderChangeHandler(object sender, string oldValue);
        public event HeaderChangeHandler HeaderChange;

        protected virtual void OnHeaderChange(string oldvalue)
        {
            HeaderChangeHandler handler = this.HeaderChange;
            if (handler != null) handler(this, oldvalue);
        }

        public event EventHandler<EventArgs> Close;

        protected virtual void OnClose()
        {
            EventHandler<EventArgs> handler = this.Close;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public Tab(string header)
        {
            this._tabVM = new ChatTabContentViewModel();
            var tabView = new ChatTabContentView(this._tabVM);
            this.TabItem = new CSTabItem { Content = tabView };
            this.Header = header;

            this.TabItem.CloseTab += this.TabItem_CloseTab;
        }

        void TabItem_CloseTab(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            this.OnClose();
        }

        public void AddChat(ChatLine line)
        {
            if (line is MessageLine)
                this.MarkUnread();

            this._tabVM.FlowDocument.Blocks.Add(line.ToParagraph());
        }

        public virtual void MarkUnread()
        {
            if (!this.IsSelected)
                this.TabItem.IsUnread = true;
        }
    }
}