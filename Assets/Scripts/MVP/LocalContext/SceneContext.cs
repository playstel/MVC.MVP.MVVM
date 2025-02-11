using GlobalContext.Configs;
using GlobalContext.Models;
using MVP.Presenter;
using MVP.View;
using UnityEngine;

namespace MVP.LocalContext
{
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
            var healthPresenter = new HealthPresenter(healthModel, healthView);

            buttonsView.Initialize(healthModel, healthConfig);
        }
    }
}