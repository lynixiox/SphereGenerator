using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameManager gameManager;
    public Text oxygen;
    public Text co2;
    public Text life;
    //Bird Buttons//
    public Button btnBird;
    public Button btnBees;
    public Button btnDove;
    public Button btnLocust;
    //Animal Buttons//
    public Button btnAnimal;
    public Button btnCow;
    public Button btnPig;
    public Button btnFox;

    //Plant Buttons//
    public Button btnPlant;
    public Button btnWheat;
    public Button btnTree;
    public Button btnFlower;

    //Image for Plants//
    public GameObject plant;
    public GameObject animal;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        plant.SetActive(false);
        animal.SetActive(false);
        bird.SetActive(false);
        Button Tree = btnTree.GetComponent<Button>();
        Tree.onClick.AddListener(AddTree);

        Button Bird = btnBird.GetComponent<Button>();
        Bird.onClick.AddListener(AddBird);

        Button Bees = btnBees.GetComponent<Button>();
        Bees.onClick.AddListener(AddBees);

        Button Dove = btnDove.GetComponent<Button>();
        Dove.onClick.AddListener(AddDove);

        Button Animal = btnAnimal.GetComponent<Button>();
        Animal.onClick.AddListener(AddAnimal);

        Button Cow = btnCow.GetComponent<Button>();
        Cow.onClick.AddListener(AddCow);

        Button Pig = btnPig.GetComponent<Button>();
        Pig.onClick.AddListener(AddPig);
        Button Fox = btnFox.GetComponent<Button>();
        Fox.onClick.AddListener(AddFox);
        Button Plant = btnPlant.GetComponent<Button>();
        Plant.onClick.AddListener(AddPlant);
        Button Wheat= btnWheat.GetComponent<Button>();
        Wheat.onClick.AddListener(AddWheat);

        Button Flower = btnFlower.GetComponent<Button>();
        Flower.onClick.AddListener(AddFlower);

        Button Locust = btnLocust.GetComponent<Button>();
        Locust.onClick.AddListener(AddLocust);



    }

    // Update is called once per frame
    void Update()
    {
        oxygen.text = gameManager.totalOxygen.ToString();
        co2.text = gameManager.totalCo2.ToString();
        life.text = gameManager.totalLife.ToString() + "%";
    }

    void AddLocust()
    {
        gameManager.Create(LifeObjectTypes.Locust);
    }

    void AddFlower()
    {
        gameManager.Create(LifeObjectTypes.Flower);
    }

    void AddTree()
    {
        gameManager.Create(LifeObjectTypes.Tree);
    }

    void AddWheat()
    {
        gameManager.Create(LifeObjectTypes.Wheat);
    }

    void AddPlant()
    {
        Debug.Log("Plant Button Pressed");
        plant.SetActive(true);
        bird.SetActive(false);
        animal.SetActive(false);
    }

    void AddFox()
    {
        gameManager.Create(LifeObjectTypes.Fox);
    }

    void AddCow()
    {
        gameManager.Create(LifeObjectTypes.Cows);
    }

    void AddPig()
    {
        gameManager.Create(LifeObjectTypes.Pigs);
    }

    void AddAnimal()
    {
        plant.SetActive(false);
        bird.SetActive(false);
        animal.SetActive(true);
    }

    void AddDove()
    {
        Debug.Log("Dove Added");
        gameManager.Create(LifeObjectTypes.Dove);
    }

    void AddBees()
    {
        Debug.Log("Clicked the button");
        gameManager.Create(LifeObjectTypes.Bees);
    }

    void AddBird()
    {
        Debug.Log("Clicked the button");
        //Create the panel//
        plant.SetActive(false);
        bird.SetActive(true);
        animal.SetActive(false);
    }
}
