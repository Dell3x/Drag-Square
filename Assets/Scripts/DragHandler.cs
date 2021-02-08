using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    Vector3 HomePosition;
    Rigidbody2D rb;
    GameObject ObjectUnder;
    string ObjectUnderName = "";

    private ScoreManager scoreManager;
    private Box box;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        box = FindObjectOfType<Box>();
    }

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        HomePosition = transform.position;
        itemBeingDragged = gameObject;
        ObjectUnderName = "";
        box.speed = 0;

    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        
        rb.MovePosition(eventData.position);
        box.speed = 0;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {

        itemBeingDragged = null;
        box.speed = 5f;


        if (ObjectUnderName == "Red Box" && this.name == "Red Box(Clone)")
        {
            transform.position = ObjectUnder.transform.position;
            scoreManager.AddScore();
            Destroy(gameObject);
            
        }
        else if (ObjectUnderName == "Peach Box" && this.name == "Peach Box(Clone)")
        {
            transform.position = ObjectUnder.transform.position;
            scoreManager.AddScore();
            Destroy(gameObject);

        }
        else if (ObjectUnderName == "Blue Box" && this.name == "Blue Box(Clone)")
        {
            transform.position = ObjectUnder.transform.position;
            scoreManager.AddScore();
            Destroy(gameObject);

        }
        else if (ObjectUnderName == "Green Box" && this.name == "Green Box(Clone)")
        {
            transform.position = ObjectUnder.transform.position;
            scoreManager.AddScore();
            Destroy(gameObject);

        }
        else if (ObjectUnderName == "Light Blue Box" && this.name == "Light Blue Box(Clone)")
        {
            transform.position = ObjectUnder.transform.position;
            scoreManager.AddScore();
            Destroy(gameObject);

        }
        else if (ObjectUnderName == "Violet Box" && this.name == "Violet Box(Clone)")
        {
            transform.position = ObjectUnder.transform.position;
            scoreManager.AddScore();
            Destroy(gameObject);

        }
        else
        {
            
            transform.position = HomePosition;
        }

    }

    #endregion

    void OnTriggerEnter2D(Collider2D myCollision)
    {
        
        ObjectUnder = myCollision.gameObject;
        ObjectUnderName = ObjectUnder.name;

    }

    void OnTriggerExit2D(Collider2D myCollision)
    {
        
        ObjectUnder = myCollision.gameObject;
        ObjectUnderName = "";

    }

}
