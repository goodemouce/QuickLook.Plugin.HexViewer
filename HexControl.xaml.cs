using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace QuickLook.Plugin.HexViewer
{
    /// <summary>
    /// HexControl.xaml 的交互逻辑
    /// </summary>
    public partial class HexControl : UserControl, INotifyPropertyChanged
    {
        private BinaryReader binaryReader;

        public HexControl()
        {
            InitializeComponent();
        }

        public HexControl(String file): this()
        {
            OpenFile(file);
        }

        public void OpenFile(String file)
        {
            Reader = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read));
        }

        public BinaryReader Reader
        {
            get => binaryReader;

            set
            {
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }

                binaryReader = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
