using BCSsolution.organization.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSsolution.organization.model
{
    class SupplierView : INotifyPropertyChanged
    {
        private Supplier _supplier;

        public Supplier InnerSupplier { get { return _supplier; } }

        public SupplierView()
        {
            _supplier = new Supplier();
        }

        public SupplierView(Supplier supplier)
        {
            _supplier = supplier;
        }

        public virtual int Id
        {
            get { return _supplier.Id; }
            set
            {
                _supplier.Id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public virtual string FirstName
        {
            get { return _supplier.FirstName; }
            set
            {
                _supplier.FirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public virtual string LastName
        {
            get { return _supplier.LastName; }
            set
            {
                _supplier.LastName = value;
                NotifyPropertyChanged("LastName");
            }
        }
        public virtual string Grs
        {
            get { return _supplier.Grs; }
            set
            {
                _supplier.Grs = value;
                NotifyPropertyChanged("Grs");
            }
        }
        public virtual string Ids
        {
            get { return _supplier.Ids; }
            set
            {
                _supplier.Ids = value;
                NotifyPropertyChanged("Ids");
            }
        }
        public virtual string Email
        {
            get { return _supplier.Email; }
            set
            {
                _supplier.Email = value;
                NotifyPropertyChanged("Email");
            }
        }
        public virtual string Tel1
        {
            get { return _supplier.Tel1; }
            set
            {
                _supplier.Tel1 = value;
                NotifyPropertyChanged("Tel1");
            }
        }
        public virtual string Mob1
        {
            get { return _supplier.Mob1; }
            set
            {
                _supplier.Mob1 = value;
                NotifyPropertyChanged("Mob1");
            }
        }
        public virtual string LblPrintText
        {
            get { return _supplier.LblPrintText; }
            set
            {
                _supplier.LblPrintText = value;
                NotifyPropertyChanged("LblPrintText");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }

        #endregion
    }
}
