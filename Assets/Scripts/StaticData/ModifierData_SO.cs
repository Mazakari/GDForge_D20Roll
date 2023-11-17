using UnityEngine;

[CreateAssetMenu(fileName = "ModifierData_SO", menuName = "StaticData/ModifierData")]
public class ModifierData_SO : ScriptableObject
{
    public ModifierType type;

    public int value;
    public string abilityName;
    public Sprite sprite;
}
