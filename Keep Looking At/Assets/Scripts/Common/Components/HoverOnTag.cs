#region imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
[RequireComponent(typeof(Collider2D))]
public class HoverOnTag : MonoBehaviour
{
    #region Variables

    [Header("Hover Settings")]
    public string tagToDetect;
    public bool isHover = false;
    #endregion
    #region Events
    private void OnMouseEnter()
    {
        isHover = true;
    }
    private void OnMouseExit()
    {
        isHover = false;   
    }
    #endregion
    #region Methods

    #endregion
}