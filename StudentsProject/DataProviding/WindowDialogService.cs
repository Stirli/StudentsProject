using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using StudentsProject.Models;

namespace StudentsProject.Services
{
    class WindowDialogService : IDialogService
    {
        public bool? ShowMessage(string message)
        {
            var result = MessageBox.Show(message, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
        }

        public bool? ShowUpdateDialog(Student initialValue)
        {
            var studentDialog = new UpdateStudentDialog(initialValue);
            return studentDialog.ShowDialog();
        }

        public bool? OpenFileDialog()
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                FileName = dialog.FileName;
            }

            return result;
        }

        public string FileName { get; set; }
    }
}
