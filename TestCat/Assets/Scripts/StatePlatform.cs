using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPlatform")]
public class StatePlatform : ScriptableObject
{
    [SerializeField]private Sprite[] platform;

    public Sprite[] PlatformState => platform;
}
