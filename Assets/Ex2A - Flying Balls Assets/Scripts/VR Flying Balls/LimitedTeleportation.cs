using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LimitedTeleportation : MonoBehaviour
{
    public int maxTeleports = 3;
    private int currentTeleports = 0;
    private TeleportationArea teleportationArea;
    public Material noTeleportMaterial;

    void Awake()
    {
        teleportationArea = GetComponent<TeleportationArea>();

        if (teleportationArea != null)
        {
            teleportationArea.teleporting.AddListener(OnTeleport);
        }
    }

    private void OnTeleport(TeleportingEventArgs args)
    {
        currentTeleports++;

        if (currentTeleports >= maxTeleports)
        {
            DisableTeleportation();
        }
    }

    private void DisableTeleportation()
    {
        if (teleportationArea != null)
        {
            teleportationArea.enabled = false;
        }

        Renderer areaRenderer = GetComponent<Renderer>();
        if (areaRenderer != null)
        {
            areaRenderer.material = noTeleportMaterial;
        }
    }

    void OnDestroy()
    {
        if (teleportationArea != null)
        {
            teleportationArea.teleporting.RemoveListener(OnTeleport);
        }
    }
}