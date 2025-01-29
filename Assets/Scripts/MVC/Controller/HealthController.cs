using MVC.Model;
using MVC.View;

namespace MVC.Controller
{
    /// <summary>
    /// Контроллер управляет логикой приложения, связывая модель и представление.
    /// </summary>
    public class HealthController
    {
        private HealthModel _model;
        private HealthView _view;

        public HealthController(HealthModel model, HealthView view)
        {
            _model = model;
            _view = view;

            _model.OnHealthChanged += UpdateView;
            
            UpdateView(_model.CurrentHealth);
        }

        public void TakeDamage(int damage)
        {
            _model.TakeDamage(damage);
        }

        public void Heal(int amount)
        {
            _model.Heal(amount);
        }

        private void UpdateView(int currentHealth)
        {
            _view.UpdateHealthText(currentHealth, _model.MaxHealth);
            _view.UpdateHealthSlider(currentHealth, _model.MaxHealth);
            _view.UpdateHealthInfo(currentHealth);
        }
    }

}