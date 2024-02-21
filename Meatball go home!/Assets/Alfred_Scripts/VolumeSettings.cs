using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider volumeSlider;

    public const string MIXER_VOLUME = "Volume";

    void Awake()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(AudioManager.AUDIO_KEY, 0.5f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.AUDIO_KEY, volumeSlider.value);
    }

    void SetVolume(float value)
    {
        mixer.SetFloat(MIXER_VOLUME, Mathf.Log10(value) * 20);
    }
}
