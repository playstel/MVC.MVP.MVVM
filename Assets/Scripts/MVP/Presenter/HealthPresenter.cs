using GlobalContext.Configs;
using GlobalContext.Interfaces;
using GlobalContext.Models;
using MVP.View;

namespace MVP.Presenter
{
    /// <summary>
    /// Презентер заменяет контроллер и управляет взаимодействием между View и Model.
    /// View стал пассивным компонентом, на который надо подписываться. В него не надо ничего передавать.
    /// </summary>
    public class HealthPresenter
    {
        private readonly HealthModel _healthModel;
        
        private readonly ButtonsView _buttonsView;
        private readonly IHealthView _iHealthView;

        public HealthPresenter(HealthModel healthModel, IHealthView iHealthView, ButtonsView buttonsView, HealthConfig config)
        {
            _healthModel = healthModel;
            
            // Presenter обновляет UI при каждом изменении модели.
            _healthModel.OnHealthChanged += UpdateView;
            
            //Интерфейс IHealthView делает View заменяемой, что облегчает тестирование.
            _iHealthView = iHealthView;

            // Кнопки сообщают Presenter о нажатиях, а не управляют логикой.
            _buttonsView = buttonsView;
            _buttonsView.OnDamageClicked += () => _healthModel.TakeDamage(config.damageValue);
            _buttonsView.OnHealClicked += () => _healthModel.Heal(config.healValue);

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