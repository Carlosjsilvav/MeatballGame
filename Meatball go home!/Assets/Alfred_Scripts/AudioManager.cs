using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    public const string AUDIO_KEY = "audioVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume()  //Volume saved in VolumeSettings script
    {
        float audioVolume = PlayerPrefs.GetFloat(AUDIO_KEY, 0.5f);

        mixer.SetFloat(VolumeSettings.MIXER_VOLUME, Mathf.Log10(audioVolume) * 20);
    }
}
