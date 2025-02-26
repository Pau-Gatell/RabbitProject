using UnityEngine;
using UnityEngine.UI;

public class barPD : MonoBehaviour
{
    public Image barImage;

    void Start()
    {
        
    }

    public void UpdateHealthbar(float maxHealth, float health)
    {
        barImage.fillAmount = health / maxHealth;
    }


    void Update()
    {
        
    }
}
