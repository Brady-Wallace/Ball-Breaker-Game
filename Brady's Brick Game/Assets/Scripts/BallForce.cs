
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Rigidbody ball;
    // Start is called before the first frame update
    void Start()
    {
        ball.AddForce(0.01f,0.25f,0);
    }

}
