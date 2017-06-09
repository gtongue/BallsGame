using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

    public Material m_Material;
    public Vector2 m_Direction = new Vector2(0, 0);
    public float m_Speed;

    public Rigidbody2D m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 8);
    }
    private void FixedUpdate()
    {
        if (m_Rigidbody != null && m_Rigidbody.velocity == Vector2.zero)
        {
            m_Rigidbody.velocity = m_Direction * m_Speed;
            if (m_Rigidbody.velocity.x == 0)
            {
                m_Rigidbody.velocity = new Vector2(-.1f, m_Rigidbody.velocity.y);
            }
            if (m_Rigidbody.velocity.y == 0)
            {
                m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, -.1f);
            }
            m_Direction = m_Rigidbody.velocity / m_Speed;
        }
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: Collisions near wall don't work
        //  if(collision.gameObject.GetComponent<Ball>() == null)
        Vector2 l_Normal = new Vector2();
        int counter = 0;

        foreach (ContactPoint2D point in collision.contacts)
        {
            l_Normal += point.normal;
            counter++;
        }
        l_Normal = l_Normal / counter;

        SetDirection(Vector2.Reflect(m_Direction, l_Normal));
    }*/

    public void SetDirection(Vector2 p_Direction)
    {
        m_Direction = p_Direction;
    }
}
