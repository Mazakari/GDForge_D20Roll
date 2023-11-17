using UnityEngine;

[RequireComponent(typeof(UIModifier))]
public class Modifier : MonoBehaviour
{
    public ModifierType type;

    public int Value { get; private set; }
    public string AbilityName { get; private set; }
    public Sprite Sprite { get; private set; }

    private UIModifier _modifierUi;

    public void Construct(ModifierData_SO data)
    {
        Value = data.value;
        AbilityName = data.abilityName;
        Sprite = data.sprite;

        InitNodifierUI();
    }

    private void InitNodifierUI()
    {
        try
        {
            _modifierUi = GetComponent<UIModifier>();
            _modifierUi.InitCellUI(this);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
