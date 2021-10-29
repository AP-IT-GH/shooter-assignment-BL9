using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehavior : MonoBehaviour
{
    private float hp = 10;

    private static bool scoreChanged = true;
    private static float score = 0;

    public GameObject HpCounter;
    public GameObject ScoreCounter;

    public float xSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (HpCounter != null)
            HpCounter.GetComponent<Text>().text = hp.ToString("n2");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = horizontal * Time.deltaTime * xSpeed;
        float xPosition = xOffset + transform.localPosition.x;
        this.transform.localPosition = new Vector3(Mathf.Clamp(xPosition, -20f, 20f), transform.localPosition.y, transform.localPosition.z);

        if(scoreChanged && ScoreCounter != null)
            ScoreCounter.GetComponent<Text>().text = score.ToString("n2");
    }

    public void DoDamage(float damage)
    {
        hp -= damage;
        if (HpCounter != null)
            HpCounter.GetComponent<Text>().text = hp.ToString("n2");
    }

    public static void AddScore(float toAdd)
    {
        score += toAdd;
        scoreChanged = true;
    }
}
