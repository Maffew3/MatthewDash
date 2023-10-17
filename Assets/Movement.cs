using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Speeds {Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4};
public class Movement : MonoBehaviour
{
    public Speeds CurrentSpeed;
    float[] SpeedValues = {8.6f, 10.4f, 12.96f, 15.6f, 19.27f};
    Rigidbody2D rb;
    public bool isJumping;
    public Transform Sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;

        if (!isJumping)
        {
            Vector3 Rotation = Sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z/90) * 90;
            Sprite.rotation = Quaternion.Euler(Rotation);
            if (Input.GetMouseButton(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
            }
        }
        else
        {  
            Sprite.Rotate(Vector3.back / 2);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("StartingPoint")) {
            isJumping = false;
        }
    }
}
