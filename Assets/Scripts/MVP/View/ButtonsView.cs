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

        public event System.Action OnDamageClicked;
        public event System.Action OnHealClicked;

        private void Awake()
        {
            if(damageButton) damageButton.onClick.AddListener(() => OnDamageClicked?.Invoke());
            if(healButton) healButton.onClick.AddListener(()=>OnHealClicked?.Invoke());
        }
    }
}