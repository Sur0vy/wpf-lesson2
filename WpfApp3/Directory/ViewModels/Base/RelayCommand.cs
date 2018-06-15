using System;
using System.Windows.Input;

namespace WpfApp3
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// the action to run
        /// </summary>
        private Action action;

        #endregion

        #region public events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            this.action = action;
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// A realy command alwais execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// execute the command action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action();
        }
        #endregion
    }
}
