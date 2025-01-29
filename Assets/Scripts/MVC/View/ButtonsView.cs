using Config;
using MVC.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    /// <summary>
    /// 
    /// </summary>
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private Button damageButton;
        [SerializeField] private Button healButton;
        
        private HealthController _controller;

        public void Initialize(HealthController controller, HealthConfig healthConfig)
        {
            _controller = controller;
            
            if (damageButton) damageButton.onClick.AddListener(() => _controller.TakeDamage(healthConfig.damageValue));
            if (healButton) healButton.onClick.AddListener(() => _controller.Heal(healthConfig.healValue));
        }
    }
}