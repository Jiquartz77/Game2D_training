using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class UI_HealthBar: MonoBehaviour{
    private Entity entity;
    private RectTransform rectTransform;

    private void Start() {
        entity = GetComponentInParent<Entity>();
        rectTransform = GetComponent<RectTransform>();

        entity.onFlipped += FlipUI;
    }

    private void FlipUI() {
        rectTransform.Rotate(0, 180, 0);
    }
}