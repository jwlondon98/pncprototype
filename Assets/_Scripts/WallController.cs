using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    #region Declarations

    public WallDictionary wallDictionary;

    public Wall currentWall;

    public Fader fader;

    #endregion

    #region Unity Methods

    private void Awake()
    {
    }

    void Start()
    {

    }

    void Update()
    {

    }

    #endregion

    #region Custom Methods

    public void ChangeWall(string dir)
    {
        switch (dir)
        {
            case "right":
                switch (currentWall.wallType)
                {
                    case WallType.Front:
                        StartWallTransition(WallType.Right);
                        break;
                    case WallType.Right:
                        StartWallTransition(WallType.Back);
                        break;
                    case WallType.Back:
                        StartWallTransition(WallType.Left);
                        break;
                    case WallType.Left:
                        StartWallTransition(WallType.Front);
                        break;
                }
                break;
            case "left":
                switch (currentWall.wallType)
                {
                    case WallType.Front:
                        StartWallTransition(WallType.Left);
                        break;
                    case WallType.Left:
                        StartWallTransition(WallType.Back);
                        break;
                    case WallType.Back:
                        StartWallTransition(WallType.Right);
                        break;
                    case WallType.Right:
                        StartWallTransition(WallType.Front);
                        break;
                }
                break;
        }
    }

    private void StartWallTransition(WallType newWallType)
    {
        fader.gameObject.SetActive(true);
        fader.newWallType = newWallType;
    }

    public void PerformWallTransition(WallType newWallType)
    {
        // disable old wall
        currentWall.gameObject.SetActive(false);

        // enable new wall
        currentWall = wallDictionary[newWallType];
        currentWall.gameObject.SetActive(true);
    }

    #endregion
}

[Serializable]
public class WallDictionary : SerializableDictionary<WallType, Wall> { }