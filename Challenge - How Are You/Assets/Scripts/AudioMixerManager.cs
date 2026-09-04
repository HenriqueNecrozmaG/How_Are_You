using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Slider slider;
    public string floatParameter;
    private static float sliderValue;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.value = sliderValue;
    }

    public void OnVolumeChange(float v)
    {
        audioMixer.SetFloat(floatParameter, v);
        sliderValue = slider.value;
    }
}