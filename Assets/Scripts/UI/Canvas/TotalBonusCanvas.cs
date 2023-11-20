using TMPro;
using UnityEngine;

public class TotalBonusCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeIn_Animation _hideFadeAnimation;

    public void UpdateBonusCounter(int totalBonus) => 
        _counter.text = totalBonus.ToString();

    public void HideTotalBonus()
    {
        try
        {
            _hideFadeAnimation.Hide();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
