using UnityEngine;

public class ModifierService : IModifierService
{
    public int TotalBonus {  get; private set; }

    private Modifier[] _activeModifiers;

    private ModifierData_SO[] _modifiersData;

    private readonly IGameFactory _gameFactory;

    public ModifierService(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;

        InitService();
    }
    public void ConstructModifier(Modifier modifier)
    {
        for (int i = 0; i < _modifiersData.Length; i++)
        {
            if (_modifiersData[i].type == modifier.type)
            {
                modifier.Construct(_modifiersData[i]);
            }
        }
    }

    public void SetActiveModifiers(Modifier[] activeModifiers)
    {
        try
        {
            _activeModifiers = activeModifiers;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }
    public int GetTotalModifiersBonus()
    {
        int total = 0;
        foreach (Modifier modifier in _activeModifiers)
        {
            total += modifier.Value;
        }

        SetTotalBonus(total);

        return total;
    }

    private void InitService()
    {
        try
        {
            _modifiersData = _gameFactory.GetModifiersStaticData(AssetPath.MODIFIERS_STATIC_DATA_FOLDER);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void SetTotalBonus(int total) => 
        TotalBonus = total;
}
