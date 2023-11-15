using UnityEngine;

public class CanvasService: MonoBehaviour
{
    [SerializeField] private DiceCanvas _diceCanvas;
    [SerializeField] private ButtonsCanvas _buttonsCanvas;
    [SerializeField] private DifficultyClassCanvas _difficultyCanvas;
    [SerializeField] private DiceInfoCanvas _diceInfoCanvas;

    void OnEnable()
    {
        InitCanvases();

        SubscribeCallbacks();
    }

    private void OnDisable() => 
        UnsubscribeCallbacks();

    private void InitCanvases()
    {
        try
        {
            _diceCanvas.Init();
            _buttonsCanvas.Init();
            _difficultyCanvas.Init();
            _diceInfoCanvas.Init();
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
    private void SubscribeCallbacks()
    {
        RollDice.OnRollBegin += _buttonsCanvas.DeactivateRollButton;
        RollDice.OnRollBegin += _diceInfoCanvas.DeactivateHint;
        RollDice.OnRollResultGenerated += _diceCanvas.SetSprite;
        RollDice.OnRollResultGenerated += _diceInfoCanvas.ShowResultText;
    }
    private void UnsubscribeCallbacks()
    {
        RollDice.OnRollBegin -= _buttonsCanvas.DeactivateRollButton;
        RollDice.OnRollBegin -= _diceInfoCanvas.DeactivateHint;
        RollDice.OnRollResultGenerated -= _diceCanvas.SetSprite;
        RollDice.OnRollResultGenerated -= _diceInfoCanvas.ShowResultText;
    }
}
