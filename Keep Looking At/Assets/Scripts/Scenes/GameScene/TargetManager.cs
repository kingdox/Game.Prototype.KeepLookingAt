#region Imports
using UnityEngine;
using XavHelpTo.Set;
#endregion
public class TargetManager : MonoBehaviour
{
    #region Variable
    private static TargetManager _;

    [Header("Target Settings")]
    public Transform @targetsContainer;

    #endregion
    #region Events
    private void Awake()
    {
        if (_ == null) _ = this;
    }
    #endregion
    #region Method

    /*
     * returns one of the specified transforms who exist in the references...
     */
    public static Transform GetContainerOf(Targets target)
    {
        Transform result = null;
        //luego refactor si da tiempo
        switch (target)
        {
            case Targets.TARGET:
                result = _.targetsContainer;
                break;
            default:
                break;
        }
        return result;
    }
    #endregion
}
public enum Targets
{
    NO = -1,
    TARGET
}