using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class HealthBarPig : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;
    private float health = 500;
    private int lastOink = 0;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject marker;


    void Start()
    {
        marker.SetActive(false);
    }

    public void ToggleMarker(bool markerActive)
    {
        marker.SetActive(markerActive);
    }

    public float GetHealth()
    {
        return health;
    }

    public void GetHit()
    {
        health -= 25;
        healthBar.fillAmount = health / 500;
        audioSource.pitch = Random.Range(0.5f, 1.5f);
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
    }
}
