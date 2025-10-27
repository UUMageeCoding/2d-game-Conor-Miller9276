using UnityEngine;

public class Shield : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D Shield)
    {
        if (Shield.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (true)
            {
                Debug.Log("Player has collected the Fallen Knights Shield");

            }

        }


    }

}