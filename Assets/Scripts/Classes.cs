using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Start is called before the first frame update
    //    int health = 100;
    //    int power = 50;
    //    string name = "Warrior";
    private int _health;
    public int Health  // vet and set as variable
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    int power;
    string name;

    public Player() // create a constructor
    {

    }
    public Player(int health, int power, string name)
    {
        //this.health = health;
        Health = health;
        this.power = power;
        this.name = name; 
    }

    public void Info()
    {
        Debug.Log("Health is: " + Health);
        Debug.Log("Power is: " + power);
        Debug.Log("Name is: " + name);
    }

    //getter and setter as variable
    //public void SetHealth(int health)
    //{
    //    this.health = health;
    //}

    //public int GetHealth()
    //{
    //    return health;
    //}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
