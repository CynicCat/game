using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class breakAble : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    private Tilemap breakTile;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;
    private Vector3 pos8;
    // Start is called before the first frame update
    void Start()
    {
        breakTile = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void Damage(object[] message)
    {
        Debug.Log('1');
            float hitPosX = (float)message[1];
            float hitPosY = (float)message[2];
            pos1 = new Vector3(hitPosX + offsetX, hitPosY ,0f);
            pos2 = new Vector3(hitPosX - offsetX, hitPosY , 0f);
            pos3 = new Vector3(hitPosX , hitPosY + offsetY, 0f);
            pos4 = new Vector3(hitPosX , hitPosY - offsetY, 0f);
            pos5 = new Vector3(hitPosX + offsetX, hitPosY + offsetY, 0f);
            pos6 = new Vector3(hitPosX + offsetX, hitPosY - offsetY, 0f);
            pos7 = new Vector3(hitPosX - offsetX, hitPosY + offsetY, 0f);
            pos8 = new Vector3(hitPosX - offsetX, hitPosY - offsetY, 0f);

            Vector3Int position = breakTile.WorldToCell(pos1);
            breakTile.SetTile(position, null);
            position = breakTile.WorldToCell(pos2);
            breakTile.SetTile(position, null);
            position = breakTile.WorldToCell(pos3);
            breakTile.SetTile(position, null);
             position = breakTile.WorldToCell(pos4);
            breakTile.SetTile(position, null);
            position = breakTile.WorldToCell(pos5);
            breakTile.SetTile(position, null);
            position = breakTile.WorldToCell(pos6);
            breakTile.SetTile(position, null);
            position = breakTile.WorldToCell(pos7);
            breakTile.SetTile(position, null);
            position = breakTile.WorldToCell(pos8);
            breakTile.SetTile(position, null);
        }
    
}
