using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int score = 0;
    public int damage;
    public float range = 3f;
    public float buffTime = 3f;
    public bool isShield = false;
    public bool isSpikes = false;
    public bool isDead = false;
    public bool isDoubleHope = false;

    public void ReduceHealth(int _amount)
    {
        if (currentHealth - _amount > 0)
        {
            currentHealth -= _amount;
            //TODO: Show that on the UI and have some effects.
        }
        else
        {
            currentHealth = 0;
            KillPlayer();
            //TODO: Show that on the UI and have some effects.
        }

        GUIManager.instance.UpdateHealth();
    }

    public void KillPlayer()
    {
        isDead = true;
        //TODO: Trigger Game Over
    }
}
