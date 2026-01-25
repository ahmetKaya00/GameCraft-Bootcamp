using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_AudioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_AudioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        { 
            m_AudioSource.Pause(); 
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
        }
    }
}
