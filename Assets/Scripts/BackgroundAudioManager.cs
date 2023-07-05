using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioDay1;
    [SerializeField] private AudioSource audioDay2;
    [SerializeField] private AudioSource trafficNoises;
    private AudioSource backgroundMusic;
    private int day;
    void Start()
    {
        day = GameManager.Instance.DayCount;
        switch(day) {
            case 1:
                backgroundMusic = audioDay1;
                trafficNoises.Play();
                break;
            case 2:
                backgroundMusic = audioDay2;
                break;
        }
        backgroundMusic.Play();
        Debug.Log(backgroundMusic.clip.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
