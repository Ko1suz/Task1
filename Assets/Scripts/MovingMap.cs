using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMap : MonoBehaviour
{
    public Transform Player;
    private int artisX;
    private int artisY;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<AAAAAAAAAAAAAAAAAAAAAAAAA>().transform; // :D oyun başında karakteri bulamamıza yarıyor
    }

    // Update is called once per frame
    void Update()
    {
        x();
        
    }

    void x() // seçilen karakterin uzaydaki konumuna göre oluştuduğun haritayı belirli aralıklara pozisyonunu değiştirir
    {
        if (Player.transform.position.x >= transform.position.x + 50)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisX += 50;
        }
        if (Player.transform.position.x <= transform.position.x - 50)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisX -= 50;
        }
        if (Player.transform.position.z >= transform.position.z + 50)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisY += 50;
        }
        if (Player.transform.position.z <= transform.position.z - 50)
        {
            transform.position = new Vector3(artisX,0, artisY);
            artisY -= 50;
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
