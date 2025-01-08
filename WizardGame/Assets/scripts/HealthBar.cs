using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image hpFill;

    public void SetHealth(int health) {
        if (health >= slider.minValue && health <= slider.maxValue) {
            slider.value = health;

            hpFill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

    public void SetMaxHealth(int maxValue) {
        hpFill.color = gradient.Evaluate(slider.normalizedValue);
        slider.maxValue = maxValue;
        slider.value = maxValue * slider.normalizedValue;
    }
}
