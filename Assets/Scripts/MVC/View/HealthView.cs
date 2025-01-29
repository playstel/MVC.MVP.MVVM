using MVC.Controller;

namespace MVC.View
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// View отвечает за отображение данных и пользовательский интерфейс.
    /// </summary>
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Text healthText;
        [SerializeField] private Slider healthSlider;

        private HealthController _controller;

        public void Initialize(HealthController controller)
        {
            _controller = controller;
        }

        public void UpdateHealthText(int currentHealth, int maxHealth)
        {
            healthText.text = $"{currentHealth} / {maxHealth}";
        }

        public void UpdateHealthSlider(int currentHealth, int maxHealth)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
}