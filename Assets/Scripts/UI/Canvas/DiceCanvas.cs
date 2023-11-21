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
    /// Устанавливает спрайт с нужной стороной
    /// </summary>
    /// <param name="rollResult">Результат броска кубика</param>
    public void SetSprite(int rollResult)
    {
        int spriteIndex = rollResult - 1;
        _diceSprite.SetSpriteByIndex(spriteIndex);
    }

    /// <summary>
    /// Устанавливает спрайт, с учетом бонуса от модификаторов
    /// </summary>
    public void SetModifierSprite() =>
    _diceSprite.SetModifiedSprite();

    /// <summary>
    /// Проигрывает визуальный эффект
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
