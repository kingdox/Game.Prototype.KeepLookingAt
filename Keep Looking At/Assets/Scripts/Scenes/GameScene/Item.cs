#region imports
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Set;
using XavHelpTo.Change;
#endregion
[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    #region Variables
    [Header("Item Settings")]
    private BoxCollider2D col2D;
    private RectTransform rect;

    #endregion
    #region Events
    private void Awake()
    {
        gameObject.Component(out col2D);
        gameObject.Component(out rect);
    }
    private void Start()
    { 
        //Code Smells
        col2D.size = (rect.anchorMax - rect.anchorMin * 100).QtyOf(GameManager.screenSize).Positive() / 2;
        rect.localPosition = (GameManager.screenSize).MinusMax();
    }
    #endregion
    #region Methods
    private void OnMouseOver()
    {
        GameManager.AddInLife(40f.QtyOf(GameManager.MAX_LIFE).ZeroMax().Min(25f.QtyOf(GameManager.MAX_LIFE)).ToInt());
        Destroy(gameObject);
    }
    #endregion
}
