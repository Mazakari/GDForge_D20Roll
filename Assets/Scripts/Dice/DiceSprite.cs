using System;
using UnityEngine;
using UnityEngine.UI;

public class DiceSprite : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Sprite[] _sideSprites;

    private IRollDiceService _rollService;

    private void OnDisable() =>
       UnsubscribeRollStateCallbacks();

    public void InitDice()
    {
        _rollService = AllServices.Container.Single<IRollDiceService>();
        SubscribeRollStateCallbacks();

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

    public void SetSpriteByIndex(int index)
    {
        try
        {
            _image.sprite = _sideSprites[index];
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    private void ActivateDiceImage()
    {
        try
        {
            _image.enabled = true;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }

    private void DeactivateDiceImage()
    {
        try
        {
            _image.enabled = false;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void SubscribeRollStateCallbacks()
    {
        RollDice.OnRollBegin += DeactivateDiceImage;
        UIDiceRollAnimation.OnRollEnd += ActivateDiceImage;
    }
    private void UnsubscribeRollStateCallbacks()
    {
        RollDice.OnRollBegin -= DeactivateDiceImage;
        UIDiceRollAnimation.OnRollEnd -= ActivateDiceImage;
    }
}
