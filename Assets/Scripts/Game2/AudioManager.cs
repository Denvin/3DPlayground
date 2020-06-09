using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region SingleTon
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] AudioSource music;
    [SerializeField] AudioSource effects;

    public void PlaySound(AudioClip audio)
    {
        effects.PlayOneShot(audio);
    }
}
