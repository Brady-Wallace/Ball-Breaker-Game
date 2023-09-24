
using UnityEngine;

public class SpawnObjectsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] bricks;

    [SerializeField] private GameObject[] paddlePowerUps;

    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            float ran = Random.Range(0.0f, 1.0f);
            if (ran <= 0.8f)
            {
                ran = Random.Range(0.0f, 1.0f);
                if (ran <= 0.90f)
                {
                    bricks[i].SetActive(true);
                }

                else
                {
                    ran = Random.Range(0.0f, 1.0f);
                    if (ran <= 0.51f)
                    {
                        for (int j = 0; j < paddlePowerUps.Length; j++)
                        {
                            if (!paddlePowerUps[j].activeSelf)
                            {
                                paddlePowerUps[j].SetActive(true);
                                paddlePowerUps[j].transform.position = bricks[i].transform.position;
                                break;
                            }


                        }
                    }
                }

            }
        }
    }
    }

