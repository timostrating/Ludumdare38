using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 8;

    float screenHalfWidth;

    // on start up
    void Start()
    {
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - (gameObject.GetComponent<Renderer>().bounds.size.x / 2);
    }

    // every frame
    void Update()
    {
        float velocity = Input.GetAxisRaw("Horizontal") * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x > screenHalfWidth)
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        
        if (transform.position.x < -screenHalfWidth)
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Enemy")
        Debug.Log("wow");
        Destroy(this.gameObject);
    }
}
