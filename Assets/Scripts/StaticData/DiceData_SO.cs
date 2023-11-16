using UnityEngine;

[CreateAssetMenu (fileName ="DiceData_SO", menuName ="StaticData/DiceData")]
public class DiceData_SO : ScriptableObject
{
    public int sidesAmount = 0;

    public Sprite[] sideSprites = null;
    public Sprite[] rollAnimationSprites = null;
}
