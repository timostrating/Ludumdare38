using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 speedMinMax = new Vector2(6, 8);

    float screenHalfWidth;

    // on start up
    void Start()
    {
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - (gameObject.GetComponent<Renderer>().bounds.size.x / 2);
    }

    // every frame
    void Update()
    {
        float velocity = Input.GetAxisRaw("Horizontal") * Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDiffucultyPercent());
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x > screenHalfWidth)
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        
        if (transform.position.x < -screenHalfWidth)
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame() {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Difficulty.ResetDiffuculty();
        yield return null;
    }
}
