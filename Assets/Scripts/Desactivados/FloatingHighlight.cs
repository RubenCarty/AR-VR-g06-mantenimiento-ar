using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHighlight : MonoBehaviour
{
    [Header("Floating")]
    public float floatSpeed = 2f;
    public float floatHeight = 0.02f;

    [Header("Scale")]
    public float scaleMultiplier = 1.1f;

    private Vector3 startPosition;
    private Vector3 originalScale;

    void Start()
    {
        startPosition = transform.localPosition;

        originalScale = transform.localScale;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.localPosition = startPosition + new Vector3(0, yOffset, 0);

        transform.localScale =
            originalScale *
            (1 + (Mathf.Sin(Time.time * floatSpeed) * 0.05f));
    }
}