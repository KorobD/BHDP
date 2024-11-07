using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameBound : MonoBehaviour {


    [SerializeField] private RectTransform gameArea;
    private float gameAreaMinX;
    private float gameAreaMaxX;
    private float gameAreaMinY;
    private float gameAreaMaxY;

    public float GameAreaMinX { get { return gameAreaMinX; } }
    public float GameAreaMaxX { get { return gameAreaMaxX; } }
    public float GameAreaMinY { get { return gameAreaMinY; } }
    public float GameAreaMaxY { get { return gameAreaMaxY; } }

    private void Awake() {
        CreateBorder();
    }

    private void CreateBorder() {

        Vector3[] corners = new Vector3[4];
        gameArea.GetWorldCorners(corners);

        gameAreaMinX = corners[0].x;
        gameAreaMaxX = corners[2].x;
        gameAreaMinY = corners[0].y;
        gameAreaMaxY = corners[2].y;

    }

}