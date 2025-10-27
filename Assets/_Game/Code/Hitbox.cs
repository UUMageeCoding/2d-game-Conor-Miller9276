using UnityEngine;

public class FallenKnight : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D FallenKnight)
    {
        if (FallenKnight.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (true)
            {
                Debug.Log("Player has saved the Fallen Knight");
            
            }

        }

  
    }

}

