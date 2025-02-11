using GlobalContext.Configs;
using GlobalContext.Models;
using MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.View
{
    /// <summary>
    /// View не знает о Presenter и просто отправляет события в Presenter.
    /// </summary>
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private Button damageButton;
        [SerializeField] private Button healButton;

        public void Initialize(HealthModel viewModel, HealthConfig healthConfig)
        {
            if (damageButton) damageButton.onClick.AddListener(() => viewModel.TakeDamage(healthConfig.damageValue));
            if (healButton) healButton.onClick.AddListener(() => viewModel.Heal(healthConfig.healValue));
        }
    }
}