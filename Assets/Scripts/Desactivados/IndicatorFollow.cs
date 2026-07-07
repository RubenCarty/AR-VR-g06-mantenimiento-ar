using UnityEngine;

public class IndicatorFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0.35f, 0f, 0f);

    private Transform panelTarget;

    void Update()
    {
        // Buscar panel si aún no existe
        if (panelTarget == null)
        {
            GameObject panel =
                GameObject.Find("ProcedurePanelAR(Clone)");

            if (panel != null)
            {
                panelTarget = panel.transform;
            }

            return;
        }

        // Seguir panel
        transform.position =
            panelTarget.position + panelTarget.right * offset.x
            + panelTarget.up * offset.y
            + panelTarget.forward * offset.z;
    }
}