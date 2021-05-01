using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [HideInInspector]
    public WallType newWallType;

    public WallController wallController;

    public void PerformWallTransition()
    {
        wallController.PerformWallTransition(newWallType);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
