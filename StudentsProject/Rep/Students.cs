using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Annotations;
using StudentsProject.Models;

namespace StudentsProject.Rep
{
    class Students : IEnumerable<Student>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private IDataContext _context;
        private bool _isEmpty;

        public Students(IDataContext context)
        {
            _context = context;
            OnPropertyChanged(nameof(IsEmpty));
        }

        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                if (value == _isEmpty) return;
                _isEmpty = value;
                OnPropertyChanged();
            }
        }

        public void Create(Student obj)
        {
            _context.Students.Add(obj);
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<Student> { obj });
            OnCollectionChanged(args);
            IsEmpty = false;
        }

        public void Remove(Student obj)
        {
            _context.Students.Remove(obj);
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new List<Student> { obj });
            OnCollectionChanged(args);
            IsEmpty = _context.Students.Any();
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return _context.Students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
