using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image filledinHeart;
    [SerializeField] private Image emptyHeart;

    private int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        
        if (currentHealth == 0)
        {
            Debug.Log("Game Over");
        }
    }

    void UpdateHealthBar()
    {
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < currentHealth; i++) {
            Image heart = Instantiate(filledinHeart, transform);
        }

        for (int i = 0; i < maxHealth - currentHealth; i++)
        {
            Instantiate(emptyHeart, transform);
        }
    }
}
