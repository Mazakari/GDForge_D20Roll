using TMPro;
using UnityEngine;

public class DifficultyClassCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text _classValueText;
    private int _value;

    public void Init() => 
        SetRandomClassValue();

    private void SetRandomClassValue()
    {
        try
        {
            SetRandomValue();
            _classValueText.text = _value.ToString();
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
        
    }

    private void SetRandomValue()
    {
        int diceSides = RollService.DiceSides;
        _value = Random.Range(0, diceSides);
        RollService.RollDifficultyClass = _value;
    }
}
