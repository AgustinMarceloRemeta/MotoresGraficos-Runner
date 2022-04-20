using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] Spawns;
    public GameObject enemy, button, money, enemy2;
    Rigidbody rb;
    Player player;
    float time = 0, Seconds;
    int score = 0, Minutes;
    public Text textTime, textScore;
    public Material Mat;
    public Color[] colors;


    void Start()
    {
        rb= GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InvokeRepeating("SpawnEnemy", 0, 3);
        InvokeRepeating( "MoreScore",5,5);    
        Cursor.lockState = CursorLockMode.Locked;
        ColorMap();
    }


    void Update()
    {
        Cronometro();
        textScore.text = "Score:" + score;
    }

    private void Cronometro()
    {
        time += Time.deltaTime;
        Minutes = (int)time / 60;
        Seconds = time % 60;
        textTime.text = "Tiempo:" + Minutes + ":" + Seconds.ToString("00");
    }

    public void Respawn()
    {
        rb.velocity = new Vector3(0, 0, 0);
        DestroyEnemys();
        Time.timeScale = 1;
        player.TpSpawn();
        button.SetActive(false);
        time = 0;
        Cursor.lockState = CursorLockMode.Locked;
        score = 0;
        ColorMap();
    }
    public void Muerte()
    {

        Time.timeScale = 0;
        button.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    
    }
    public void SpawnEnemy()
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            int number = Random.Range(1, 6);
            if (number == 2) { Instantiate(money, Spawns[i]); }
            if (number == 1 || number == 3) { Instantiate(enemy, Spawns[i]); }
            if (number == 4){ Instantiate(enemy2, Spawns[i]); }
        }
    }
    void DestroyEnemys()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(item);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("money"))
        {
            Destroy(item);
        }

    }
    public void MoreScore()
    {
        score += 5;
    }
    void ColorMap()
    {
       int c = Random.Range(0,10);
        Mat.color = colors[c];
    }
}
