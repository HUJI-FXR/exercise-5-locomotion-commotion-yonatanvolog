using UnityEngine;
using UnityEngine.XR;

public class NegateTracking : MonoBehaviour
{
    void Update()
    {
        transform.position = -InputTracking.GetLocalPosition(XRNode.CenterEye);
    }
}