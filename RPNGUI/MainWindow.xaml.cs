using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using RPNLogic;

namespace RPNGUI {

    public partial class MainWindow : Window {
        private StringBuilder stringBuilder;
        private string result;
        public MainWindow() {
            InitializeComponent();
            Calculator.Init();
            foreach (UIElement child in RootElement.Children) {
                if (child is Button) {
                    ((Button) child).Click += ButtonClicked;
                }
            }
            stringBuilder = new StringBuilder();
        }

        public void ButtonClicked(object o, RoutedEventArgs ea) {
            string value = (string) ((Button) ea.OriginalSource).Content;
            if (value == "=" && result == null) {
                if (IsRPN.IsChecked == true) {
                    result = NotationConverter.ToPostFix(stringBuilder.ToString());
                }
                else {
                    try {
                        result = Calculator.Calculate(NotationConverter.ToPostFix(stringBuilder.ToString())).ToString();
                    }
                    catch (InvalidOperationException) {
                        result = "Действие невозможно";
                    }
                    catch (DivideByZeroException) {
                        result = "Деление на ноль невозможно";
                    }
                }
            }
            stringBuilder.Append(value);
            if (value == "CLEAR") {
                stringBuilder.Clear();
                result = null;
            }
            Prompt.Text = result != null ? result : stringBuilder.ToString();
        }
    }
}