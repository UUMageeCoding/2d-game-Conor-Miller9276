using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public int maxHealth = 100;
    int Health = 100;

    public bool hasDied;

    public GameManagerScript gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = maxHealth;
   
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0 && !hasDied)
        {
            hasDied = true;
            gameObject.gameObject.SetActive(false);
            gameManager.gameOver();
            Debug.Log("You Died");
        }
    }
}

public class GameManagerScript
{
    public void gameOver()
    {
        Debug.Log("Game Over Triggered");
    }
}