using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    public AnaCember anaCember;
    public Animator animator;
    public Text donenCemverText;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacAtıs;
    bool kontrol = true;
    AudioSource carpisma;

    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        donenCemverText.text = SceneManager.GetActiveScene().name;
        carpisma = GetComponent<AudioSource>();

        if (kacAtıs < 2)
        {
            bir.text = kacAtıs + "";
        }
        else if (kacAtıs < 3)
        {
            bir.text = kacAtıs + "";
            iki.text = (kacAtıs - 1) + "";
        }
        else
        {
            bir.text = kacAtıs + "";
            iki.text = (kacAtıs - 1) + "";
            uc.text = (kacAtıs - 2) + "";
        }
    }
    public void kalanText()
    {
        kacAtıs--;

        if (kacAtıs < 2)
        {
            bir.text = kacAtıs + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacAtıs < 3)
        {
            bir.text = kacAtıs + "";
            iki.text = (kacAtıs - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacAtıs + "";
            iki.text = (kacAtıs - 1) + "";
            uc.text = (kacAtıs - 2) + "";
        }
        if (kacAtıs == 0)
        {
            StartCoroutine(yeniLevel());
        }
    }
    IEnumerator yeniLevel()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
       
    }


    public void OyunBitti()
    {
        Debug.Log("0");
        donenCember.GetComponent<Dondurme>().enabled = false;
        Debug.Log("1");

        anaCember.enabled = false;
        Debug.Log("2");

        carpisma.Play();
        Debug.Log("3");

        animator.SetTrigger("oyunbitti");
        Debug.Log("4");

        kontrol = false;
        Invoke("CagirilanMetot",2);
    }

    void CagirilanMetot()
    {
        SceneManager.LoadScene("AnaMenu");
    }

    
}
