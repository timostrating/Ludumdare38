using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{
    public Vector3 movementMin;
    public Vector3 movementMax;

    public bool destroy = true;
    public float destroyAfter = 3f;

    Vector3 speed;


    private void Start() {
        if (destroy)
            Destroy(gameObject, destroyAfter);

        speed = Vector3.Lerp(movementMin, movementMax, Difficulty.GetDiffucultyPercent());
    }

    void Update() {
        transform.Translate(speed * Time.deltaTime);
    }
}
