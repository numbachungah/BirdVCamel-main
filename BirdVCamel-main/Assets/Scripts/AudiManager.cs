using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiManager : MonoBehaviour
{

    private static AudiManager instance;

    public static AudiManager Instance { get { return instance; } }

    public float sfxVolume;

    private void Awake()
    {
        if(instance != null && instance!= this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
