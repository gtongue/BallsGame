using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {
    
    public BallController m_BallController;

    GameObject  m_Line;
    LineRenderer m_LineRenderer;
    EdgeCollider2D m_EdgeCollider;


    Vector2 m_MousePos;

    List<Vector2> m_LinePoints = new List<Vector2>();
    bool m_MouseDown = false;

	// Use this for initialization
	void Start () {
	}

    private void Update()
    {
       // if(m_BallController.m_BallFired)
        //{
            m_MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bool l_DrawArea = false;
            foreach (Transform d in LevelLoader.m_DrawAreas.transform)
            {
                BoxCollider2D collider = d.GetComponent<BoxCollider2D>();
                if(collider.bounds.Contains(new Vector3(m_MousePos.x, m_MousePos.y, 1)))
                {
                    l_DrawArea = true;
                }
            }
            if (l_DrawArea)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (m_Line != null) Destroy(m_Line);
                    CreateLine();
                    m_MouseDown = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    //   if (m_Line != null) Destroy(m_Line);
                    m_MouseDown = false;
                }
                if (m_MouseDown)
                {
                    AddPoint();
                }
            }
        else
        {
            m_MouseDown = false;
        }
    //    }
    }

    void CreateLine()
    {
        m_Line = new GameObject();

        m_LineRenderer = m_Line.AddComponent<LineRenderer>();
        m_EdgeCollider = m_Line.AddComponent<EdgeCollider2D>();

        m_LinePoints.Clear();

        m_LineRenderer.startColor = Color.red;
        m_LineRenderer.endColor = Color.red;
        m_LineRenderer.material = m_BallController.m_SelectedBall.m_Material;
        m_LineRenderer.startWidth = .1f;
        m_LineRenderer.endWidth = .1f;
        AddPoint();
    }

    void AddPoint()
    {
        m_LinePoints.Add(m_MousePos);

        m_LineRenderer.positionCount = m_LinePoints.Count;
        m_LineRenderer.SetPosition(m_LinePoints.Count-1, m_MousePos);

        if(m_LinePoints.Count > 1)
            m_EdgeCollider.points = m_LinePoints.ToArray();
    }
}
