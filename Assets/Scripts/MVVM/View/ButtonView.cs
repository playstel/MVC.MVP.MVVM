using MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.View
{
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private Button damageButton;
        [SerializeField] private Button healButton;

        public void Bind(HealthViewModel viewModel, int damageValue, int healValue)
        {
            if (damageButton) damageButton.onClick.AddListener(() => viewModel.TakeDamage(damageValue));
            if (healButton) healButton.onClick.AddListener(() => viewModel.Heal(healValue));
        }
    }
}