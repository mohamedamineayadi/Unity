using RDG;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        Vector3 accel = Input.acceleration;
        rb.AddForce(new Vector3(accel.x,0,0).normalized * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Vibration.Vibrate(500, -1);
            StartCoroutine(CancelVibration());
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator CancelVibration()
    {
        yield return new WaitForSeconds(0.2f);
        Vibration.Cancel();
    }
}
