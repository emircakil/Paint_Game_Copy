using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class PaintballGun : MonoBehaviour
{
    public GameObject paintPrefab;
    SpriteRenderer spriteRenderer;
    PaintballPrefab paintballPrefab;
    [SerializeField] GameObject colorGameObject;
    ColorController colorController;
    [SerializeField] GameObject layerObject;
    LayerManager layerManager;
    ParticleSystem particalSystem;
    [SerializeField]AudioSource paintballSound;
    ParticleSystem particle;
    

    private void Awake()
    {
        layerManager = layerObject.gameObject.GetComponent<LayerManager>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Touch touch = Input.touches[0];
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                colorController = colorGameObject.GetComponent<ColorController>();
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject paintInstance = Instantiate(paintPrefab, mousePosition, Quaternion.identity);
                paintballPrefab = paintInstance.GetComponent<PaintballPrefab>();
                spriteRenderer = paintInstance.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = paintballPrefab.getSprite(colorController.getColorWName());
                spriteRenderer.sortingOrder = layerManager.getLayer();
                particalSystem = paintInstance.GetComponentInChildren<ParticleSystem>();
                particalSystem.startColor = colorController.getColor();
                paintballSound.Play();
            }

            
           
        }
    }

    public void MakeInstance(List<PaintballData> list) {
        
        foreach (PaintballData data in list)
        {

            Vector2 pos = new Vector2(data.xPosition, data.yPosition);
            GameObject paintInstance = Instantiate(paintPrefab, pos, Quaternion.identity);
            paintballPrefab = paintInstance.GetComponent<PaintballPrefab>();
            spriteRenderer = paintInstance.GetComponent <SpriteRenderer>();
            spriteRenderer.sprite = paintballPrefab.getSprite(data.colorWName);
            spriteRenderer.sortingOrder = data.layer;
            particle = paintInstance.GetComponentInChildren<ParticleSystem>();
            particle.Stop();


        }
    }
}
