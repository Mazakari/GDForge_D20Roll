using UnityEngine;

/// <summary>
/// Сервис для хранения информации по текущим модификаторам и их бонуса
/// </summary>
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

    /// <summary>
    /// Метод инициализирует переданный модификатор соответствующими данными из Static Data
    /// </summary>
    /// <param name="modifier">Модификатор для инициализации</param>
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

    /// <summary>
    /// Устанавливает ссылку на коллекцию текущих модификаторов
    /// </summary>
    /// <param name="activeModifiers">Коллекция текущих модификаторов</param>
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

    /// <summary>
    /// Суммирует общий бонус со всех текущих модификаторов
    /// </summary>
    /// <returns></returns>
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
            GetModifiersStaticData();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Получат коллекцию Static Data для всех существующих модификаторов
    /// </summary>
    private void GetModifiersStaticData() => 
        _modifiersData = _gameFactory.GetModifiersStaticData(AssetPath.MODIFIERS_STATIC_DATA_FOLDER);

    /// <summary>
    /// Устанавливает значение для общей суммы всех модификаторо
    /// </summary>
    /// <param name="total">Общая сумма бонусов всех модификаторов</param>
    private void SetTotalBonus(int total) => 
        TotalBonus = total;
}
