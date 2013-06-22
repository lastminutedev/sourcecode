using System;

namespace SecurityApp
{
    using System.ComponentModel;

    public class SecurityDataController : INotifyPropertyChanged
    {
        #region Fields

        private SecurityState securityState;
        private bool? isReadOnly;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        public SecurityDataController()
            : this(SecurityState.NotDefinedMode)
        { }

        public SecurityDataController(SecurityState securityState)
        {
            this.SecurityState = securityState;
            this.SetToDefaultMode();
        }

        #endregion

        #region Properties

        public SecurityState SecurityState
        {
            get { return this.securityState; }
            set
            {
                if (this.securityState != value)
                {
                    this.securityState = value;
                    this.SetToDefaultMode();
                    this.RaisePropertyChangedEvent("SecurityState");
                }
            }
        }

        public bool? IsReadOnly
        {
            get { return this.isReadOnly; }
            private set
            {
                if (this.isReadOnly != value)
                {
                    this.isReadOnly = value;
                    this.RaisePropertyChangedEvent("IsReadOnly");
                }
            }
        }

        #endregion

        #region Methods

        private void SetToDefaultMode()
        {
            if (this.SecurityState == SecurityState.ErrorMode)
            {
                throw new Exception("Application security error mode!");
            }

            if (this.SecurityState == SecurityState.ReadOnlyMode)
            {
                this.IsReadOnly = true; 
            }
            else
            {
                this.IsReadOnly = false;
            }
        }

        public void SwitchToReadOnlyMode()
        {
            if (this.SecurityState == SecurityState.ErrorMode)
            {
                throw new Exception("Application security error mode!");
            }

            this.IsReadOnly = true;
        }

        public bool TrySwitchToEditMode()
        {
            if (this.SecurityState == SecurityState.ErrorMode)
            {
                throw new Exception("Application security error mode!");
            }

            if (this.SecurityState == SecurityState.ReadOnlyMode)
            {
                return false;
            }

            this.IsReadOnly = false;

            return true;
        }

        #endregion

        #region Event Handlers

        private void RaisePropertyChangedEvent(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}