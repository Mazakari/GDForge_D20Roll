using UnityEngine;
using UnityEngine.UI;

public class DiceSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _sideSprites;

    [SerializeField] private Image _image;

    public void InitSprite()
    {
        try
        {
            int lastSpriteIndex = _sideSprites.Length - 1;
            SetSpriteByIndex(lastSpriteIndex);

            RollService.DiceSides = _sideSprites.Length;

        }
        catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }

    public void SetSpriteByIndex(int index) => 
        _image.sprite = _sideSprites[index];
}
