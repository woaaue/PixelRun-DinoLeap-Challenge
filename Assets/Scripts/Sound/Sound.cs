using UnityEngine;
using System.Collections.Generic;

public sealed class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _soundsEffects;

    public void PlaySound(int indexSound)
    {
        _audioSource.PlayOneShot(_soundsEffects[indexSound]);
    }
}
