using System;
using UnityEngine;

public class UIDiceAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UIDiceRollAnimation _rollAnimaton;

    private const string DICE_ROLL_BOUNCE_ANIMATION_NAME = "DiceRollBouncing_Animation";
    private readonly int DICE_ROLL_BOUNCE_ANIMATION_HASH = Animator.StringToHash(DICE_ROLL_BOUNCE_ANIMATION_NAME);

    public static event Action OnDiceBounceAnimationEnd;

    private void OnEnable() => 
        SubscribeAnimationCallbacks();

    private void OnDisable() => 
        UnsubscribeAnimationCallbacks();

    private void StartAnimation()
    {
        PlayRollAnimation();
        PlayBounceAnimation();
    }
    private void PlayRollAnimation()
    {
        try
        {
            _rollAnimaton.StartAnimation();
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
        
    }
    private void PlayBounceAnimation()
    {
		try
		{
            _animator.StopPlayback();
            _animator.Play(DICE_ROLL_BOUNCE_ANIMATION_HASH);

        }
		catch (Exception e)
		{

			Debug.Log(e.Message);
		}
    }

    /// <summary>
    /// Animation timeline callback on dice bounce is finished
    /// </summary>
    private void OnBounceAnimationEnd() => 
        OnDiceBounceAnimationEnd?.Invoke();

    private void SubscribeAnimationCallbacks() =>
    RollDice.OnRollBegin += StartAnimation;
    private void UnsubscribeAnimationCallbacks() =>
       RollDice.OnRollBegin -= StartAnimation;
}
