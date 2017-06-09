using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour {

    public GameObject m_Block;

	void Start () {
        GenerateWalls();
        //GenerateBlockGrid();
	}
    void GenerateWalls()
    {
        GameObject Walls = new GameObject("Walls");
        Camera mainCam = GetComponent<Camera>();

        float verticalSize = mainCam.orthographicSize;
        float horizontalSize = verticalSize * Screen.width / Screen.height;

        GameObject top = new GameObject("Top");
        GameObject bottom = new GameObject("Bottom");
        GameObject left = new GameObject("Left");
        GameObject right = new GameObject("Right");

        //top.transform.position = new Vector3(0, verticalSize, 0);
        top.transform.position = new Vector3(0, 3.55f, 0);

        top.AddComponent<BoxCollider2D>();
        BoxCollider2D col = top.GetComponent<BoxCollider2D>();
        col.size = new Vector2(horizontalSize * 2, 0.1f);

        //bottom.transform.position = new Vector3(0, -verticalSize, 0);
        bottom.transform.position = new Vector3(0, -3.55f, 0);
        bottom.AddComponent<BoxCollider2D>();
        col = bottom.GetComponent<BoxCollider2D>();
        col.size = new Vector2(horizontalSize * 2, 0.1f);


        //right.transform.position = new Vector3(horizontalSize, 0, 0);
        right.transform.position = new Vector3(5.55f, 0, 0);
        right.AddComponent<BoxCollider2D>();
        col = right.GetComponent<BoxCollider2D>();
        col.size = new Vector2(.1f, verticalSize * 2);

        left.transform.position = new Vector3(-horizontalSize, 0, 0);
        left.AddComponent<BoxCollider2D>();
        left.AddComponent<DeadZone>();
        col = left.GetComponent<BoxCollider2D>();
        col.isTrigger = true;
        col.size = new Vector2(.1f, verticalSize * 2);

        top.transform.parent = bottom.transform.parent = right.transform.parent = left.transform.parent = Walls.transform;
    }

    void GenerateBlockGrid()
    {
        GameObject l_Level = new GameObject("Level");
        for(int x = -3; x <= 5; x++)
        {
            for(int y = -3; y <= 3; y++)
            {
                Instantiate(m_Block, new Vector3((float)x, (float)y, 0), Quaternion.identity).transform.parent = l_Level.transform;
            }
        }
    }
}
