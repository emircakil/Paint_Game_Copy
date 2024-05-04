using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{ 
    public float circleRadius = 1.0f;

    void Update()
    {
        // Fare pozisyonunu al
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane; // Uzaklığı kameranın yakın düzlemine ayarla

        // Fare pozisyonunu 3D dünyadaki bir noktaya dönüştür
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Dairenin konumunu fare pozisyonu olarak ayarla
        transform.position = worldPosition;

        // Dairenin boyutunu güncelle
        transform.localScale = new Vector3(circleRadius * 2, circleRadius * 2, 1);
    }

    void OnDrawGizmos()
    {
        // Gizmo olarak daireyi çiz
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}


