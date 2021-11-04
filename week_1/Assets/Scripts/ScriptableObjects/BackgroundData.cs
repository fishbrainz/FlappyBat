using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu (fileName = "BackgroundData", menuName = "Custom Scripts/Background/BackgroundData", order = 0)]
public class BackgroundData : CustomScriptableObject
{
    public List<GameObject> Levels;
}
