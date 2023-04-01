using UnityEngine;

public class EventRotationModificationService : MonoBehaviour
{
    public float SeismicEvent(float initYspeed, float timing, float amplitude, float frequency)
    {
        // param timing : duree d'action dans la SafeZone
        return initYspeed + amplitude * 0.01f * Mathf.Sin(frequency * 0.01f * Time.fixedTime);
    }

    public float SolarFlareEvent(float initYspeed, float timing, float amplitude, float delay)
    {
        // param timing : durée de l'event
        return initYspeed;
    }

    public float MeteorologicEvent(float initYspeed, float timing, float amplitude, float delay)
    {
        // param timing : durée de l'event
        return initYspeed;
    }

    public float TsunamiEvent(float initYspeed, float timing, float amplitude, float _maxTravelDistance)
    {
        // param timing : durée de l'event
        return initYspeed;
    }

}
