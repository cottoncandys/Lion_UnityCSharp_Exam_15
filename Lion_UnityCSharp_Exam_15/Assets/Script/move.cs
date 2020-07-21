using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    
   

    Vector3 targetPosition = new Vector3(0, 0, -5);
    Vector3 currentVelocity = Vector3.zero;
    //[Header("移動速度"),Range(1,10)]
    int maxSpeed = 10;
    int smoothTime = 1;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, maxSpeed);

        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene("第2題");
        }

        if (Input.GetKeyDown("o"))
        {
            SceneManager.LoadScene("第1題");
        }
    }
}


 



















