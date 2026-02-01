using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterSelection : MonoBehaviour
{
    public Image carImage;
    public Text price;
    public Button actionButton, prevButton, nextButton;

    public Sprite[] carSprites;
    public int[] carPrice;
    public string[] carNames;

    private int currentIndex;
    private int totalScore = 0;
    private bool[] ownedCars;

    private string ownedCarsKey = "OwnedCar";

    private void Start()
    {
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        ownedCars = new bool[carSprites.Length];
        for (int i = 0; i < carSprites.Length; i++) {
            ownedCars[i] = PlayerPrefs.GetInt(ownedCarsKey + i, 0) == 1 ? true : false;
        }

        UpdateCarDisplay();
        nextButton.onClick.AddListener(NextCar);
        prevButton.onClick.AddListener(PrevCar);
        actionButton.onClick.AddListener(ActionCar);
    }
    public void UpdateCarDisplay()
    {
        carImage.sprite = carSprites[currentIndex];

        if (ownedCars[currentIndex])
        {
            actionButton.GetComponentInChildren<Text>().text = carNames[currentIndex];
            actionButton.onClick.RemoveAllListeners();
            actionButton.onClick.AddListener(SelectCar);
            price.text = "";
            actionButton.interactable = true;
        }
        else
        {
            actionButton.GetComponentInChildren<Text>().text = "Satýn Al";
            actionButton.onClick.RemoveAllListeners();
            actionButton.onClick.AddListener(BuyCar);
            price.text = "Price: " + carPrice[currentIndex].ToString();

            if(totalScore >= carPrice[currentIndex])
            {
                actionButton.interactable = true;
            }
            else
            {
                actionButton.interactable = false;
            }
        }
    }
    public void NextCar()
    {
        currentIndex = (currentIndex + 1) % carSprites.Length;
        UpdateCarDisplay();
    }
    public void PrevCar()
    {
        currentIndex = (currentIndex - 1 + carSprites.Length) % carSprites.Length;
        UpdateCarDisplay();
    }
    public void ActionCar()
    {
        if (ownedCars[currentIndex])
        {
            SelectCar();
        }
        else
        {
            BuyCar();
        }
    }
    public void SelectCar()
    {
        if (ownedCars[currentIndex]) {
            string selectedCarPrefabName = carNames[currentIndex];
            PlayerPrefs.SetString("SelectedCarPrefab", selectedCarPrefabName);
        }
    }
    public void BuyCar()
    {
        if (totalScore >= carPrice[currentIndex] && !ownedCars[currentIndex])
        {
            totalScore -= carPrice[currentIndex];
            PlayerPrefs.SetInt("TotalScore", totalScore);
            ownedCars[currentIndex] = true;
            PlayerPrefs.SetInt(ownedCarsKey + currentIndex, 1);
            UpdateCarDisplay();
        }
    }
}
