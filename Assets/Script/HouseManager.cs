using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    [Header("GameOver Conditions")]
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private List<HouseComponent> houses;

    private void Start()
    {
        foreach (HouseComponent house in houses)
        {
            house.houseManager = this;
        }
    }

    public void DestroyHouse(HouseComponent house)
    {
        houses.Remove(house);
        Destroy(house.gameObject);

        if (houses.Count == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
