using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyControll : MonoBehaviour
{
  
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.2f);
    }
}
