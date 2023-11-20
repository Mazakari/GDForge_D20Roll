using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UiModifierTextMove_Animation : MonoBehaviour
{
    [SerializeField] private RectTransform _textRectTransform;
    private RectTransform _targetRectTransform;
    [SerializeField] private TMP_Text _text;

    [Space(10)]
    [Header("Audio Effects Settings")]
    [SerializeField] private UI_AudioEffect _effect;

    [Space(10)]
    [Header("Animation Scale Settings")]
    [SerializeField] private float _scaleSpeed = 2f;
    [SerializeField] private float _targetScale = 2f;

    [Space(10)]
    [Header("Animation Movement Settings")]
    [SerializeField] private float _moveSpeed = 2f;

    private IModifierService _modifierService;

    public static event Action OnTotalBonusMoveAnimationEnd;

    private void OnEnable()
    {
        SubscribeAnimationsCallbacks();
        SetServiceReference();
        DisableCounterText();
    }

    private void OnDisable() => 
        UnsubscribeAnimationsCallbacks();

    private void StartAnimation()
    {
        CacheMovementTargetPosition();
        SetTotalBonusCounter();
       
        StartCoroutine(StartAnimationScript());
    }

    private IEnumerator StartAnimationScript()
    {
        EnableCounterText();

        yield return StartCoroutine(ScaleAnimation());
        yield return StartCoroutine(MoveAnimation());

        DisableCounterText();
        PlayAudioEffect();

        OnTotalBonusMoveAnimationEnd?.Invoke();
    }

    private void PlayAudioEffect()
    {
        try
        {
            _effect.PlayEffect();
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
        
    }

    private IEnumerator ScaleAnimation()
    { 
        Vector3 newScale = _textRectTransform.localScale;
        float scaleSpeed = _scaleSpeed * Time.deltaTime;

        while (_textRectTransform.localScale.x < _targetScale)
        {
            newScale.x += scaleSpeed;
            newScale.y += scaleSpeed;

            _textRectTransform.localScale = newScale;
            yield return null;
        }
    }
    private IEnumerator MoveAnimation()
    {
        float step = _moveSpeed * Time.deltaTime; // calculate distance to move

        while (Vector3.Distance(_textRectTransform.position, _targetRectTransform.position) > 0.001f)
        {
            _textRectTransform.position = Vector3.MoveTowards(_textRectTransform.position, _targetRectTransform.position, step);
            yield return null;
        }
    }

    private void CacheMovementTargetPosition() =>
        _targetRectTransform = FindObjectOfType<DiceSprite>().GetComponent<RectTransform>();

    private void SetServiceReference() =>
    _modifierService = AllServices.Container.Single<IModifierService>();

    private void SetTotalBonusCounter()
    {
        try
        {
            _text.enabled = false;
            _text.text = $"+ {_modifierService.TotalBonus}";
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
  
    private void SubscribeAnimationsCallbacks() =>
       UIDiceRoll_Animation.OnRollAnimationEnd += StartAnimation;
    private void UnsubscribeAnimationsCallbacks() =>
      UIDiceRoll_Animation.OnRollAnimationEnd -= StartAnimation;

    private void EnableCounterText()
    {
        try
        {
            _text.enabled = true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void DisableCounterText()
    {
        try
        {
            _text.enabled = false;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
