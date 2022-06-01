using System;
using System.Windows.Forms;

namespace WindowsFormsApplicationTest
{
    public partial class MainForm : Form
    {
        private readonly Library _library;

        public MainForm()
        {
            InitializeComponent();
            _library = new Library();
            libraryBindingSource.DataSource = _library;
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _library.Load(openFileDialog.FileName);
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                _library.Save(saveFileDialog.FileName);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}