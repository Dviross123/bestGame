using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider bonusHealthSlider;
    public Color low;
    public Color high;
    public Color Bonuslow;
    public Color bonushigh;
    public Vector3 sliderOffset;
    public Vector3 bonusSliderOffset;
    public GameObject bonusHealthBar;

    public playerManager playerManager;

    void Start()
    {
        SetHealth(10f, 10f);
    }

    public void SetHealth(float health, float maxHealth)
    {
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;

        bonusHealthSlider.value = health-10;
        bonusHealthSlider.maxValue = 5;

        healthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, healthSlider.normalizedValue);
        bonusHealthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Bonuslow, bonushigh, bonusHealthSlider.normalizedValue);

    }

    void Update()
    {
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + sliderOffset);
        bonusHealthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + bonusSliderOffset);

        if (playerManager.health > playerManager.resetHealth)
        {
            bonusHealthBar.SetActive(true);
        }
        else 
        {
            bonusHealthBar.SetActive(false);
        }
    }
}
