using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.FtpClient;
using System.Windows.Forms;

namespace FileExtractorApp
{
    public partial class MainForm : Form
    {
        private Button compressButton;
        private Button extractButton;
        private Button ftpButton;
        private Button fileBrowserButton;
        private Button settingsButton;

        public MainForm()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            compressButton = new Button();
            compressButton.Text = "Compress";
            compressButton.Location = new System.Drawing.Point(100, 100);
            compressButton.Click += CompressButton_Click;
            Controls.Add(compressButton);

            extractButton = new Button();
            extractButton.Text = "Extract";
            extractButton.Location = new System.Drawing.Point(200, 100);
            extractButton.Click += ExtractButton_Click;
            Controls.Add(extractButton);

            ftpButton = new Button();
            ftpButton.Text = "FTP";
            ftpButton.Location = new System.Drawing.Point(300, 100);
            ftpButton.Click += FtpButton_Click;
            Controls.Add(ftpButton);

            fileBrowserButton = new Button();
            fileBrowserButton.Text = "File Browser";
            fileBrowserButton.Location = new System.Drawing.Point(400, 100);
            fileBrowserButton.Click += FileBrowserButton_Click;
            Controls.Add(fileBrowserButton);

            settingsButton = new Button();
            settingsButton.Text = "Settings";
            settingsButton.Location = new System.Drawing.Point(500, 100);
            settingsButton.Click += SettingsButton_Click;
            Controls.Add(settingsButton);
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            string sourceDirectory = "C:\\Path\\To\\Source\\Directory";

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = folderBrowserDialog.SelectedPath;
                    string zipFilePath = Path.Combine(destinationPath, "CompressedFile.zip");
                    ZipFile.CreateFromDirectory(sourceDirectory, zipFilePath);
                    MessageBox.Show("Files compressed successfully!");
                }
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            string zipFilePath = "C:\\Path\\To\\Compressed\\File.zip";

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string extractDirectory = folderBrowserDialog.SelectedPath;
                    ZipFile.ExtractToDirectory(zipFilePath, extractDirectory);
                    MessageBox.Show("Files extracted successfully!");
                }
            }
        }

        private void FtpButton_Click(object sender, EventArgs e)
        {
            string ftpHost = "ftp.example.com";
            string ftpUsername = "username";
            string ftpPassword = "password";

            using (FtpClient client = new FtpClient())
            {
                client.Host = ftpHost;
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Connect to FTP server
                client.Connect();

                // FTP contents
                foreach (FtpListItem item in client.GetListing())
                {
                    if (item.Type == FtpFileSystemObjectType.File)
                    {
                        // Download files
                        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                        {
                            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                            {
                                string localDirectoryPath = folderBrowserDialog.SelectedPath;
                                string localFilePath = Path.Combine(localDirectoryPath, item.Name);
                                client.DownloadFile(item.FullName, localFilePath);
                            }
                        }
                    }
                    else if (item.Type == FtpFileSystemObjectType.Directory)
                    {
                        // Download directories
                        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                        {
                            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                            {
                                string localDirectoryPath = folderBrowserDialog.SelectedPath;
                                client.DownloadDirectory(item.FullName, localDirectoryPath);
                            }
                        }
                    }
                }

                // Disconnect from FTP server
                client.Disconnect();
            }

            MessageBox.Show("Files transferred successfully via FTP!");
        }

        private void FileBrowserButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] selectedFiles = openFileDialog.FileNames;
                    // Perform the desired operations on the files
                    // قم بتنفيذ العمليات المطلوبة على الملفات
                }
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Implement theبالطبع يمكن تحويل الكود من C++ إلى C#. ها هو الكود المحدث:

```csharp
using System;
using System.IO;

namespace FileExtractorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to File Extractor App!");

            string sourceDirectory = @"C:\Path\To\Source\Directory";
            string destinationPath = @"C:\Path\To\Destination\Directory";
            string zipFilePath = Path.Combine(destinationPath, "CompressedFile.zip");

            // Compress files
            CompressFiles(sourceDirectory, zipFilePath);
            Console.WriteLine("Files compressed successfully!");

            // Extract files
            ExtractFiles(zipFilePath, destinationPath);
            Console.WriteLine("Files extracted successfully!");
        }

        static void CompressFiles(string sourceDirectory, string zipFilePath)
        {
            System.IO.Compression.ZipFile.CreateFromDirectory(sourceDirectory, zipFilePath);
        }

        static void ExtractFiles(string zipFilePath, string destinationPath)
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, destinationPath);
        }
    }
}
