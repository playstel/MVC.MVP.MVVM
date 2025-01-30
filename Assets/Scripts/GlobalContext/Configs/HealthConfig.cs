using UnityEngine;

namespace GlobalContext.Configs
{
    [CreateAssetMenu(menuName = "Configs/Health")]
    public class HealthConfig : ScriptableObject
    {
        public int maxHealth;
        public int startHealth;
        public int damageValue;
        public int healValue;
    }
}