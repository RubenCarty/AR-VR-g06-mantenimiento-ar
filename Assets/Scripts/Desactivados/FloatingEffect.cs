using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatSpeed = 2f;
    public float floatHeight = 0.02f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 newPosition = startPosition;

        newPosition.y +=
            Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = newPosition;
    }
}