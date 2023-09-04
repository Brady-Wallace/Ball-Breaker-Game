using UnityEngine;


public class CollisionEventsBehaviour : MonoBehaviour
{
    private WaitForSeconds waitObj;





    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }
    }
}