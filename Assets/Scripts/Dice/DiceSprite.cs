using UnityEngine;
using UnityEngine.UI;

public class DiceSprite : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Sprite[] _sideSprites;

    private IRollDiceService _rollService;

    public void InitDice()
    {
        _rollService = AllServices.Container.Single<IRollDiceService>();

        try
        {
            _sideSprites = _rollService.DiceSettings.sideSprites;
            int lastSpriteIndex = _sideSprites.Length - 1;
            SetSpriteByIndex(lastSpriteIndex);
        }
        catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }

    public void SetSpriteByIndex(int index) => 
        _image.sprite = _sideSprites[index];
}
