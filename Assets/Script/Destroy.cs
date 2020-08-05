using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;
    [SerializeField]
    private GameObject effectPrefab2;
    public int objectHP;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shell"))
        {
            Debug.Log(other.gameObject);
            objectHP -= 1;
            if (objectHP > 0)
            {
                Destroy(other.gameObject);
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
                Debug.Log("o");
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);
                
                Destroy(this.gameObject);
            }
           
        }
    }
}
