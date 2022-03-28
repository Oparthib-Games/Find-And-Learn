using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_manager : MonoBehaviour
{
    void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
