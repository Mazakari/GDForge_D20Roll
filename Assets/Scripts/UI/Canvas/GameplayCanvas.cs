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

    public RollResultCanvas RollResultCanvas => _rollResultCanvas;
    [SerializeField] private RollResultCanvas _rollResultCanvas;

    [SerializeField] private DifficultyClassCanvas _difficultyCanvas;

    public ModifiersCanvas ModifiersCanvas => _modifiersCanvas;
    [SerializeField] private ModifiersCanvas _modifiersCanvas;

    public TotalBonusCanvas TotalBonusCanvas => _totalBonusCanvas;
    [SerializeField] private TotalBonusCanvas _totalBonusCanvas;

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
            _rollResultCanvas.Init();
            _modifiersCanvas.Init();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
