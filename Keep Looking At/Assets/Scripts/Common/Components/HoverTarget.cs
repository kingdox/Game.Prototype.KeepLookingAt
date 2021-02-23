#region imports
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Set;
#endregion
[RequireComponent(typeof(BoxCollider2D))]
public class HoverTarget : MonoBehaviour
{
    #region Variables

    [Header("Hover Settings")]
    public bool isHover = false;

    // 0 = normal, +0 = Crown, -0 = 
    [Space]
    public int scoreAddition = 1;
    public int lifeAddition = 0;
    [Space]
    private BoxCollider2D col2D;
    private RectTransform rect;
    private Vector2 screenSize;

    [Header("Size")]

    private Vector2 actualSize = new Vector2(1, 1);
    private float actualSpeedSize = 5;
    private readonly Vector2 RANGE_SIZE = new Vector2(0.5f, 1.5f);
    private readonly Vector2 RANGE_SPEED_SIZE = new Vector2(.5f, 2f);

    [Header("Movements")]
    private Vector2 actualDestination = new Vector2(0,0);
    private float actualSpeed = 150;
    private readonly Vector2 RANGE_SPEED = new Vector2(150, 300);

    #endregion
    #region Events
    private void Awake()
    {
        gameObject.Component(out col2D);
        gameObject.Component(out rect);

        //col2D.size;
        Vector2 size = rect.anchorMax - rect.anchorMin * 100;
        screenSize = Get.RectScreen();
        Vector2 sizePercent = size.QtyOf(screenSize) / 2;

        col2D.size = sizePercent.Positive();

    }
    private void Update()
    {
        screenSize = Get.RectScreen();

        // POSITION
        if (actualDestination.Equals(rect.localPosition))
        {
            actualDestination = (screenSize / 2).MinusMax();
            actualSpeed = RANGE_SPEED.y.ZeroMax().Min(RANGE_SPEED.x);
        }
        else
        {
            rect.localPosition = Vector2.MoveTowards(rect.localPosition, actualDestination, actualSpeed * Time.deltaTime);
        }

        // SIZE
        if (actualSize.Equals(rect.localScale))
        {
            actualSize = (Vector2.one * RANGE_SIZE.y.ZeroMax().Min(RANGE_SIZE.x));
            actualSpeedSize = RANGE_SPEED_SIZE.y.ZeroMax().Min(RANGE_SPEED_SIZE.x);
        }
        else
        {
            rect.localScale = Vector2.MoveTowards(rect.localScale, actualSize, actualSpeedSize * Time.deltaTime);
        }



    }
    private void OnMouseEnter()
    {
        isHover = true;
        GameManager.CheckHovers += OnHover;
    }
    private void OnMouseExit()
    {
        isHover = false;
        GameManager.CheckHovers -= OnHover;

    }
    private void OnEnable()
    {
        GameManager.CheckScore += ChangeScore;
        GameManager.CheckLife += ChangeLife;
    }
    private void OnDisable()
    {
        GameManager.CheckScore -= ChangeScore;
        GameManager.CheckLife -= ChangeLife;
    }
    #endregion
    #region Methods

    /// <summary>
    /// No hace nada...
    /// </summary>
    private void OnHover() {}

    /// <summary>
    /// Change the <seealso cref="GameManager.scoreActual"/>
    /// </summary>
    private void ChangeScore()
    {
        if (isHover) GameManager.AddInScore(scoreAddition);
    }
    /// <summary>
    /// Change the life of the player
    /// </summary>
    public void ChangeLife()
    {
        if (isHover) GameManager.AddInLife(lifeAddition);
    }


    #endregion
}