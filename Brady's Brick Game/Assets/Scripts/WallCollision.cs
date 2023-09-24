using UnityEngine;
using UnityEngine.Events;
public class WallCollision : MonoBehaviour
{

    [SerializeField] private GameObject[] balls;
    public UnityEvent endGame;
    private bool beginEndGame;
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.SetActive(false);
        for (int i = 0;i <= 3;i++) 
        {
            Debug.Log("loop was entered");
            if (!balls[i].activeSelf)
            {
                beginEndGame = true;
                Debug.Log("true");
            }

            else
            {
                beginEndGame = false;
                Debug.Log("false");
            }
            
        }

        if (beginEndGame)
        {
            
            endGame.Invoke();
        }
    }
}
