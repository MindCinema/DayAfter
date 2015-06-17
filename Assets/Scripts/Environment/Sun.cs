using UnityEngine;
using System.Collections;
using System;

public class Sun : MonoBehaviour
{

    //private const double radToDeg = 1;
    private const double radToDeg = 0.01745;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePosition(DateTime Time)
    {        
        /*
        //K=Pi/180=0.01745 (zur Umrechnung von Grad- in Bogenmass)
        //deklin = -23.45*cos(K*360*(tageszahl+10)/365)
        var declination = -23.44 * Math.Cos(radToDeg * 360 * (Time.DayOfYear + 10) / 365);
        //zeitgleichung = 60*[-0.171*sin(0.0337*tageszahl + 0.465) - 0.1299*sin(0.01787*tageszahl - 0.168)]
        var equationOfTime = 60 * (-0.171 * Math.Sin(0.0337 * Time.DayOfYear + 0.465) - 0.1299 * Math.Sin(0.01787 * Time.DayOfYear - 0.168));
        //stundenwinkel = 15*(stunde + minute/60 - (15.0-long)/15.0 - 12 + zeitgleichung/60)
        var hourAngle = 15 * (Time.Hour + Time.Minute / 60 - (15 - longitude) / 15 - 12 + equationOfTime / 60);
        //x = sin(hoehe) = sin(K*lat)*sin(K*deklin) + cos(K*lat)*cos(K*deklin)*Math.cos(K*stundenwinkel)
        var height = Math.Sin(radToDeg * latitude) * Math.Sin(radToDeg * declination) + Math.Cos(radToDeg * latitude) * Math.Cos(radToDeg * declination) * Math.Cos(radToDeg * hourAngle);
        var x = Math.Sin(height);
        //y = cos(azimut) = -[sin(K*lat)*sin(K*hoehe) - sin(K*deklin)] / [cos(K*lat)*sin(arccos(sin(K*hoehe)))]
        var azimut = -(Math.Sin(radToDeg * latitude) * Math.Sin(radToDeg * height) - Math.Sin(radToDeg * declination)) / (Math.Cos(radToDeg * latitude) * Math.Sin(Math.Acos(Math.Sin(radToDeg * height))));
        var y = Math.Cos(azimut);
        var xDeg = Math.Asin(x) / radToDeg;
        var yDeg = Math.Acos(y) / radToDeg;
        Vector3 vector = new Vector3((float)xDeg, 90, (float)yDeg);
        gameObject.transform.rotation.Set((float)xDeg, 90, (float)yDeg, 0);
        */

    }
}
