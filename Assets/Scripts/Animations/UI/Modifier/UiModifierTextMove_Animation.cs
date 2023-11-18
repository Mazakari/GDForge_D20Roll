using DG.Tweening;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class UiModifierTextMove_Animation : MonoBehaviour
{
    [SerializeField] private RectTransform _textRectTransform;
    private RectTransform _targetRectTransform;
    [SerializeField] private TMP_Text _text;


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
        StartMoveAnimation();
    }

    private void StartMoveAnimation()
    {
        try
        {
            EnableCounterText();
            MoveAndScaleAnimation();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private async void MoveAndScaleAnimation()
    {
        await ScaleText();
        await MoveText();
        DisableCounterText();

        OnTotalBonusMoveAnimationEnd?.Invoke();
    }

    private async Task ScaleText() => 
        await _textRectTransform.DOScale(Vector3.one * _targetScale, _scaleSpeed).AsyncWaitForCompletion();
    private async Task MoveText() => 
        await _textRectTransform.DOMove(_targetRectTransform.position, _moveSpeed).AsyncWaitForCompletion();

    private void CacheMovementTargetPosition() =>
        _targetRectTransform = FindObjectOfType<DiceSprite>().GetComponent<RectTransform>();

    private void SetServiceReference() =>
    _modifierService = AllServices.Container.Single<IModifierService>();

    private void SetTotalBonusCounter()
    {
        try
        {
            _text.enabled = false;
            _text.text = _modifierService.TotalBonus.ToString();
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
