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
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private HealthView healthView;
        [SerializeField] private ButtonsView buttonsView;
        [SerializeField] private HealthConfig healthConfig;

        private void Start()
        {
            var healthModel = new HealthModel(healthConfig.maxHealth);
            var healthController = new HealthController(healthModel, healthView);

            healthView.Initialize(healthController);
            buttonsView.Initialize(healthController, healthConfig);
        }
    }

}