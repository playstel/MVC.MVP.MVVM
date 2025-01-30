using MVVM.ViewModel;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.View
{
    /// <summary>
    /// View теперь подписывается на изменения в ViewModel, а не вызывает обновления вручную.
    /// </summary>
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text healthInfo;
        [SerializeField] private Slider healthSlider;

        public void Bind(HealthViewModel viewModel)
        {
            // Подписываем UI на реактивные свойства ViewModel
            viewModel.CurrentHealth.Subscribe(UpdateHealthText).AddTo(this);
            viewModel.CurrentHealth.Subscribe(UpdateHealthInfo).AddTo(this);
            viewModel.CurrentHealth.Subscribe(UpdateHealthSlider).AddTo(this);
            viewModel.MaxHealth.Subscribe(UpdateMaxHealth).AddTo(this);
            
            UpdateMaxHealth(viewModel.MaxHealth.Value);
        }

        private void UpdateHealthText(int currentHealth)
        {
            if (healthText) healthText.text = $"{currentHealth} HP";
        }

        private void UpdateHealthSlider(int currentHealth)
        {
            if (healthSlider) healthSlider.value = currentHealth;
        }

        private void UpdateMaxHealth(int maxHealth)
        {
            if (healthSlider) healthSlider.maxValue = maxHealth;
        }

        private void UpdateHealthInfo(int currentHealth)
        {
            if (healthInfo) healthInfo.text = currentHealth <= 0 ? "Player is dead" : "";
        }
    }
}