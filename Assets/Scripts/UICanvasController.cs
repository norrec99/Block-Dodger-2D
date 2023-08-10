using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICanvasController : MonoBehaviour
{
    [SerializeField] private GameObject tapToStart;
    [SerializeField] private TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IsGameStarted())
            {
                tapToStart.SetActive(false);
            }
            scoreText.SetText(GameManager.Instance.GetScore().ToString());
        }
    }
}
