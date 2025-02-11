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

        public void UpdateData(int currentHealth, int maxHealth)
        {
            Debug.Log($"Health was changed to {currentHealth} by ReactiveProperty CurrentHealth from ViewModel");
            healthText.text = $"{currentHealth} / {maxHealth}";
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
            healthInfo.text = currentHealth <= 0 ? "Player is dead" : "";
        }
    }
}