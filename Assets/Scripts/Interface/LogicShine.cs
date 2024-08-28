using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicShine : MonoBehaviour
{
    public Slider slider;
    public Image imageShine;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Shine", 0.5f);
        imageShine.color = new Color(imageShine.color.r, imageShine.color.g, imageShine.color.b, slider.value);
        slider.onValueChanged.AddListener(ChangeSlider);
    }

    public void ChangeSlider(float value)
    {
        PlayerPrefs.SetFloat("Shine", value);
        imageShine.color = new Color(imageShine.color.r, imageShine.color.g, imageShine.color.b, slider.value);
    }
}
