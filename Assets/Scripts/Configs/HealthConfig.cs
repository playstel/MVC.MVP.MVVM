namespace Configs
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Configs/Health")]
    public class HealthConfig : ScriptableObject
    {
        public int maxHealth;
        public int startHealth;
        public int damageValue;
        public int healValue;
    }
}