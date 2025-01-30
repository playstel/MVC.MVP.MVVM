using MVVM.ViewModel;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.View
{
    /// <summary>
    /// View теперь подписывается на изменения CurrentHealth в ViewModel, а не вызывает обновления вручную.
    /// </summary>
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text healthInfo;
        [SerializeField] private Slider healthSlider;

        public void Bind(HealthViewModel viewModel)
        {
            viewModel.CurrentHealth.Subscribe(currentHealth =>
            {
                Debug.Log($"Health was changed to {currentHealth} by ReactiveProperty CurrentHealth from ViewModel");
                healthText.text = $"{currentHealth} / {viewModel.MaxHealth}";
                healthSlider.maxValue = viewModel.MaxHealth;
                healthSlider.value = currentHealth;
                healthInfo.text = currentHealth <= 0 ? "Player is dead" : "";
            }).AddTo(this);
        }
    }
}