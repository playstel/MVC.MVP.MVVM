using GlobalContext.Configs;
using GlobalContext.Models;
using MVC.Controller;
using MVC.View;
using UnityEngine;

namespace MVC.LocalContext
{
    /// <summary>
    /// Локальный контекст, в котором создаются и соединяются Model, View и Controller.
    /// </summary>
    public class SceneContext : MonoBehaviour
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