using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;
    public PlayerHealth Health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health.TakeDamage(damage);

            if (true)
            {
                Debug.Log("Player took " + damage + " damage.");
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
