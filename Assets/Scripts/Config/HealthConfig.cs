namespace Config
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Config/Health")]
    public class HealthConfig : ScriptableObject
    {
        public int maxHealth;
        public int startHealth;
        public int damageValue;
        public int healValue;
    }
}