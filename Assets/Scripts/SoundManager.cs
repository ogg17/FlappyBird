using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    [SerializeField] private AudioClip soundtrack;
    [SerializeField] private AudioClip tap;
    [SerializeField] private AudioClip lose;
    [SerializeField] private AudioClip score;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = soundtrack;
        OnIsSoundChange();

        EventsInstance.Events.GameOver += OnGameOver;
        EventsInstance.Events.OnTap += OnTap;
        EventsInstance.Events.ScoreChange += OnScoreChange;
        EventsInstance.Events.SoundChange += OnIsSoundChange;
    }

    private void OnIsSoundChange()
    {
        if (gameData.isSound)
            _audioSource.Play();
        else 
            _audioSource.Stop();
    }

    private void OnGameOver()
    {
        if (gameData.isSound)
            _audioSource.PlayOneShot(lose);
    }

    private void OnScoreChange(int s)
    {
        if (gameData.isSound)
            _audioSource.PlayOneShot(score);
    }

    private void OnTap()
    {
        if (gameData.isSound)
            _audioSource.PlayOneShot(tap);
    }
}
