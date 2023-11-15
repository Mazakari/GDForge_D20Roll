using System;
using TMPro;
using UnityEngine;

public class DiceInfoCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _diceInfoHint;
    [SerializeField] private GameObject _rollResult;

    [SerializeField] private TMP_Text _successText;
    [SerializeField] private TMP_Text _failText;

    public void Init()
    {
		try
        {
            ActivateHint();
        }
        catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }
    public void ShowSucessText(bool success)
    {
        try
        {
            _successText.gameObject.SetActive(success);
            _failText.gameObject.SetActive(!success);

            _rollResult.SetActive(true);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    public void ActivateHint()
    {
        _diceInfoHint.SetActive(true);
        _rollResult.SetActive(false);    
    }

    public void DeactivateHint() => 
        _diceInfoHint.SetActive(false);

    public void ShowResultText(int rollResult)
    {
        bool success = rollResult > RollService.RollDifficultyClass;
        ShowSucessText(success);
    }
}
