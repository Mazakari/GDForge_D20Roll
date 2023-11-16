using TMPro;
using UnityEngine;

public class DifficultyClassCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text _classValueText;

    private IRollDiceService _rollService;

    public void Init()
    {
        GetServiceReference();
        SetDifficultyText();
    }

    private void GetServiceReference() => 
        _rollService = AllServices.Container.Single<IRollDiceService>();

    private void SetDifficultyText()
    {
        try
        {
            _classValueText.text = _rollService.RollDifficulty.ToString();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }
}
