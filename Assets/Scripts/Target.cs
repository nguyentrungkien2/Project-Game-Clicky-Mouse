using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    //lấy thuộc tính vật lý của target
    private Rigidbody targetRb;
    //khai báo các giá trị vận tốc quay và độ cao bay lên
    [SerializeField] private float minSpeed = 12.0f;
    [SerializeField] private float maxSpeed = 18.0f;

    private float minToque = -5.0f;
    private float maxToque = 10.0f;
    //khai báo biến random vị trí bắt đầu rơi của target trên trục x,y
    private float rangeX = -4;
    private float spawnYPos = -6;

    //tham chiếu object GameManager
    private GameManager gameManager;

    //khai báo biến giá trị điểm của target
    [SerializeField] private int scoreValue;

    //khai báo biến lấy hiệu ứng vụ nổ khi user nhấn vào target
    [SerializeField] private ParticleSystem explosionPartical;

    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomSpeedTarget(), ForceMode.Impulse);
        targetRb.AddTorque(RandomToqueTarget(), RandomToqueTarget(), RandomToqueTarget(), ForceMode.Impulse);
        transform.position = RandomPositionTarget();
    }

    private Vector3 RandomSpeedTarget()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomToqueTarget()
    {
        return Random.Range(minToque, maxToque);
    }
    private Vector3 RandomPositionTarget()
    {
        return new Vector3(Random.Range(rangeX, -rangeX), spawnYPos);
    }

    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive)
    //    {
    //        Destroy(gameObject);
    //        gameManager.UpdateScore(scoreValue);
    //        Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.CountLive(lives);
        }

    }
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(scoreValue);
            Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);
        }
    }

}
