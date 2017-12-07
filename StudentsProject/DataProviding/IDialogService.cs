using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Models;

namespace StudentsProject.Services
{
    /// <summary>
    /// Предоставляет методы для вызова диалогов
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Выводит вопрос и возвращает true, если пользователь ответил утвердительно, false если отрицательно.
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>true, если пользователь ответил утвердительно, false если отрицательно</returns>
        bool ShowMessage(string message);

        /// <summary>
        /// Выводит сообщение об ошибке
        /// </summary>
        /// <param name="message">сообщение об ошибке</param>
        void ShowError(string message);

        /// <summary>
        /// Открывает диалог изменения инфо о студенте
        /// </summary>
        /// <param name="initialValue">Начальные значения для студента</param>
        /// <returns></returns>
        bool? ShowUpdateDialog(Student initialValue);

        /// <summary>
        /// Запрашивает выбор пути к файлу. Выбранный будет записан в FileName
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        /// <returns>true, если файл был выбран успешно.</returns>
        bool OpenFileDialog(out string fileName);
    }
}
