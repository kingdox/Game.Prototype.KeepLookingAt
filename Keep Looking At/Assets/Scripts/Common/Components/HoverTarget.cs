#region imports
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Set;
using XavHelpTo.Know;
#endregion
[RequireComponent(typeof(BoxCollider2D))]
public class HoverTarget : MonoBehaviour
{
    #region Variables

    [Header("Hover Settings")]
    public bool isHover = false;

    private BoxCollider2D col2D;
    private RectTransform rect;

    [Header("Size")]
    private const float SIZE_TIMER = 5f;
    private float actualTimer = 5f;
    private float sizeCountTime = 0;
    private readonly Vector2 LIMIT_MAGNITUDE = new Vector2(.25f, 2);
    private float actualMagnitude = 0.1f;
    private const float MAGNITUDE_SPEED = 0.05f;
    private bool isShrink = false;
    #endregion
    #region Events
    private void Awake()
    {
        gameObject.Component(out col2D);
        gameObject.Component(out rect);

        //col2D.size;
        Vector2 size = rect.anchorMax - rect.anchorMin * 100;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        Vector2 sizePercent = size.QtyOf(screenSize) / 2;
        //$"size: {size}, Screen.width -> {sizePercent} ".Print();

        col2D.size = sizePercent.Positive();

    }
    private void Update()
    {

        //TODO
        //if (actualTimer.TimerIn(ref sizeCountTime))
        //{
        //    RefreshSize();
        //}
        //else
        //{
        //    new float magnitude = isShrink ? -MAGNITUDE_SPEED : MAGNITUDE_SPEED;

        //    rect.localScale = (Vector3.one - Vector3.forward) * actualMagnitude;

        //    actualMagnitude += isShrink ? -MAGNITUDE_SPEED : MAGNITUDE_SPEED;
        //    actualMagnitude = Mathf.Clamp(actualMagnitude, LIMIT_MAGNITUDE[0], LIMIT_MAGNITUDE[1]);
        //}
        
    }
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

    private void RefreshSize()
    {
        actualTimer = SIZE_TIMER;
        actualMagnitude = Get.Range(LIMIT_MAGNITUDE[0], LIMIT_MAGNITUDE[1]);
        isShrink = Get.RandomBool();
    }
    #endregion
}