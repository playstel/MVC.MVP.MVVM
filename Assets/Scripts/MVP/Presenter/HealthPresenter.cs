using GlobalContext.Configs;
using GlobalContext.Interfaces;
using GlobalContext.Models;
using MVP.View;

namespace MVP.Presenter
{
    /// <summary>
    /// Presenter обновляет UI при каждом изменении модели.
    /// Интерфейс IHealthView делает View заменяемой, что облегчает тестирование.
    /// </summary>
    public class HealthPresenter
    {
        private readonly HealthModel _healthModel;
        
        private readonly ButtonsView _buttonsView;
        private readonly IHealthView _iHealthView;

        public HealthPresenter(HealthModel healthModel, IHealthView iHealthView)
        {
            _healthModel = healthModel;
            
            _healthModel.OnHealthChanged += UpdateView;
            
            _iHealthView = iHealthView;

            UpdateView(_healthModel.CurrentHealth);
        }

        private void UpdateView(int currentHealth)
        {
            _iHealthView.UpdateHealthText(currentHealth, _healthModel.MaxHealth);
            _iHealthView.UpdateHealthSlider(currentHealth, _healthModel.MaxHealth);
            _iHealthView.UpdateHealthInfo(currentHealth);
        }
    }
}