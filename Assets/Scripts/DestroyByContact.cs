using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gc;
    public int scoreValue;

    void Start()
    {
        GameObject gcObj = GameObject.FindWithTag("GameController");
        if(gcObj != null)
        {
            gc = gcObj.GetComponent <GameController>();
        }
        if (gc == null)
        {
            Debug.Log("GameController Obj does not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") {
            return;
        }
        Instantiate(explosion,transform.position,transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gc.GameOver(); 
        }
        gc.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
