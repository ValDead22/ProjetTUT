using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.Command
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Action à éxécuter
        /// </summary>
        private readonly Action _actionToExecute;

        /// <summary>
        /// Action à vérifier pour éxécuter l'action à éxécuter
        /// </summary>
        private readonly Func<object, bool> _checkCanExecute;

        public RelayCommand(Action actionToExecute, Func<object, bool> actionToCheckExecute)
        {
            _actionToExecute = actionToExecute;
            _checkCanExecute = actionToCheckExecute;
        }
      
        /// <summary>
        /// Occurs when the <see cref="CanExecute(object)"/> changed
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Check if we can execute the current command
        /// </summary>
        /// <param name="parameter">The parameter used to check the command</param>
        /// <returns>True if we can check the command, else false</returns>
        public bool CanExecute(object parameter)
        {

            return _checkCanExecute.Invoke(parameter);
        }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter">The parameter to pass to the command</param>
        public void Execute(object parameter)
        {
            _actionToExecute.Invoke();


        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
