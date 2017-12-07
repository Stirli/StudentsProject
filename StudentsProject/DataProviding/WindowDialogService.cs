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
    /// <summary>
    /// Предоставляет методы для открытия диалоговых окон
    /// </summary>
    class WindowDialogService : IDialogService
    {
        public bool ShowMessage(string message)
        {
            var result = MessageBox.Show(message, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Данные, введенные пользователем остануться в initialValue
        public bool? ShowUpdateDialog(Student initialValue)
        {
            var studentDialog = new UpdateStudentDialog(initialValue);
            return studentDialog.ShowDialog();
        }

        public bool OpenFileDialog(out string fileName)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                fileName = dialog.FileName;
                return true;
            }

            fileName = String.Empty;
            return false;
        }
    }
}
