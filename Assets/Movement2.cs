using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement2 : MonoBehaviour
{
    public Speeds CurrentSpeed;
    float[] SpeedValues = {8.6f, 10.4f, 12.96f, 15.6f, 19.27f};
    Rigidbody2D rb;
    public bool isJumping;
    public Transform Sprite2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;

        if (!isJumping)
        {
            Vector3 Rotation = Sprite2.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z/90) * 90;
            Sprite2.rotation = Quaternion.Euler(Rotation);
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.down * 26.6581f, ForceMode2D.Impulse);
            }
        }
        else
        {  
            Sprite2.Rotate(Vector3.back / 2);
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
}
