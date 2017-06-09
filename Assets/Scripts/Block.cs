using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    TextMesh m_Text;

    public int m_Health = 20;

	// Use this for initialization
	void Start () {
        m_Text = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Text.text = "" + m_Health;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_Health--;
        if (m_Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
