using UnityEngine;


public class CollisionEventsBehaviour : MonoBehaviour
{


    [SerializeField] private GameObject[] balls;



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Power"))
        {
            Destroy(other.gameObject);
            for (int i = 0; i <= 2; i++)
            {
                if (!balls[i].gameObject.activeSelf)
                {
                    balls[i].gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
    
    
}
