using UnityEngine;

namespace Config
{
    [CreateAssetMenu(menuName = "Config/Health")]
    public class HealthConfig : ScriptableObject
    {
        public int maxHealth;
        public int damageValue;
        public int healValue;
    }
}