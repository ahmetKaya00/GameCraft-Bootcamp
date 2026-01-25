using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllers : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip m_AudioClip;
    private Transform camera;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_AudioClip;
        camera = Camera.main.transform;
    }
    private void Update()
    {
        float mesafe = Vector3.Distance(transform.position,camera.position);
        float maxMesafe = 10f;
        float normalizedMesafe = Mathf.Clamp01(mesafe/maxMesafe);
        m_AudioSource.volume = 1f - normalizedMesafe;
    }
}
