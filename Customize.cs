using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customize : MonoBehaviour
{
    public GameObject f1;
    public GameObject f2;
    public GameObject a1;
    public GameObject a2;
    public GameObject body;
    public GameObject dragon;

    public Slider FootSlider;
    public Slider ArmSlider;
    public Slider BodySlider;
    public Slider DragonSlider;

    public GameObject panel;

    public void Start()
    {
        Time.timeScale = 0;
        panel.gameObject.SetActive(true);
    }
    public void RandomizeButton()
    {

        ArmSlider.value = Random.Range(0.5f, 1.5f);
        BodySlider.value = Random.Range(0.5f, 1.5f);
        FootSlider.value = Random.Range(0.5f, 1.5f);
        DragonSlider.value = Random.Range(0.5f, 1.5f);
    }
    public void ASlider()
    {
        float newArmValue = ArmSlider.value;
        a1.transform.localScale = new Vector2(newArmValue, newArmValue);
        a2.transform.localScale = new Vector2(newArmValue, newArmValue);
        Debug.Log(newArmValue);
    }
    public void BSlider()
    {
        float newBodyValue = BodySlider.value;
        body.transform.localScale = new Vector2(newBodyValue, newBodyValue);
        Debug.Log(newBodyValue);
    }
    public void FSlider()
    {
        float newFootValue = FootSlider.value;
        f1.transform.localScale = new Vector2(newFootValue, newFootValue);
        f2.transform.localScale = new Vector2(newFootValue, newFootValue);
        Debug.Log(newFootValue);
    }
    public void DSlider()
    {
        float newDraValue = DragonSlider.value;
        dragon.transform.localScale = new Vector2(newDraValue, newDraValue);
        Debug.Log(newDraValue);
    }
    
    public void Play()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
    }

}
