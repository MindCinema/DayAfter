using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEnvironment : MonoBehaviour
{
    public static Sun Sun;
    public List<GameObject> RainSources;
    int currentRainEmission = 0;
    bool rainIntensityIsChaning = false;

    // Use this for initialization
    void Start()
    {
        Sun = GetComponent<Sun>();
        GameTime.DayChanged += CalculateRainPossibility;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CalculateRainPossibility(object sender, DayChangedEventArgs args)
    {
        var willRain = (Random.value > 0.8f);
        if (willRain)
        {
            var rainStart = Random.Range(0.0f, 1444.0f);
            var rainDuration = Random.Range(60.0f, 600.0f);
        }
    }

    public void StartRain()
    {
        var rainStrength = Random.Range(50.0f, 200.0f);
        int newRainEmission = (int)rainStrength;
        ChangeRainIntensity(newRainEmission);
    }

    public void ChangeRainIntensity(int newRainEmission)
    {
        if (rainIntensityIsChaning) return; //Dont change when there is already a change going on. ToDo: Needs better handling
        if (newRainEmission > currentRainEmission)
        {
            StartCoroutine(IncreaseRainDrops(newRainEmission));
        }
        else if (newRainEmission < currentRainEmission)
        {
            StartCoroutine(DecreaseRainDrops(newRainEmission));
        }
        currentRainEmission = newRainEmission;
    }

    IEnumerator IncreaseRainDrops(int newRainEmission)
    {
        Debug.Log("Increase raindrops to " + newRainEmission);
        rainIntensityIsChaning = true;
        if (currentRainEmission == 0)
        {
            currentRainEmission = 1;
        }
        for (int i = currentRainEmission; i < newRainEmission; i *= 2)
        {
            yield return new WaitForSeconds(2.0f);
            if (i * 2 > newRainEmission)
            {
                i = newRainEmission;
            }
            foreach (var RainSource in RainSources)
            {
                var particleSystem = RainSource.GetComponent<ParticleSystem>();
                particleSystem.emissionRate = i;
            }
            Debug.Log("Increased raindrops to " + i);
        }
        rainIntensityIsChaning = false;
    }

    IEnumerator DecreaseRainDrops(int newRainEmission)
    {
        Debug.Log("Decrease raindrops to " + newRainEmission);
        rainIntensityIsChaning = true;
        for (int i = currentRainEmission; i > newRainEmission; i /= 2)
        {
            yield return new WaitForSeconds(2.0f);
            if (i / 2 <= newRainEmission)
            {
                i = newRainEmission;
            }
            foreach (var RainSource in RainSources)
            {
                var particleSystem = RainSource.GetComponent<ParticleSystem>();
                particleSystem.emissionRate = i;
            }
            Debug.Log("Decreased raindrops to " + i);
        }
        rainIntensityIsChaning = false;
    }

    public void StopRain()
    {
        ChangeRainIntensity(0);
    }
}
