using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// ★追加
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    private GameObject[] enemyObjects;
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;

    // ★追加
    [SerializeField]
    private Text HPLabel;
    public int tankMaxHP = 5;

    // ★追加
    void Start()
    {
        tankHP = tankMaxHP;
        HPLabel.text = "HP:" + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShell")
        {
            tankHP -= 1;

            // ★追加
            HPLabel.text = "HP:" + tankHP;

            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);
                this.gameObject.SetActive(false);
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void AddHP(int amount)
    {
        tankHP += amount;
        if(tankHP>tankMaxHP)
        {
            tankHP = tankMaxHP;
        }
        HPLabel.text = "HP" + tankHP;
    }
    void Update()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        print(enemyObjects.Length);
        if (enemyObjects.Length == 0)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}