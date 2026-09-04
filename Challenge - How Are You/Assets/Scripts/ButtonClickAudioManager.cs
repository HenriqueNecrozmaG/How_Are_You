using UnityEngine;

public class ButtonClickAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource aus;
    public void PlayClickButtonSound()
    {
        aus.Play();
    }
}
