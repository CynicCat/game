using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2zone : MonoBehaviour
{
   
        public List<Collider2D> zone2Colider = new List<Collider2D>();
        Collider2D col;
        private void Awake()
        {
            col = GetComponent<Collider2D>();
        }
        private void OnTriggerEnter2D(Collider2D collision) //碰撞物体进入
        {
        if (collision.CompareTag("Player"))
            zone2Colider.Add(collision);

        }

        private void OnTriggerExit2D(Collider2D collision)//碰撞物体退出
        {
        if (collision.CompareTag("Player"))
            zone2Colider.Remove(collision);
        }
        // Start is called before the first frame update


}
