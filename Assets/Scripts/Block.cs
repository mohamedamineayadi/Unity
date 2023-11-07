using UnityEngine;
using RDG;

public class Block : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f)
        {
            Vibration.Vibrate(10000, -1, false);
            Destroy(gameObject);
        }
    }
}
