using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows;

namespace CodeSnippetManager
{
    public class InputDialog : Window
    {
        private TextBox responseTextBox;
        public string ResponseText => responseTextBox.Text;
        public InputDialog(string title, string prompt)
        {
            Title = title;
            Width = 300;
            Height = 150;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var promptLabel = new Label { Content = prompt, Margin = new Thickness(5) };
            Grid.SetRow(promptLabel, 0);

            responseTextBox = new TextBox { Margin = new Thickness(5) };
            Grid.SetRow(responseTextBox, 1);

            var buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(5)
            };
            Grid.SetRow(buttonPanel, 2);

            var okButton = new Button
            {
                Content = "확인",
                Width = 60,
                Margin = new Thickness(5),
                IsDefault = true
            };
            okButton.Click += (s, e) => { DialogResult = true; };

            var cancelButton = new Button
            {
                Content = "취소",
                Width = 60,
                Margin = new Thickness(5),
                IsCancel = true
            };

            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);

            grid.Children.Add(promptLabel);
            grid.Children.Add(responseTextBox);
            grid.Children.Add(buttonPanel);

            Content = grid;
        }
    }
}
