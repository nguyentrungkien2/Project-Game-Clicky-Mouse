using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(TrailRenderer))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private BoxCollider boxColl;
    private TrailRenderer trailRe;
    private bool swiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        trailRe = GetComponent<TrailRenderer>();
        boxColl = GetComponent<BoxCollider>();
        boxColl.enabled = false;
        trailRe.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponent();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponent();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }
    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }
    void UpdateComponent()
    {
        trailRe.enabled = swiping;
        boxColl.enabled = swiping;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
        if (collision.gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
