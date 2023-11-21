using UnityEngine;

public class DiceCanvas : MonoBehaviour
{
    [SerializeField] private DiceSprite _diceSprite;

    [Space(10)]
    [Header("Particles Effects")]
    [SerializeField] private UI_ParticlesEffect _particlesEffect;


    public void Init()
    {
		try
		{
            _diceSprite.InitDice();

        }
		catch (System.Exception e)
		{

			Debug.Log(e.Message);
		}
    }

    /// <summary>
    /// ������������� ������ � ������ ��������
    /// </summary>
    /// <param name="rollResult">��������� ������ ������</param>
    public void SetSprite(int rollResult)
    {
        int spriteIndex = rollResult - 1;
        _diceSprite.SetSpriteByIndex(spriteIndex);
    }

    /// <summary>
    /// ������������� ������, � ������ ������ �� �������������
    /// </summary>
    public void SetModifierSprite() =>
    _diceSprite.SetModifiedSprite();

    /// <summary>
    /// ����������� ���������� ������
    /// </summary>
    public void PlayParticles()
    {
        try
        {
            _particlesEffect.PlayEffect();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
