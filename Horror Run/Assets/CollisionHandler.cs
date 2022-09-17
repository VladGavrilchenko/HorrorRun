using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ICrash
{
   void Crash();
}

public class CollisionHandler : MonoBehaviour , ICrash
{
    [SerializeField] private int _indexMainScene;
    [SerializeField] private float _loadDelayCrash = 1f;
    [SerializeField] private float _loadDelayWin = 1f;

    public void Crash()
    {
        FindObjectOfType<PlayerMove>().GetComponent<ICanMove>().SetCantMove();
        GetComponentInChildren<Animator>().SetTrigger("Death");
        Invoke("LoadMainScene", _loadDelayCrash);
    }

    public void EndLevel()
    {
        FindObjectOfType<PlayerMove>().GetComponent<ICanMove>().SetCantMove();
        GetComponentInChildren<Animator>().SetTrigger("Win");
        Invoke("LoadMainScene", _loadDelayWin);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(_indexMainScene);
    }
}
