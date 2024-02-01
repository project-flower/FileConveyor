using FileConveyor.Constants;
using FileConveyor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileConveyor
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private readonly char[] directorySeparators = new char[] { Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar };
        private readonly Exception initializingException = null;
        private bool messageShowing = false;
        private readonly Queue<string> queueFiles = new Queue<string>();

        #endregion

        #region Public Properties

        public DateTimeSources dateTimeSource
        {
            get
            {
                return (radioButtonFileUpdated.Checked
                    ? DateTimeSources.FileUpdated
                    : radioButtonFileCreated.Checked
                    ? DateTimeSources.FileCreated
                    : DateTimeSources.SystemClock);
            }

            set
            {
                switch (value)
                {
                    case DateTimeSources.FileCreated:
                        radioButtonFileCreated.Checked = true;
                        break;
                    default:
                    case DateTimeSources.FileUpdated:
                        radioButtonFileUpdated.Checked = true;
                        break;
                    case DateTimeSources.SystemClock:
                        radioButtonSystem.Checked = true;
                        break;
                }
            }
        }

        #endregion

        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
            MaximumSize = new Size(int.MaxValue, Height);
            MinimumSize = Size;

            try
            {
                Settings settings = Settings.Default;
                string dateTimeSource_ = settings.DateTime;

                if (dateTimeSource_ == DateTimeSources.FileCreated.ToString())
                {
                    dateTimeSource = DateTimeSources.FileCreated;
                }
                else if (dateTimeSource_ == DateTimeSources.FileUpdated.ToString())
                {
                    dateTimeSource = DateTimeSources.FileUpdated;
                }
                else if (dateTimeSource_ == DateTimeSources.SystemClock.ToString())
                {
                    dateTimeSource = DateTimeSources.SystemClock;
                }

                if (settings.StartsImmediately)
                {
                    DoValidate(true);
                    SetEnable(true);
                }

                numericUpDownDelay.Value = settings.Delay;
            }
            catch (Exception exception)
            {
                initializingException = exception;
            }
        }

        #endregion

        #region Private Methods

        private void DoValidate(bool throwException)
        {
            try
            {
                ValidatePaths();
                ValidatePattern();
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }

                ShowErrorMessage(exception);
            }
        }

        private void MoveFile(string fileName, bool throwException)
        {
            try
            {
                FileOperator.MoveFile(fileName, comboBoxDestination.Text, textBoxRename.Text, dateTimeSource);
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }

                ShowErrorMessage(exception);
            }
        }

        private void SetEnable(bool enabled)
        {
            if (enabled)
            {
                try
                {
                    fileSystemWatcher.Path = comboBoxTargetDirectory.Text;
                    fileSystemWatcher.Filter = textBoxFilter.Text;
                    fileSystemWatcher.EnableRaisingEvents = true;
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                fileSystemWatcher.EnableRaisingEvents = false;
            }

            labelTargetDirectory.Enabled = !enabled;
            comboBoxTargetDirectory.Enabled = !enabled;
            labelFilter.Enabled = !enabled;
            textBoxFilter.Enabled = !enabled;
            labelDestination.Enabled = !enabled;
            comboBoxDestination.Enabled = !enabled;
            labelRename.Enabled = !enabled;
            textBoxRename.Enabled = !enabled;
            groupBoxDateTime.Enabled = !enabled;
            labelDelay.Enabled = !enabled;
            numericUpDownDelay.Enabled = !enabled;
            buttonDisable.Enabled = enabled;
            buttonEnable.Enabled = !enabled;
            buttonMoveNow.Enabled = !enabled;
        }

        private void ShowErrorMessage(Exception exception)
        {
            ShowMessage(exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowErrorMessage(string message)
        {
            ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult ShowMessage(string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (messageShowing)
            {
                return DialogResult.None;
            }

            messageShowing = true;
            DialogResult result = MessageBox.Show(this, message, Text, buttons, icon);
            messageShowing = false;
            return result;
        }

        private void ValidatePaths()
        {
            DirectoryInfo targetDirectory;

            try
            {
                targetDirectory = new DirectoryInfo(comboBoxTargetDirectory.Text.TrimEnd(directorySeparators));
            }
            catch
            {
                throw new Exception("The target directory is invalid.");
            }

            DirectoryInfo destination;

            try
            {
                destination = new DirectoryInfo(comboBoxDestination.Text.TrimEnd(directorySeparators));
            }
            catch
            {
                throw new Exception("The target directory is invalid.");
            }

            if (!targetDirectory.Exists)
            {
                throw new Exception("Target directory does not exist.");
            }

            if (!destination.Exists)
            {
                throw new Exception("Destination directory does not exist.");
            }

            if (string.Compare(destination.FullName, targetDirectory.FullName, true) == 0)
            {
                throw new Exception("The target directory and destination cannot be the same.");
            }
        }

        private void ValidatePattern()
        {
            string pattern = textBoxRename.Text;

            if (Regex.IsMatch(pattern, "\\*[^\\*]*\\*")
                || Regex.IsMatch(pattern, "\\?[^\\?]*\\?"))
            {
                throw new Exception("Specify no more than one asterisk or question mark.");
            }
        }

        #endregion

        // Designer's Methods

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            try
            {
                DoValidate(true);
                SetEnable(true);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void buttonMoveNow_Click(object sender, EventArgs e)
        {
            DoValidate(false);

            if (ShowMessage("Is it okay to move files all at once?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            bool errorOccurred = false;

            foreach (string fileName in Directory.EnumerateFiles(comboBoxTargetDirectory.Text, textBoxFilter.Text))
            {
                if (errorOccurred)
                {
                    if (ShowMessage("Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        != DialogResult.Yes) break;

                    errorOccurred = false;
                }

                try
                {
                    MoveFile(fileName, true);
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception);
                    errorOccurred = true;
                }
            }
        }

        private void comboBoxDirectory_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] dropData) || (dropData.Length < 1))
            {
                return;
            }

                (sender as ComboBox).Text = dropData[0];
        }

        private void comboBoxDirectory_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect
                = (e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.All
                : DragDropEffects.None);
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created) return;

            int delay = (int)numericUpDownDelay.Value;
            string fileName = e.FullPath;

            if (delay > 0)
            {
                timerDelay.Stop();
                queueFiles.Enqueue(fileName);
                timerDelay.Interval = delay;
                timerDelay.Start();
                return;
            }

            MoveFile(fileName, false);
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Settings settings = Settings.Default;
                settings.DateTime = dateTimeSource.ToString();
                settings.Delay = (ushort)numericUpDownDelay.Value;
                settings.Save();
            }
            catch
            {
            }
        }

        private void shown(object sender, EventArgs e)
        {
            if (initializingException != null)
            {
                ShowErrorMessage(initializingException);
            }
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            timerDelay.Stop();
            bool errorOccurred = false;

            while (queueFiles.Count > 0)
            {
                if (errorOccurred)
                {
                    if (ShowMessage("Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        != DialogResult.Yes)
                    {
                        queueFiles.Clear();
                        break;
                    }

                    errorOccurred = false;
                }

                try
                {
                    MoveFile(queueFiles.Dequeue(), true);
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception);
                    errorOccurred = true;
                }
            }

            queueFiles.TrimExcess();
        }
    }
}
