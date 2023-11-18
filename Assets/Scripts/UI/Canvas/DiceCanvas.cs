using UnityEngine;

public class DiceCanvas : MonoBehaviour
{
    [SerializeField] private DiceSprite _diceSprite;

    public void Init()
    {
		try
		{
            _diceSprite.InitDice();

        }
		catch (System.Exception e)
		{

			Debug.Log(e.Message);
		}
    }

    public void SetSprite(int rollResult)
    {
        int spriteIndex = rollResult - 1;
        _diceSprite.SetSpriteByIndex(spriteIndex);
    }

    public void SetModifierSprite() =>
    _diceSprite.SetModifiedSprite();
}
