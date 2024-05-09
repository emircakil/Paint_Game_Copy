using UnityEngine;
using UnityEngine.EventSystems;

public class BucketFill : MonoBehaviour, IPointerClickHandler
{
    public GameObject prefabToSpawn; // Oluşturulacak nesnenin prefabı
    public Color fillColor; // Doldurulacak renk
    public LayerMask layerMask; // Kenarları belirlemek için kullanılacak layer mask

    // Tıklama olayını algılayan fonksiyon
    public void OnPointerClick(PointerEventData eventData)
    {
        // Tıklama noktasının koordinatlarını al
        Vector3 worldPosition = eventData.pointerCurrentRaycast.worldPosition;

        // Raycast ile tıklanan noktanın üzerindeki colliderı bul
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition, layerMask);

        // Kenara tıklandığını kontrol et
        if (hitCollider != null)
        {
            // Nesne oluştur ve pozisyonunu belirle
            GameObject newObj = Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);

            // Nesne rengini doldurulacak renk olarak ayarla
            newObj.GetComponent<Renderer>().material.color = fillColor;
        }
    }
}
