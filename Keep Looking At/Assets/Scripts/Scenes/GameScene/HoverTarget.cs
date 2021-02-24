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
    public float coliderDivisor = 1;
    [Space]
    public int scoreAddition = 1;
    public int lifeAddition = 0;
    [Space]
    private BoxCollider2D col2D;
    private RectTransform rect;

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

       

    }
    private void Start()
    {
        //col2D.size;
        Vector2 size = rect.anchorMax - rect.anchorMin * 100;
        Vector2 sizePercent = size.QtyOf(GameManager.screenSize);
        col2D.size = sizePercent.Positive() / coliderDivisor;
        rect.localPosition = (GameManager.screenSize).MinusMax();
    }
    private void Update()
    {

        // POSITION
        if (actualDestination.Equals(rect.localPosition))
        {
            actualDestination = (GameManager.screenSize).MinusMax();
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
    private void OnMouseOver()
    {
        if (!isHover)
        {
            isHover = true;
            GameManager.CheckHovers += OnHover;
        }
    }
    //private void OnMouseEnter()
    //{
    //    if (!isHover)
    //    {
    //        isHover = true;
    //        GameManager.CheckHovers += OnHover;
    //    }
    //}
    private void OnMouseExit()
    {
        if (isHover)
        {
            isHover = false;
            GameManager.CheckHovers -= OnHover;
        }
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
        if (isHover)
        {
            GameManager.CheckHovers -= OnHover;
        }
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