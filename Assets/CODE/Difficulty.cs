using UnityEngine;

public static class Difficulty {

    static float secondsToMaxDifficulty = 30;


    public static float GetDiffucultyPercent() {
        return Mathf.Clamp01(Time.time / secondsToMaxDifficulty);
    }

}
