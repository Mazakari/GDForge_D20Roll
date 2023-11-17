using TMPro;
using UnityEngine;

public class TotalBonusCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    public void UpdateBonusCounter(int totalBonus) => 
        _counter.text = totalBonus.ToString();
}
