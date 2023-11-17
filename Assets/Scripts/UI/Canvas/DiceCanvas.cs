using System;
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

    public void SetSprite(int index) =>
        _diceSprite.SetSpriteByIndex(index);

    public void SetModifierSprite(int index) =>
    _diceSprite.SetModifiedSpriteByIndex(index);
}
