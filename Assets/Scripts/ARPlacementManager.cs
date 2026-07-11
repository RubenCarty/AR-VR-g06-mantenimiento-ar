using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{
    [Header("AR Panel Prefab")]
    public GameObject panelPrefab;

    [Header("Debug Android")]
    public bool showDebug = true;

    [Header("Fallback Test")]
    public bool placeInFrontIfNoHit = true;

    private GameObject spawnedPanel;
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;

    private readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private string debugMessage = "Inicializando AR...";
    private int planeCount = 0;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();

        if (raycastManager == null)
            debugMessage = "ERROR: No hay ARRaycastManager.";
        else if (planeManager == null)
            debugMessage = "ERROR: No hay ARPlaneManager.";
        else if (panelPrefab == null)
            debugMessage = "ERROR: panelPrefab no asignado.";
        else
            debugMessage = "Mueve el celular para detectar superficie.";
    }

    void Update()
    {
        if (planeManager != null)
            planeCount = planeManager.trackables.count;

        if (spawnedPanel != null)
        {
            debugMessage = "Panel colocado correctamente.";
            return;
        }

        if (Touchscreen.current == null)
        {
            debugMessage = "ERROR: Touchscreen.current null.";
            return;
        }

        TouchControl touch = Touchscreen.current.primaryTouch;

        if (!touch.press.wasPressedThisFrame)
            return;

        Vector2 touchPosition = touch.position.ReadValue();

        bool hitPlane = raycastManager.Raycast(
            touchPosition,
            hits,
            TrackableType.Planes
        );

        if (hitPlane)
        {
            Pose hitPose = hits[0].pose;

            Vector3 panelPosition = hitPose.position;
            panelPosition.y += 0.35f;

            PlacePanel(panelPosition, "Panel colocado sobre plano AR.");
            DisablePlaneDetection();
            return;
        }

        if (placeInFrontIfNoHit)
        {
            if (Camera.main == null)
            {
                debugMessage = "ERROR: Camera.main null.";
                return;
            }

            Vector3 testPosition =
                Camera.main.transform.position +
                Camera.main.transform.forward * 2.0f;

            testPosition.y = Camera.main.transform.position.y;

            PlacePanel(
                testPosition,
                "No hubo hit AR.\nPanel colocado frente a camara."
            );

            return;
        }

        debugMessage =
            "Toque OK, pero NO hubo hit AR." +
            "\nPlanos detectados: " + planeCount;
    }

    void PlacePanel(Vector3 position, string successMessage)
    {
        if (panelPrefab == null)
        {
            debugMessage = "ERROR: panelPrefab no asignado.";
            return;
        }

        if (Camera.main == null)
        {
            debugMessage = "ERROR: Camera.main null. Revisa Tag MainCamera.";
            return;
        }

        Vector3 directionToCamera =
            Camera.main.transform.position - position;

        directionToCamera.y = 0f;

        if (directionToCamera.sqrMagnitude < 0.001f)
            directionToCamera = -Camera.main.transform.forward;

        directionToCamera.Normalize();

        Quaternion panelRotation =
            Quaternion.LookRotation(-directionToCamera, Vector3.up);

        spawnedPanel = Instantiate(
            panelPrefab,
            position,
            panelRotation
        );

        spawnedPanel.transform.localScale = Vector3.one;

        ProcedureManager procedure =
            spawnedPanel.GetComponentInChildren<ProcedureManager>();

        if (procedure != null)
            procedure.StartProcedure();

        Debug.Log("Panel Spawn Position: " + spawnedPanel.transform.position);
        Debug.Log("Panel Spawn Rotation: " + spawnedPanel.transform.rotation.eulerAngles);
        Debug.Log("Panel Spawn Scale: " + spawnedPanel.transform.localScale);

        debugMessage =
            successMessage +
            "\nPos: " + spawnedPanel.transform.position +
            "\nRot: " + spawnedPanel.transform.rotation.eulerAngles +
            "\nScale: " + spawnedPanel.transform.localScale;
    }

    void DisablePlaneDetection()
    {
        if (planeManager == null)
            return;

        planeManager.enabled = false;

        foreach (ARPlane plane in planeManager.trackables)
            plane.gameObject.SetActive(false);
    }

    void OnGUI()
    {
        if (!showDebug)
            return;

        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        style.wordWrap = true;

        GUI.Box(new Rect(20, 20, Screen.width - 40, 300), "");
        GUI.Label(
            new Rect(40, 40, Screen.width - 80, 260),
            debugMessage,
            style
        );
    }
}