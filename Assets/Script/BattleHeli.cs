using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeli : MonoBehaviour
{
    public GameObject target;
    public GameObject enemyShotShell;
    public GameObject enemyShellPrefab;
    private int count = 0;

    void Update()
    {
        // 常にターゲットの方を向く。
        transform.LookAt(target.transform);

        // ターゲットとの距離が離れている場合には、ターゲットに近く。
        if (Vector3.Distance(transform.position, target.transform.position) > 10f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }
        else
        {
            // 一定距離に近づいたら機体の高度を上げる。
            if (transform.position.y < 8f)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3);
            }

            // 攻撃開始
            count += 1;
            if (count % 60 == 0)
            {
                GameObject enemyShell = Instantiate(enemyShellPrefab, enemyShotShell.transform.position, enemyShotShell.transform.rotation);
                Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();
                enemyShellRb.AddForce(transform.forward * 500);
            }
        }
    }
}