using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            managePlayer.numberOfCoins++;
            Debug.Log("Coins:" + managePlayer.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
