using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar: MonoBehaviour{
    private Entity entity;
    private RectTransform rectTransform;
    private CharacterStats stats;
    private Slider slider;

    private void Start() {
        entity = GetComponentInParent<Entity>();
        rectTransform = GetComponent<RectTransform>();
        stats = GetComponentInParent<CharacterStats>();
        slider =GetComponent<Slider>();

        entity.onFlipped += FlipUI;
        stats.onHealthChanged += UpdateHealthUI;

        UpdateHealthUI();
    }

    private void Update() {
    }

    private void UpdateHealthUI(){
        slider.maxValue = stats.GetMaxHP();
        slider.value = stats.curHP;
    }

    private void FlipUI() => rectTransform.Rotate(0, 180, 0); 

    private void OnDisable(){
        entity.onFlipped -= FlipUI;
        stats.onHealthChanged -= UpdateHealthUI;
    } 
}