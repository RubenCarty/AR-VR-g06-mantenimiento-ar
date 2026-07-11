using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            return;
        }

        Vector3 directionToCamera =
            mainCamera.transform.position - transform.position;

        directionToCamera.y = 0f;

        if (directionToCamera.sqrMagnitude < 0.001f)
            return;

        directionToCamera.Normalize();

        transform.rotation = Quaternion.LookRotation(directionToCamera);
    }
}