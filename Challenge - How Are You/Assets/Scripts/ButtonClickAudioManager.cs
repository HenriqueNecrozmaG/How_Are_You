using UnityEngine;

public class ButtonClickAudioManager : MonoBehaviour
{
    private AudioSource aus;

    void Awake()
    {
        aus = GetComponent<AudioSource>();
    }

    public void PlayClickButtonSound()
    {
        aus.Play();
    }
}
