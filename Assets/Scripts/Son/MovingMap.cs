using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMap : MonoBehaviour
{
    public Transform Player;
    private int artisX;
    private int artisY;

    public int mesafe = 1500;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<ArabaKontrol>().transform; // :D oyun başında karakteri bulamamıza yarıyor
    }

    // Update is called once per frame
    void Update()
    {
        x();
        
    }

    void x() // seçilen karakterin uzaydaki konumuna göre oluştuduğun haritayı belirli aralıklara pozisyonunu değiştirir
    {
        if (Player.transform.position.x >= transform.position.x + mesafe)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisX += mesafe;
        }
        if (Player.transform.position.x <= transform.position.x - mesafe)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisX -= mesafe;
        }
        if (Player.transform.position.z >= transform.position.z + mesafe)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisY += mesafe;
        }
        if (Player.transform.position.z <= transform.position.z - mesafe)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisY -= mesafe;
        }
        // else if (Player.transform.position.y >= transform.position.y + 64 && Player.transform.position.x >= transform.position.x + 64)
        // {
        //     transform.position = new Vector2(artisX, 0);
        //     artisX += 64;
        //     transform.position = new Vector2(0, artisY);
        //     artisY += 64;
        // }
        // else if (Player.transform.position.x <= transform.position.x - 64 && Player.transform.position.y <= transform.position.y - 64)
        // {
        //     transform.position = new Vector2(artisX, 0);
        //     artisX -= 64;
        //     transform.position = new Vector2(0, artisY);
        //     artisY -= 64;
        // }
    }

    
}
