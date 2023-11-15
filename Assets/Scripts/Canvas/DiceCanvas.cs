using UnityEngine;

public class DiceCanvas : MonoBehaviour
{
    [SerializeField] private DiceSprite _diceSprite;

    public void Init()
    {
		try
		{
            _diceSprite.InitSprite();

        }
		catch (System.Exception e)
		{

			Debug.Log(e.Message);
		}
    }

    public void SetSprite(int index) =>
        _diceSprite.SetSpriteByIndex(index);
}
