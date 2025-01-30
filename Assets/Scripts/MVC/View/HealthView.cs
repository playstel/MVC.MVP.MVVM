using Context.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MVC.View
{
    /// <summary>
    /// View отвечает за отображение данных и пользовательский интерфейс.
    /// </summary>
    public class HealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text healthInfo;
        [SerializeField] private Slider healthSlider;
        public void UpdateHealthText(int currentHealth, int maxHealth)
        {
            if(healthText) healthText.text = $"{currentHealth} / {maxHealth} HP";
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
            if(healthInfo) healthInfo.text = currentHealth <= 0 ? "Player is dead" : "";
        }
    }
}