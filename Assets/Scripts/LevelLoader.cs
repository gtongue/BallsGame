using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    public GameObject m_Block;
    public GameObject m_Obstacle;
    public GameObject m_DrawArea;
    public GameObject m_AddBall;

    public static GameObject m_Blocks;
    public static GameObject m_Obstacles;
    public static GameObject m_DrawAreas;
    public static GameObject m_AddBalls;


    // Use this for initialization
    void Start () {
        m_Blocks = new GameObject("Level");
        m_Obstacles = new GameObject("Obstacles");
        m_DrawAreas = new GameObject("DrawAreas");
        m_AddBalls = new GameObject("AddBalls");
        LoadLevel();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void LoadLevel()
    {
        System.IO.StreamReader file = new System.IO.StreamReader("Assets\\Resources\\Levels\\Level4.txt");
        String line = file.ReadLine();
        if(line!= null && line.Length > 1)
        {
            line = line.Substring(0, line.Length - 1);
            var lines = line.Split(',');
            for(int i = 0; i < lines.Length; i+=3)
            {
                int x = int.Parse(lines[i])-4;
                int y = -int.Parse(lines[i+1])+2;
                int life = int.Parse(lines[i+2]);

                Block b = Instantiate(m_Block, new Vector3(x,y, 1), Quaternion.identity).GetComponent<Block>();
                b.m_Health = life;
            }
        }

        line = file.ReadLine();
        if (line != null && line.Length > 1)
        {
            line = line.Substring(0, line.Length - 1);
            var lines = line.Split(',');
            for (int i = 0; i < lines.Length; i += 2)
            {
                int x = int.Parse(lines[i]) - 4;
                int y = -int.Parse(lines[i + 1]) + 2;
                Instantiate(m_DrawArea, new Vector3(x, y, 1), Quaternion.identity).transform.parent = m_DrawAreas.transform;
            }
        }

        line = file.ReadLine();
        if (line != null && line.Length > 1)
        {
            line = line.Substring(0, line.Length - 1);
            var lines = line.Split(',');
            for (int i = 0; i < lines.Length; i += 2)
            {
                int x = int.Parse(lines[i]) - 4;
                int y = -int.Parse(lines[i + 1]) + 2;
                Instantiate(m_Obstacle, new Vector3(x, y, 1), Quaternion.identity).transform.parent = m_Obstacles.transform;
            }
        }

        line = file.ReadLine();
        if (line != null && line.Length > 1)
        {
            line = line.Substring(0, line.Length - 1);
            var lines = line.Split(',');
            for (int i = 0; i < lines.Length; i += 2)
            {
                int x = int.Parse(lines[i]) - 4;
                int y = -int.Parse(lines[i + 1]) + 2;
                Instantiate(m_AddBall, new Vector3(x, y,1), Quaternion.identity).transform.parent = m_AddBalls.transform;
            }
        }
        file.Close();
    }
}
