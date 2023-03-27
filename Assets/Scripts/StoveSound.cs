using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSound : MonoBehaviour
{
    [SerializeField] private Stove stove;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        stove.OnStateChanged += Stove_OnStateChanged;
    }

    private void Stove_OnStateChanged(object sender, Stove.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == Stove.State.Frying || e.state == Stove.State.Fried;

        if (playSound)
            audioSource.Play();
        else
            audioSource.Pause();
    }
}
