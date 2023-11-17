public interface IModifierService : IService
{
    int TotalBonus { get; }

    void ConstructModifier(Modifier modifier);
    int GetTotalModifiersBonus();
    void SetActiveModifiers(Modifier[] activeModifiers);
}