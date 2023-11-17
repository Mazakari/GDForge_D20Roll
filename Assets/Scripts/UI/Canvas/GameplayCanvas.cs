using System;
using UnityEngine;

public class GameplayCanvas : MonoBehaviour
{
    public DiceCanvas DiceCanvas =>_diceCanvas;
    [SerializeField] private DiceCanvas _diceCanvas;

    public ButtonsCanvas ButtonsCanvas => _buttonsCanvas;
    [SerializeField] private ButtonsCanvas _buttonsCanvas;

    public DiceInfoCanvas DiceInfoCanvas => _diceInfoCanvas;
    [SerializeField] private DiceInfoCanvas _diceInfoCanvas;

    [SerializeField] private DifficultyClassCanvas _difficultyCanvas;
    [SerializeField] private ModifiersCanvas _modifiersCanvas;

    void OnEnable() => 
        InitCanvases();

    private void InitCanvases()
    {
        try
        {
            _diceCanvas.Init();
            _buttonsCanvas.Init();
            _difficultyCanvas.Init();
            _diceInfoCanvas.Init();
            _modifiersCanvas.Init();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
