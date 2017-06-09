using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.main.GetComponent<BallController>().m_BallsTotal++;
        Destroy(gameObject);
    }
}
