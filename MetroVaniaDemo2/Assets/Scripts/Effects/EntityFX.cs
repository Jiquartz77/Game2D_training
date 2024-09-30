using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityFX : MonoBehaviour {
    protected SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private Material materHit;
    private Material materOrigin;

    private void Start(){
        sr = GetComponentInChildren<SpriteRenderer>();
        materOrigin = sr.material;
    }
    
    private IEnumerator FlashFX(){

        /*
        float time, float duration
        float t = 0;
        while(t < duration){
            t += Time.deltaTime;
            sr.material = materHit;
            yield return null;
            sr.material = materOrigin;
            yield return new WaitForSeconds(time);
        }
        */

        sr.material = materHit;
        yield return new WaitForSeconds(0.2f);
        sr.material = materOrigin;
    }
}