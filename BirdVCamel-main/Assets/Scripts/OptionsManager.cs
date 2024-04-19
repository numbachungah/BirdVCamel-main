using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volume;

    public void SetVolume(float bgmvolume)
    {
        AudiManager.Instance.GetComponent<AudioSource>().volume = bgmvolume;
        PlayerPrefs.SetFloat("volume", bgmvolume);
    }

    // Start is called before the first frame update
    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
