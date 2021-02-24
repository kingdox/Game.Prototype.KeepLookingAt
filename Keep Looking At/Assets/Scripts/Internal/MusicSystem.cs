using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Set;


public class MusicSystem : MonoBehaviour
{
    private static MusicSystem _;
    private void Awake()
    {
        //Singletone reference
        gameObject.Singletone(ref _, this);
    }
}
