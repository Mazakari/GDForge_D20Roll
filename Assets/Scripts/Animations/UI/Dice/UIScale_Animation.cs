using System.Collections;
using UnityEngine;

public class UIScale_Animation : MonoBehaviour
{
    [SerializeField] private RectTransform _diceImageRectTransform;

    [Space(10)]
    [Header("Animation Scale Settings")]
    [SerializeField] private float _scaleSpeed = 2f;
    [SerializeField] private float _targetScale = 2f;
    [SerializeField] private bool _pingPong = false;

    private void OnEnable() => 
        SubscribeAnimationsCallbacks();

    private void OnDisable() =>
        UnsubscribeAnimationsCallbacks();

    private void StartAnimation()
    {
        if (_pingPong)
        {
            StartCoroutine(ScalePinPongAnimation());
            return;
        }

        StartCoroutine(ScaleAnimation());
    }

    private IEnumerator ScaleAnimation()
    {
        bool playAnimation = true;

        Vector3 newScale = _diceImageRectTransform.localScale;
        float scaleSpeed = _scaleSpeed * Time.deltaTime;

        while (playAnimation)
        {
            newScale.x = Mathf.MoveTowards(newScale.x, _targetScale, scaleSpeed);
            newScale.y = Mathf.MoveTowards(newScale.y, _targetScale, scaleSpeed);

            if (_diceImageRectTransform.localScale.x >= _targetScale)
            {
                playAnimation = false;
                newScale = Vector2.one * _targetScale;
            }

            _diceImageRectTransform.localScale = newScale;
            
            yield return null;
        }
    }

    private IEnumerator ScalePinPongAnimation()
    {
        bool playAnimation = true;

        Vector3 initialScale = _diceImageRectTransform.localScale;
        Vector3 newScale = initialScale;

        float scaleSpeed = _scaleSpeed * Time.deltaTime;
        bool pong = false;

        while (playAnimation)
        {
            if (_diceImageRectTransform.localScale.x >= _targetScale)
            {
                _targetScale = initialScale.x;
                pong = true;
            }

            newScale.x = Mathf.MoveTowards(newScale.x, _targetScale, scaleSpeed);
            newScale.y = Mathf.MoveTowards(newScale.y, _targetScale, scaleSpeed);

            if (_diceImageRectTransform.localScale.x <= _targetScale && pong)
            {
                playAnimation = false;
                newScale = initialScale;
            }

            _diceImageRectTransform.localScale = newScale;

            yield return null;
        }
    }

    private void SubscribeAnimationsCallbacks() =>
       UiModifierTextMove_Animation.OnTotalBonusMoveAnimationEnd += StartAnimation;
    private void UnsubscribeAnimationsCallbacks() =>
      UiModifierTextMove_Animation.OnTotalBonusMoveAnimationEnd -= StartAnimation;
  
}
