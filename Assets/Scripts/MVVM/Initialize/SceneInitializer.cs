using Configs;
using Models;
using UnityEngine;
using MVVM.View;
using MVVM.ViewModel;

namespace MVVM.Initialize
{
    public class SceneInitializer : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private HealthConfig healthConfig;

        [Header("View")]
        [SerializeField] private HealthView healthView;
        [SerializeField] private ButtonsView buttonsView;

        private void Start()
        {
            var model = new HealthModel(healthConfig);
            var viewModel = new HealthViewModel(model);

            healthView.Bind(viewModel);
            buttonsView.Bind(viewModel, healthConfig.damageValue, healthConfig.healValue);
        }
    }
}