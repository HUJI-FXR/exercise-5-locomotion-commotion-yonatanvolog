using UnityEngine;

public class TintRedScript : MonoBehaviour
{
    [SerializeField] private Renderer monsterRenderer;
    private LifeTotalScript lifeTotalScript;

    private void Start()
    {
        monsterRenderer.material = Instantiate(monsterRenderer.material);
        lifeTotalScript = GetComponent<LifeTotalScript>();
    }

    private void Update()
    {
        float lifeTotalRatio = lifeTotalScript.GetLifeTotal() / lifeTotalScript.GetInitialLifeTotal();
        monsterRenderer.material.color = lifeTotalRatio * Color.white + (1f - lifeTotalRatio) * Color.red;
    }
}