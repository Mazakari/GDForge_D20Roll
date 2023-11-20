using UnityEngine;

public class UI_ParticlesEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectsParticleSystem;

    public void PlayEffect()
    {
		try
		{
            _effectsParticleSystem.Stop();
            _effectsParticleSystem.Play();

        }
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }
}
