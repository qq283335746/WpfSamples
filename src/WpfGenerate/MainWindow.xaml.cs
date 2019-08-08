using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yibi.WpfGenerate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bind();
        }

        private void Bind()
        {
            txtCode.Text = TxtCode;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtCode.Text = TxtCode;
        }

        public string TxtCode
        {
            get
            {
                
                var code = GenerateHelper.CreateGenerateCode(PasswordType);
                Clipboard.SetText(code);
                return code;
            }
        }

        public PasswordType PasswordType { get; set; }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            switch (rbtn.Name)
            {
                case "rbtnDefaultType":
                    PasswordType = PasswordType.Default;
                    break;
                case "rbtnStrongType":
                    PasswordType = PasswordType.Stronger;
                    break;
                default:
                    PasswordType = PasswordType.Default;
                    break;
            }

            if(txtCode != null)
            {
                txtCode.Text = TxtCode;
            }
        }
    }
}
