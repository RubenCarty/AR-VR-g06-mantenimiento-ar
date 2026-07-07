using TMPro;
using UnityEngine;

public class ProcedureManager : MonoBehaviour
{
    [Header("Procedure Steps")]
    [TextArea]
    public string[] steps;

    [Header("UI")]
    public TMP_Text instructionText;
    public TMP_Text stepText;

    [Header("3D Preview")]
    public Transform preview3DRoot;

    private GameObject ramModel;
    private GameObject ssdModel;
    private GameObject gpuModel;

    private int currentStep = 0;
    private bool started = false;

    void Awake()
    {
        if (preview3DRoot == null)
        {
            GameObject foundPreview = FindChildByName(transform.root, "Preview3D");
            if (foundPreview != null)
                preview3DRoot = foundPreview.transform;
        }

        if (preview3DRoot != null)
        {
            ramModel = FindChildByName(preview3DRoot, "RAM_Model");
            ssdModel = FindChildByName(preview3DRoot, "SSD_Model");
            gpuModel = FindChildByName(preview3DRoot, "GPU_Model");
        }

        DisableAllModels();
    }

    void Start()
    {
        StartProcedure();
    }

    public void StartProcedure()
    {
        if (steps == null || steps.Length == 0)
        {
            if (instructionText != null)
                instructionText.text = "No hay pasos configurados.";
            return;
        }

        started = true;
        currentStep = 0;
        ShowCurrentStep();
    }

    public void NextStep()
    {
        if (!started)
        {
            StartProcedure();
            return;
        }

        if (steps == null || steps.Length == 0)
            return;

        if (currentStep < steps.Length - 1)
        {
            currentStep++;
            ShowCurrentStep();
        }
        else
        {
            if (instructionText != null)
                instructionText.text = "Procedimiento completado.";

            if (stepText != null)
                stepText.text = "FIN";

            DisableAllModels();
        }
    }

    void ShowCurrentStep()
    {
        if (instructionText != null)
            instructionText.text = steps[currentStep];

        if (stepText != null)
            stepText.text = "STEP " + (currentStep + 1) + "/" + steps.Length;

        DisableAllModels();

        // Paso 0: seguridad inicial, sin modelo
        if (currentStep == 1 && ramModel != null)
            ramModel.SetActive(true);

        if (currentStep == 2 && ssdModel != null)
            ssdModel.SetActive(true);

        if (currentStep == 3 && gpuModel != null)
            gpuModel.SetActive(true);
    }

    void DisableAllModels()
    {
        if (ramModel != null) ramModel.SetActive(false);
        if (ssdModel != null) ssdModel.SetActive(false);
        if (gpuModel != null) gpuModel.SetActive(false);
    }

    GameObject FindChildByName(Transform parent, string childName)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>(true))
        {
            if (child.name == childName)
                return child.gameObject;
        }

        return null;
    }
}