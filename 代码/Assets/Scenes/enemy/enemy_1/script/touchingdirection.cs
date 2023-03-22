using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchingdirection : MonoBehaviour
{
    public ContactFilter2D castfilter;
    public float grounddistance = 0.05f;//¼ì²â
    public float walldistance = 0.2f;
    public float cellingdistance = 0.5f;
    Collider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] cellingHits = new RaycastHit2D[5];
    Animator animator;
    private void Awake()
    {
        touchingCol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    [SerializeField]
    private bool _isground = true;
    public bool isground 
    { 
        get { return _isground; } 
        private set { 
            _isground = value;
            animator.SetBool("isground", value);
        }
    }

    [SerializeField]
    private bool _isonwall = false;
    private Vector2 wallCheckdirection => gameObject.transform.localScale.x > 0 ? Vector2.right: Vector2.left;
    public bool isonwall
    {
        get { return _isonwall; }
        private set
        {
            _isonwall = value;
            animator.SetBool("isonwall", value);
        }
    }
    

    [SerializeField]
    private bool _isoncelling = false;
    public bool isoncelling
    {
        get { return _isoncelling; }
        private set
        {
            _isground = value;
            animator.SetBool("isoncelling", value);
        }
    }

  
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        isground=(touchingCol.Cast(Vector2.down, castfilter, groundHits, grounddistance)>0);
        isonwall = (touchingCol.Cast(wallCheckdirection, castfilter, wallHits, walldistance) > 0);
        isoncelling= (touchingCol.Cast(Vector2.up, castfilter, cellingHits, cellingdistance) >0);
    }
  
}
