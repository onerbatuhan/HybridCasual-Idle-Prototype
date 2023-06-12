using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject topPrefab; // Top objesinin prefab referansı
    public int satirSayisi = 3; // Zemindeki satır sayısı
    public int sutunSayisi = 4; // Zemindeki sütun sayısı
    public float topArasiMesafe = 2.0f; // Toplar arasındaki mesafe
    public Transform spawnPozisyonu; // Spawn pozisyonu

    void Start()
    {
        float toplamGenislik = (sutunSayisi - 1) * topArasiMesafe;
        float toplamYukseklik = (satirSayisi - 1) * topArasiMesafe;
        Vector3 baslangicPozisyonu = spawnPozisyonu.position - new Vector3(toplamGenislik / 2, 0.0f, toplamYukseklik / 2);

        for (int satir = 0; satir < satirSayisi; satir++)
        {
            for (int sutun = 0; sutun < sutunSayisi; sutun++)
            {
                Vector3 spawnKonumu = baslangicPozisyonu + new Vector3(sutun * topArasiMesafe, 0.0f, satir * topArasiMesafe);
                GameObject yeniTop = Instantiate(topPrefab, spawnKonumu, Quaternion.identity);
                // Rastgele bir renk atayabilirsiniz
                yeniTop.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
        }
    }
}
