﻿using CircuitDiagram.DPIWindow;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CircuitDiagram
{
    /// <summary>
    /// Interaction logic for winNewDocument.xaml
    /// </summary>
    public partial class winNewDocument : MetroDPIWindow
    {
        Regex numMatch;

        public double DocumentWidth { get { return double.Parse(tbxDocWidth.Text); } }
        public double DocumentHeight { get { return double.Parse(tbxDocHeight.Text); } }

        public winNewDocument()
        {
            InitializeComponent();

            numMatch = new Regex("[0-9]{0,5}");

            tbxDocWidth.Text = "640";
            tbxDocHeight.Text = "480";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ValidateNumericInput(object sender, TextCompositionEventArgs e)
        {
            Match match = numMatch.Match(((TextBox)sender).Text + e.Text);
            e.Handled = match.Length != (((TextBox)sender).Text + e.Text).Length;
        }

        private void tbxDocWidthHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnOK.IsEnabled = (tbxDocWidth.Text.Length > 0 && tbxDocHeight.Text.Length > 0);
        }
    }
}
