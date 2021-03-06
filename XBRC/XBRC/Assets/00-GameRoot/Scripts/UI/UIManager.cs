using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class UIManager : MonoBehaviour
{
    public List<GameObject> _childPanels = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        int i = 0; // need to ignore parent canvas
        foreach (CanvasGroup child in GetComponentsInChildren<CanvasGroup>())
        {
                _childPanels.Add(child.gameObject);
        }
        SetUI();
    }
    public virtual void SetUI() {}

    public void PlayGame()          // can be used to restart game or play game from title menu
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToIntroScene()          // can be used to restart game or play game from title menu
    {
        SceneManager.LoadScene(0);
    }

  
}
