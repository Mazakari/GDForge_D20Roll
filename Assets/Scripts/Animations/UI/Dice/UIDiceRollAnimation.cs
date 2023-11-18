using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDiceRollAnimation : MonoBehaviour
{
    public static event Action OnRollAnimationEnd;

    [SerializeField] private Image _image;

    [SerializeField] private float _speed = 0.1f;

    private Sprite[] _sprites;

    private int _currentIndex = 0;
    private bool _active = false;

    private IRollDiceService _rollService;

    private IEnumerator _animationCoroutine;

    private void OnEnable()
    {
        GetServiceReference();
        SubscribeAnimationsCallbacks();

        ResetCurrentAnimationSpriteIndex();
        SetAnimationSpritesReference();

        InitAnumationCoroutine();
        DisableAnimationImage();
    }

    private void OnDisable() => 
        UnsubscribeAnimationsCallbacks();

    public void StartAnimation()
    {
        EnableAnimationImage();
        _active = true;
        StartCoroutine(_animationCoroutine);
    }
    private void SetAnimationSpritesReference()
    {
        try
        {
            _sprites = _rollService.DiceSettings.rollAnimationSprites;
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    private void InitAnumationCoroutine()
    {
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
            _animationCoroutine = null;
        }

        _animationCoroutine = Animation();
    }
   
    private IEnumerator Animation()
    {
        while(_active)
        {
            ChangeSprite();

            yield return new WaitForSeconds(_speed);

            IncrementCurrentSpriteIndex();
        }
    }

    private void ChangeSprite()
    {
        try
        {
            _image.sprite = _sprites[_currentIndex];
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void IncrementCurrentSpriteIndex()
    {
        _currentIndex++;

        if (_currentIndex >= _sprites.Length)
        {
            ResetCurrentAnimationSpriteIndex();
        }
    }

    private void ResetCurrentAnimationSpriteIndex() =>
       _currentIndex = 0;

    private void EnableAnimationImage() =>
       _image.enabled = true;
    private void DisableAnimationImage() =>
       _image.enabled = false;

    private void StopRollAnimation()
    {
        Debug.Log("Bounce animation ended");
        _active = false;
        DisableAnimationImage();
        OnRollAnimationEnd?.Invoke();
    }
    private void GetServiceReference() =>
      _rollService = AllServices.Container.Single<IRollDiceService>();
    private void SubscribeAnimationsCallbacks() =>
       UIDiceAnimator.OnDiceBounceAnimationEnd += StopRollAnimation;
    private void UnsubscribeAnimationsCallbacks() =>
      UIDiceAnimator.OnDiceBounceAnimationEnd -= StopRollAnimation;
}
