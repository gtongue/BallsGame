using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Ball m_Ball;

    GameObject m_Balls;

    GameObject m_Fireline;
    public Ball m_SelectedBall;

    bool m_MouseDown = false;
    public bool m_BallFired = false;
    Vector3 m_ClickedPos;
    Vector2 m_SpawnDirection;

    public int m_BallsToFire = 1;
    public int m_BallsTotal = 1;

	void Start () {
        m_Balls = new GameObject("Balls");
	}
	
	void Update () {
        if(m_Balls.transform.childCount == 0 && m_BallFired)
        {
            m_BallFired = false;
        }
        Vector3 l_MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        l_MousePosition.z = 0;
        if (!m_BallFired)
        {
            if (Input.GetMouseButtonDown(0) && l_MousePosition.x <= -3 )
            {
                m_MouseDown = true;
                m_ClickedPos = l_MousePosition;
                CreateFireline();
            }
            else if (Input.GetMouseButtonUp(0) && m_MouseDown)
            {
                if (m_Fireline != null)
                    Destroy(m_Fireline);
                m_MouseDown = false;
                m_BallFired = true;
                FireBall(l_MousePosition);
            }

            if (m_MouseDown)
            {
                UpdateFireline(l_MousePosition);
            }
            else
            {
                if (m_Fireline != null)
                    Destroy(m_Fireline);
            }
        }
    }
    void CreateFireline()
    {
        if (m_Fireline != null)
            Destroy(m_Fireline);
        m_Fireline = new GameObject();
        m_Fireline.transform.position = m_ClickedPos;
        LineRenderer l_LineRenderer = m_Fireline.AddComponent<LineRenderer>();
        l_LineRenderer.positionCount = 2;
        l_LineRenderer.startWidth = .02f;
        l_LineRenderer.endWidth = .02f;

        Vector3[] Positions = { m_ClickedPos, m_ClickedPos };
        l_LineRenderer.SetPositions(Positions);
    }

    void FireBall(Vector3 p_Position)
    {
        m_Ball = m_SelectedBall;
        m_SpawnDirection = new Vector2((p_Position.x - m_ClickedPos.x), (p_Position.y - m_ClickedPos.y)).normalized;
        m_BallsToFire = m_BallsTotal;
        InvokeRepeating("SpawnBall", 0, .1f);
    }
    void SpawnBall()
    {
        m_BallsToFire--;
        if (m_BallsToFire == 0)
            CancelInvoke("SpawnBall");

        m_Ball = Instantiate(m_Ball, m_ClickedPos, Quaternion.identity);
        m_Ball.transform.parent = m_Balls.transform;
        m_Ball.SetDirection(m_SpawnDirection);
    }
    void UpdateFireline(Vector3 p_Position)
    {
        m_Fireline.GetComponent<LineRenderer>().SetPosition(1, p_Position);
    }
}
