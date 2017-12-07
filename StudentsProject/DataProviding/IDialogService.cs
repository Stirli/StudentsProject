using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Models;

namespace StudentsProject.Services
{
    public interface IDialogService
    {
        bool? ShowMessage(string message);
        void ShowError(string message);
        bool? ShowUpdateDialog(Student initialValue);
        bool? OpenFileDialog();
        string FileName { get; set; }
    }
}
