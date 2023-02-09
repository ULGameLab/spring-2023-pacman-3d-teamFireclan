using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Creator : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject parentObject;
    public int maxFoodCount = 3;
    public float secondsBetweenSpawn = 2;
    float elapsedTime = 0;
    int currentFoodCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentFoodCount = CountFood();
        parentObject = transform.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > secondsBetweenSpawn && currentFoodCount < maxFoodCount)
        {
            elapsedTime = 0;
            Vector3 spawnPosition = RandomPositionAroundPlayer();
            GameObject newEnemy = (GameObject)Instantiate(foodPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
            newEnemy.transform.SetParent(parentObject.transform);
            currentFoodCount += 1;
        }
    }
    private int CountFood()
    {
        int count = 0;
        GameObject[] food = GameObject.FindGameObjectsWithTag("apple, Banana, Mega Fruit, Burger, Onion, Ice Cream");
        count = food.Length;
        return count;
    }
    private Vector3 RandomPositionAroundPlayer()
    {
        Vector3 randPos = new Vector3(Random.Range(-30.0f, 30.0f), 0, Random.Range(-30.0f, 30.0f));
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        randPos += playerPos;
        randPos.x += 10.0f;
        randPos.y = playerPos.y + 1;
        randPos.z += 10.0f;
        return randPos;
    }
}