using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHunger : MonoBehaviour
{
    
    static public float timeX = 1f;
    public int maxFood = 350;
    public int maxWater = 200;
    static public int currentFood;
    static public int currentWater;

    public FoodBarScript foodbar;
    public WaterBar waterbar;
    public Hpsys hp;
    void Start()
    {
        currentWater = maxWater;
        waterbar.SetMaxWater(maxWater);
        currentFood = maxFood;
        foodbar.SetMaxFood(maxFood);
        timerfood();
        timerwater();
    }

    void timerfood()
    {
        if(currentFood > 0)
        {
        Invoke("timerfood", 20f * timeX);
        //Invoke("timerfood", 0.1f * timeX);
        currentFood -= 1;
        foodbar.SetFood(currentFood);
        }
        else
        {
            Invoke("timerfood", 6f);
            hp.TakeDamage(4);
        }
    }

    void timerwater()
    {
        if (currentWater > 0)
        {
        Invoke("timerwater", 12f * timeX);
        //Invoke("timerwater", 0.1f * timeX);
        currentWater -= 1;
        waterbar.SetFood(currentWater);
        }
        else
        {
            Invoke("timerwater", 6f);
            hp.TakeDamage(4);
        }
    }
}
