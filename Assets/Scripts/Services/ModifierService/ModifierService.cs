using UnityEngine;

/// <summary>
/// ������ ��� �������� ���������� �� ������� ������������� � �� ������
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
    /// ����� �������������� ���������� ����������� ���������������� ������� �� Static Data
    /// </summary>
    /// <param name="modifier">����������� ��� �������������</param>
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
    /// ������������� ������ �� ��������� ������� �������������
    /// </summary>
    /// <param name="activeModifiers">��������� ������� �������������</param>
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
    /// ��������� ����� ����� �� ���� ������� �������������
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
    /// ������� ��������� Static Data ��� ���� ������������ �������������
    /// </summary>
    private void GetModifiersStaticData() => 
        _modifiersData = _gameFactory.GetModifiersStaticData(AssetPath.MODIFIERS_STATIC_DATA_FOLDER);

    /// <summary>
    /// ������������� �������� ��� ����� ����� ���� ������������
    /// </summary>
    /// <param name="total">����� ����� ������� ���� �������������</param>
    private void SetTotalBonus(int total) => 
        TotalBonus = total;
}
