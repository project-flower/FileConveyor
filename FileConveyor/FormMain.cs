using FileConveyor.Constants;
using FileConveyor.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileConveyor
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private readonly Exception initializingException = null;
        private bool messageShowing = false;

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
                    SetEnable(true);
                }
            }
            catch (Exception exception)
            {
                initializingException = exception;
            }
        }

        #endregion

        #region Private Methods

        private void MoveFile(string fileName, string destination, string pattern)
        {
            if (!ValidatePattern())
            {
                ShowErrorMessage("Specify no more than one asterisk or question mark.");
                return;
            }

            try
            {
                FileOperator.MoveFile(fileName, destination, pattern, dateTimeSource);
            }
            catch (Exception exception)
            {
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

        private bool ValidatePattern()
        {
            string pattern = textBoxRename.Text;

            if (Regex.IsMatch(pattern, "\\*[^\\*]*\\*")
                || Regex.IsMatch(pattern, "\\?[^\\?]*\\?"))
            {
                return false;
            }

            return true;
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
                SetEnable(true);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void buttonMoveNow_Click(object sender, EventArgs e)
        {
            if (ShowMessage("Is it okay to move files all at once?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string destination = comboBoxDestination.Text;
            string pattern = textBoxRename.Text;

            try
            {
                foreach (string fileName in Directory.EnumerateFiles(comboBoxTargetDirectory.Text, textBoxFilter.Text))
                {
                    MoveFile(fileName, destination, pattern);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception);
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

            try
            {
                MoveFile(e.FullPath, comboBoxDestination.Text, textBoxRename.Text);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception);
            }
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Settings settings = Settings.Default;
                settings.DateTime = dateTimeSource.ToString();
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
    }
}
