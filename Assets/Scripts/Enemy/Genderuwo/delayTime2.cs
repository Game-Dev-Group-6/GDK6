using UnityEngine;

public class delayTime2 : MonoBehaviour
{
    public float Timer;

    public bool Delay(float timeDelay)
    {
        Timer += Time.deltaTime;
        if (Timer > timeDelay)
        {
            Timer = 0;
            return true;
        }
        return false;

    }
}
