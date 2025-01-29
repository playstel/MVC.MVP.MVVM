using MVC.Controller;
using TMPro;

namespace MVC.View
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// View отвечает за отображение данных и пользовательский интерфейс.
    /// </summary>
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text healthInfo;
        [SerializeField] private Slider healthSlider;
        public void UpdateHealthText(int currentHealth, int maxHealth)
        {
            if(healthText) healthText.text = $"{currentHealth} / {maxHealth}";
        }

        public void UpdateHealthSlider(int currentHealth, int maxHealth)
        {
            if (healthSlider)
            {
                healthSlider.maxValue = maxHealth;
                healthSlider.value = currentHealth;
            }
        }
        
        public void UpdateHealthInfo(int currentHealth)
        {
            if(healthInfo) healthInfo.text = currentHealth <= 0 ? "Player is dead" : null;
        }
    }
}