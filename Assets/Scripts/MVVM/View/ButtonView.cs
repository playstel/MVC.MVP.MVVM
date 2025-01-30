using Context.Configs;
using MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.View
{
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private Button damageButton;
        [SerializeField] private Button healButton;

        public void Bind(HealthViewModel viewModel, HealthConfig healthConfig)
        {
            if (damageButton) damageButton.onClick.AddListener(() => viewModel.TakeDamage(healthConfig.damageValue));
            if (healButton) healButton.onClick.AddListener(() => viewModel.Heal(healthConfig.healValue));
        }
    }
}