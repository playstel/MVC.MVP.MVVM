using Config;
using MVC.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private Button damageButton;
        [SerializeField] private Button healButton;
        
        private HealthController _controller;

        public void Initialize(HealthController controller, HealthConfig healthConfig)
        {
            _controller = controller;
            
            damageButton.onClick.AddListener(() => _controller.TakeDamage(healthConfig.damageValue));
            healButton.onClick.AddListener(() => _controller.Heal(healthConfig.healValue));
        }
    }
}