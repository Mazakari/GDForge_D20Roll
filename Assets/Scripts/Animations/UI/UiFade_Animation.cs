using System;
using System.Collections;
using UnityEngine;

public class UiFade_Animation : MonoBehaviour
{
    [SerializeField] private CanvasGroup _animationCanvasGroup;

    [SerializeField] private float _fadeInStep = 0.03f;

    [Space(10)]
    [Header("Show Animation Settings")]
    [SerializeField] private float _showStartDelay = 0;
    [SerializeField] private float _showStartAlpha = 0;

    [Space(10)]
    [Header("Hide Animation Settings")]
    [SerializeField] private float _hideStartDelay = 0;
    [SerializeField] private float _hideStartAlpha = 1;

    private bool _showAnimationRunning = false;

    private void OnEnable() => 
        SubscribeAnimationCallbacks();

    private void OnDisable() => 
        UnsubscribeAnimationCallbacks();

    public void Show()
    {
        _showAnimationRunning = true;
        SetCanvasGroupAlpha(_showStartAlpha);
        StartCoroutine(FadeOut());
    }

    public void Hide()
    {
        _showAnimationRunning = false;
        SetCanvasGroupAlpha(_hideStartAlpha);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(_showStartDelay);

        while (_animationCanvasGroup.alpha < 1f)
        {
            _animationCanvasGroup.alpha += _fadeInStep;
            yield return new WaitForSeconds(_fadeInStep);
        }
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(_hideStartDelay);

        while (_animationCanvasGroup.alpha > 0)
        {
            _animationCanvasGroup.alpha -= _fadeInStep;
            yield return new WaitForSeconds(_fadeInStep);
        }

        gameObject.SetActive(false);
    }

    private void SetCanvasGroupAlpha(float initValue)
    {
        try
        {
            _animationCanvasGroup.alpha = initValue;
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    private void SubscribeAnimationCallbacks() =>
      RollDice.OnRollBegin += FinishAnimation;
    private void UnsubscribeAnimationCallbacks() =>
       RollDice.OnRollBegin -= FinishAnimation;

    private void FinishAnimation()
    {
        float targetCanvasAlpha = 0;
        if (_showAnimationRunning)
        {
            targetCanvasAlpha = 1f;
        }

        StopAllCoroutines();
        _animationCanvasGroup.alpha = targetCanvasAlpha;
    }
}
