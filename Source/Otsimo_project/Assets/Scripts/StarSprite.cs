using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarSprite : MonoBehaviour
{
    public GameObject paintPrefab;
    [SerializeField] GameObject layerObject;
    LayerManager layerManager;
    [SerializeField] AudioSource starSound;
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
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject paintInstance = Instantiate(paintPrefab, mousePosition, Quaternion.identity);
                paintInstance.GetComponent<Renderer>().sortingOrder = layerManager.getLayer();
                starSound.Play();
            }
            
            
        }
    }

    public void MakeInstance(List<StarData> list) {

        // This method provides making lines from datas. It's using when you start game in continue button.

        foreach (StarData data in list)
        {
            Vector2 pos = new Vector3(data.xPosition, data.yPosition);
            GameObject paintInstance = Instantiate(paintPrefab, pos, Quaternion.identity);
            particle = paintInstance.GetComponentInChildren<ParticleSystem>();
            paintInstance.GetComponent<Renderer>().sortingOrder = data.layer;
            particle.Stop();

        }

    }
}
