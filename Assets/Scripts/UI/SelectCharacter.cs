using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    private int index;
    [SerializeField] private Image Characterimage;
    [SerializeField] private TextMeshProUGUI CharacterName;

    private GameManager gameManager;

    private void Start()
    {
        gameManager= GameManager.Instance;

        index = PlayerPrefs.GetInt("PlayerIndex");

        if(index > gameManager.CharacterList.Count - 1)
        {
            index = 0;
        }

        ChangeCharacter();
    }

    private void ChangeCharacter()
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
        Characterimage.sprite = gameManager.CharacterList[index].image;
        CharacterName.text = gameManager.CharacterList[index].Name;


    }

    public void NextCharacter()
    {
        if(index == gameManager.CharacterList.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        ChangeCharacter();
    }

    public void PreviousCharacter()
    {
        if (index == 0)
        {
            index = gameManager.CharacterList.Count - 1;
        }
        else
        {
            index -= 1;
        }

        ChangeCharacter();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
