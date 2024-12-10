using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VrBall : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer sphereRenderer;
    private Material originalMaterial;
    public float speed = 5f;
    public Material hoverMaterial;
    public Material selectMaterial;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        sphereRenderer = GetComponent<Renderer>();
        originalMaterial = sphereRenderer.material;

        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }
    
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            FindObjectOfType<VrGameManager>().EndLife();
        }
    }

    public void DestroyBall()
    {
        VrGameManager.score++;
        Debug.Log(GameManager.score);
        Destroy(gameObject);
    }
    
    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        originalMaterial = sphereRenderer.material;
        sphereRenderer.material = hoverMaterial;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        sphereRenderer.material = originalMaterial;
    }
    
    private void OnSelectEntered(SelectEnterEventArgs args) {
        originalMaterial = sphereRenderer.material;
        sphereRenderer.material = selectMaterial;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        sphereRenderer.material = originalMaterial;
        DestroyBall();
    }
}