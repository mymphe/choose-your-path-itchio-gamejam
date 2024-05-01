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
        UpdateHealthBar2();
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar2();
    }

    void UpdateHealthBar2()
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

    //void UpdateHealthBar()
    //{
    //    for (int i = 0; i < maxHealth; i++)
    //    {
    //        if (i < currentHealth)
    //            healthIcons[i].enabled = true;
    //        else
    //            healthIcons[i].enabled = false;
    //    }
    //}
}
