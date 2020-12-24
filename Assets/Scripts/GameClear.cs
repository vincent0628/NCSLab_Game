using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    private GameObject Chicken;
    // Start is called before the first frame update
    void Start()
    {
        Chicken = GameObject.Find("Chicken");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (Chicken.transform.GetChild(7).gameObject.activeSelf && enemy.Length <= 0)
            FindObjectOfType<GameManager>().ClearGame();
        // Debug.Log(enemy.Length);
        // Debug.Log(Chicken.transform.GetChild(7).gameObject.activeSelf);
    }
}
