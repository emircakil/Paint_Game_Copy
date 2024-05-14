using UnityEngine;

public class PaintController : MonoBehaviour
{
    public GameObject paintPrefab;
    [SerializeField] GameObject layerObject;
    LayerManager layerManager;
    [SerializeField] AudioSource starSound;

    private void Awake()
    {
        layerManager = layerObject.gameObject.GetComponent<LayerManager>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
            GameObject paintInstance = Instantiate(paintPrefab, mousePosition, Quaternion.identity);
            paintInstance.GetComponent<Renderer>().sortingOrder = layerManager.getLayer();
            starSound.Play();
        }
    }
}
