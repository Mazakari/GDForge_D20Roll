using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDiceRollAnimation : MonoBehaviour
{
    public static event Action OnRollEnd;

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
        SubscribeAnimationCallbacks();
        ResetCurrentAnimationSpriteIndex();
        SetAnimationSpritesReference();
        InitAnumationCoroutine();
    }

    private void OnDisable() => 
        UnsubscribeAnimationCallbacks();
    private void GetServiceReference() =>
       _rollService = AllServices.Container.Single<IRollDiceService>();
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
        catch (System.Exception e)
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
            _active = false;

            OnRollEnd?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void StartAnimation()
    {
        _active = true;
        StartCoroutine(_animationCoroutine);
    }

    private void ResetCurrentAnimationSpriteIndex() =>
       _currentIndex = 0;

    private void SubscribeAnimationCallbacks() =>
     RollDice.OnRollBegin += StartAnimation;
    private void UnsubscribeAnimationCallbacks() =>
       RollDice.OnRollBegin -= StartAnimation;
}