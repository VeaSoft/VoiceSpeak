using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
namespace VoiceSpeak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string openFilePath;
        string saveFilePath;
        FileInterfacer fInterfacer;
        Thread speakerThread;
        Speaker mySpeaker;
        public MainWindow()
        {
            InitializeComponent();
            fInterfacer = new FileInterfacer();
            mySpeaker = new Speaker();
            speakerThread = new Thread(new ParameterizedThreadStart(mySpeaker.speak));
        }

        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog oFileDialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult userResult = oFileDialog.ShowDialog();
            if (userResult == System.Windows.Forms.DialogResult.OK)
            {
                openFilePath = oFileDialog.FileName;
                textBox1.Text = fInterfacer.read(openFilePath);
            }
        }

        private void VoiceSpeak_Click(object sender, RoutedEventArgs e)
        {           
             speakerThread.Start(textBox1.Text);           
        }

        
        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
                                   
        }

        

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfDialog = new System.Windows.Forms.SaveFileDialog();
            
            System.Windows.Forms.DialogResult result = sfDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string[] values= new string[2];
                values[0] = sfDialog.FileName;
                values[1] = textBox1.Text;
                FileInterfacer fInterfacer = new FileInterfacer();
                Thread writerThread = new Thread(new ParameterizedThreadStart(fInterfacer.write));
                writerThread.Start(values);
                
                MessageBox.Show("Operation completed");
            }
        }

    }
}
