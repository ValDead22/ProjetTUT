using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace ApplicationJampay.ViewModel.Behavior
{
    public class PasswordBehavior : Behavior<PasswordBox>
    {

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(PasswordBehavior),
                new PropertyMetadata(OnSourcePropertyChanged));

        public SecureString Password
        {
            get => (SecureString)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += OnPasswordBoxValueChanged;
        }

        private static void OnSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                var behavior = d as PasswordBehavior;
                behavior.AssociatedObject.PasswordChanged -= OnPasswordBoxValueChanged;
                behavior.AssociatedObject.Password = string.Empty;
                behavior.AssociatedObject.PasswordChanged += OnPasswordBoxValueChanged;
            }
        }

        private static void OnPasswordBoxValueChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var behavior = Interaction.GetBehaviors(passwordBox).OfType<PasswordBehavior>().FirstOrDefault();
            if (behavior != null)
            {
                var binding = BindingOperations.GetBindingExpression(behavior, PasswordProperty);
                if (binding != null)
                {
                    var property = binding.DataItem.GetType().GetProperty(binding.ParentBinding.Path.Path);
                    if (property != null)
                        property.SetValue(binding.DataItem, passwordBox.SecurePassword, null);
                }
            }
        }
    }
}
