using System;
using UnityEngine;

public class CanvasAnimator : MonoBehaviour
{
    [SerializeField] private GameplayCanvas _gameplayCanvas;

    private IRollDiceService _rollDiceService;
    private IModifierService _modifierService;

    void OnEnable()
    {
        SerSevicesReferences();
        SubscribeCallbacks();
    }

    private void OnDisable() =>
        UnsubscribeCallbacks();

  

    private void SubscribeCallbacks()
    {
        RollDice.OnRollBegin += _gameplayCanvas.ButtonsCanvas.DeactivateRollButton;
        RollDice.OnRollBegin += _gameplayCanvas.DiceInfoCanvas.DeactivateHint;
        RollDice.OnRollResultGenerated += _gameplayCanvas.DiceCanvas.SetSprite;
        UIDiceRoll_Animation.OnRollAnimationEnd += AddModifiersBonusToRollResult;
        // ToDo Play particles on dice sprite
        UiModifierTextMove_Animation.OnTotalBonusMoveAnimationEnd += _gameplayCanvas.DiceCanvas.SetModifierSprite;
        // ToDo Play particles on show result
        DiceSprite.OnModifiedSpriteSet += _gameplayCanvas.DiceInfoCanvas.ShowResultText;// ToDo Add DOFade
        // ToDo Hide modifiers canvas group DOFade
        DiceSprite.OnModifiedSpriteSet += _gameplayCanvas.ButtonsCanvas.ActivateContinueButton;// ToDo Add DOFade
    }

    private void UnsubscribeCallbacks()
    {
        RollDice.OnRollBegin -= _gameplayCanvas.ButtonsCanvas.DeactivateRollButton;
        RollDice.OnRollBegin -= _gameplayCanvas.DiceInfoCanvas.DeactivateHint;
        RollDice.OnRollResultGenerated -= _gameplayCanvas.DiceCanvas.SetSprite;
        UIDiceRoll_Animation.OnRollAnimationEnd -= AddModifiersBonusToRollResult;
        DiceSprite.OnModifiedSpriteSet -= _gameplayCanvas.DiceInfoCanvas.ShowResultText;
        DiceSprite.OnModifiedSpriteSet -= _gameplayCanvas.ButtonsCanvas.ActivateContinueButton;
    }

    private void AddModifiersBonusToRollResult()
    {
        int bonus = _modifierService.TotalBonus;
        _rollDiceService.AddModifierBonusToRollResult(bonus);
    }
    private void SerSevicesReferences()
    {
        _rollDiceService = AllServices.Container.Single<IRollDiceService>();
        _modifierService = AllServices.Container.Single<IModifierService>();
    }
}
