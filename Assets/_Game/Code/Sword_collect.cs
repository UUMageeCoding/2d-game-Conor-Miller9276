using UnityEngine;

public class Sword : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D Sword)
    {
        if (Sword.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (true)
            {
                Debug.Log("Player has collected the Fallen Knights Sword");

            }

        }


    }

}