using UnityEngine;

public class MonsterHolderScript : MonoBehaviour
{
    public bool IsLast()
    {
        // Check if the number of child objects is 1
        return transform.childCount == 1;
    }
}
