using System;
using UnityEngine;

public class UI_AudioEffect : MonoBehaviour
{
    public static event Action<AudioClip> OnAudioEffectPlay;

    [SerializeField] private AudioClip _sound;

    public void PlayEffect()
    {
        if (_sound)
        {
            OnAudioEffectPlay?.Invoke(_sound);
        }
    }
}
