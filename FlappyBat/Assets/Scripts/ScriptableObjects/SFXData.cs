using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu (fileName = "SFXData", menuName = "Custom Scripts/SFX/SFXData", order = 0)]
[Serializable]
public class SFXData : CustomScriptableObject
{
    public AudioClip[] SFX_Flaps;
    public AudioClip[] SFX_Collide;
    public AudioClip[] SFX_GameOver;
}
