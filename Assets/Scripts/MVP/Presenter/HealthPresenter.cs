using Configs;
using Interfaces;
using Models;
using MVP.View;

namespace MVP.Presenter
{
    /// <summary>
    /// Презентер заменяет контроллер и управляет взаимодействием между View и Model.
    /// View стала "глупой" и не знает о модели, теперь она просто отображает данные.
    /// Presenter обновляет UI при каждом изменении модели.
    /// Интерфейс IHealthView делает View заменяемой, что облегчает тестирование.
    /// Кнопки сообщают Presenter о нажатиях, а не управляют логикой.
    /// </summary>
    public class HealthPresenter
    {
        private readonly HealthModel _healthModel;
        private readonly IHealthView _healthView;
        private readonly ButtonsView _buttonsView;

        public HealthPresenter(HealthModel healthModel, IHealthView healthView, ButtonsView buttonsView, HealthConfig config)
        {
            _healthModel = healthModel;
            _healthView = healthView;
            _buttonsView = buttonsView;

            _healthModel.OnHealthChanged += UpdateView;

            _buttonsView.OnDamageClicked += () => _healthModel.TakeDamage(config.damageValue);
            _buttonsView.OnHealClicked += () => _healthModel.Heal(config.healValue);

            UpdateView(_healthModel.CurrentHealth);
        }

        private void UpdateView(int currentHealth)
        {
            _healthView.UpdateHealthText(currentHealth, _healthModel.MaxHealth);
            _healthView.UpdateHealthSlider(currentHealth, _healthModel.MaxHealth);
            _healthView.UpdateHealthInfo(currentHealth);
        }
    }
}