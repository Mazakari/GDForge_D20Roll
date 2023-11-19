using UnityEngine;

public class UI_AudioEffectsSource : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable() =>
        UI_AudioEffect.OnAudioEffectPlay += PlayAudioSound;

    private void OnDisable() =>
        UI_AudioEffect.OnAudioEffectPlay -= PlayAudioSound;

    private void PlayAudioSound(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
