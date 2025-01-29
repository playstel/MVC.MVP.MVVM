using Config;
using MVC.Controller;
using MVC.Model;
using MVC.View;

namespace MVC.Initialize
{
    using UnityEngine;

    /// <summary>
    /// Cоздаёт модель, представление и контроллер, связывая их вместе.
    /// </summary>
    public class SceneInitializer : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private HealthConfig healthConfig;
        
        [Header("View")]
        [SerializeField] private HealthView healthView;
        [SerializeField] private ButtonsView buttonsView;

        private void Start()
        {
            var healthModel = new HealthModel(healthConfig);
            var healthController = new HealthController(healthModel, healthView);

            buttonsView.Initialize(healthController, healthConfig);
        }
    }

}