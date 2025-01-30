namespace Context.Interfaces
{
    /// <summary>
    /// В MVC данный интерфейс не выполняет ключевых функций
    /// В MVP данный интерфейс является DI инструментом и обновляет View со стороны Presenter
    /// В MVVM данный интерфейс отсутствует из-за отличия архитектуры View
    /// </summary>
    public interface IHealthView
    {
        void UpdateHealthText(int currentHealth, int maxHealth);
        void UpdateHealthSlider(int currentHealth, int maxHealth);
        void UpdateHealthInfo(int currentHealth);
    }
}