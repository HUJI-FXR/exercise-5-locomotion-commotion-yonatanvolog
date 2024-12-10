using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {        
        transform.Translate(transform.forward * Time.deltaTime * speed,
            Space.World);
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            FindObjectOfType<GameManager>().EndLife();
        }
    }
	
    void OnMouseDown()
    {
        GameManager.score++;
        Debug.Log(GameManager.score);
        Destroy(gameObject);		
    }
	
	
	
	
}