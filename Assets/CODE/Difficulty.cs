using UnityEngine;

public static class Difficulty {

    static float secondsToMaxDifficulty = 30;
    static float startupTime = 0f;


    public static float GetDiffucultyPercent() {
        return Mathf.Clamp01((Time.time - startupTime) / secondsToMaxDifficulty);
    }

    public static void ResetDiffuculty() {
        startupTime = Time.time;
    }

}
