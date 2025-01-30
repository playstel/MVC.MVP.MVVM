namespace Context.Interfaces
{
    public interface IHealthView
    {
        void UpdateHealthText(int currentHealth, int maxHealth);
        void UpdateHealthSlider(int currentHealth, int maxHealth);
        void UpdateHealthInfo(int currentHealth);
    }
}