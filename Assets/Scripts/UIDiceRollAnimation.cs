using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDiceRollAnimation : MonoBehaviour
{
    public static event Action OnRollEnd;

    [SerializeField] private Image _image;

    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private Sprite[] _sprites;
    private int _currentIndex = 0;
    private bool _active = false;

    private IEnumerator _animationCoroutine;

    private void OnEnable()
    {
        RollDice.OnRollBegin += StartAnimation;

        _currentIndex = 0;

        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
            _animationCoroutine = null;
        }

        _animationCoroutine = Animation();
    }

    private void OnDisable()
    {
        RollDice.OnRollBegin -= StartAnimation;
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

    private void IncrementCurrentSpriteIndex()
    {
        _currentIndex++;

        if (_currentIndex >= _sprites.Length)
        {
            _currentIndex = 0;
            _active = false;

            OnRollEnd?.Invoke();
            gameObject.SetActive(false);

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

    private void StartAnimation()
    {
        _active = true;
        StartCoroutine(_animationCoroutine);
    }
}
