using GlobalContext.Configs;
using GlobalContext.Models;
using MVVM.View;
using MVVM.ViewModel;
using UniRx;
using UnityEngine;

namespace MVVM.LocalContext
{
    /// <summary>
    /// View привязан к ViewModel через поле ReactiveProperty (UniRx) в ViewModel.
    /// ViewModel получает данные из Model и передаёт их View.
    /// View не взаимодействует напрямую с Model.
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
            var model = new HealthModel(healthConfig);
            var viewModel = new HealthViewModel(model);

            viewModel.CurrentHealth
                .Subscribe(value => { healthView.UpdateData(value, viewModel.MaxHealth); })
                .AddTo(this);
            
            buttonsView.Initialize(viewModel, healthConfig);
        }
    }
}