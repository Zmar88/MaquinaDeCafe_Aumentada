using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataBaseManager_MC : MonoBehaviour
{
    public TextMeshProUGUI botao;
    public GameObject PanelTipoCafe, PanelBotao;
    public GameObject textTipoCafe;
    public int sequencia;
    public string tipoCafe;
    public AudioSource audioDoCard;

    public GameObject garrafa, seta, botaoCafeLongoV, botaoCafeCurtoV, botaoCafeLongoAnima, botaoCafeCurtoAnima, capsula, seccaoV, seccaoF, pegaV, pegaF, chavenaLonga, chavenaCurta, cafe, cafe2Longo, cafe2Curto, seta2;

    [SerializeField]
    private AudioClip[] switchAudios;

    // Start is called before the first frame update
    public void Start()
    {
        sequencia = 0;
        tipoCafe = "";

        hideGarrafa();
        hideSeta();
        hideCapsula();
        hideAnimaCap();
        hideChavena();
        hideCafe();
        hideCafe2();
        hideSeta2();
        hideText();

        readFirebaseMaquina();
        audioDoCard.clip = switchAudios[sequencia];
        audioDoCard.Play();
    }

    public void goBack()
    {
        sequencia = sequencia-2;

        hideGarrafa();
        hideSeta();
        hideCapsula();
        hideAnimaCap();
        hideChavena();
        hideCafe();
        hideCafe2();
        hideSeta2();
        hideText();

        nextText();
    }

    //garrafa
    public void hideGarrafa()
    {
        garrafa.SetActive(false);
    }

    public void showGarrafa()
    {
        garrafa.SetActive(true);
    }

    //seta
    public void hideSeta()
    {
        seta.SetActive(false);

        botaoCafeLongoAnima.SetActive(false);
        botaoCafeLongoV.SetActive(true);
        botaoCafeCurtoAnima.SetActive(false);
        botaoCafeCurtoV.SetActive(true);

    }

    public void showSeta()
    {
        Debug.Log("***seta");
        seta.SetActive(true);
    }

    public void showBotoesTipoCafe()
    {
        Debug.Log("***botoes");


        if (tipoCafe == "longo")
        {
            botaoCafeLongoAnima.SetActive(true);
            botaoCafeLongoV.SetActive(false);
        }

        if (tipoCafe == "curto")
        {
            botaoCafeCurtoAnima.SetActive(true);
            botaoCafeCurtoV.SetActive(false);
        }
    }

    //capsula
    public void hideCapsula()
    {
        capsula.SetActive(false);
    }

    public void showCapsula()
    {
        capsula.SetActive(true);
    }

    //seccao e tira
    public void hideAnimaCap()
    {
        seccaoF.SetActive(false);
        seccaoV.SetActive(true);
        pegaF.SetActive(false);
        pegaV.SetActive(true);
    }

    public void showAnimaCap()
    {
        seccaoF.SetActive(true);
        seccaoV.SetActive(false);
        pegaF.SetActive(true);
        pegaV.SetActive(false);
    }

    //chavena
    public void hideChavena()
    {
        chavenaLonga.SetActive(false);
        chavenaCurta.SetActive(false);

    }

    public void showChavena()
    {
        if (tipoCafe == "longo")
        {
            chavenaLonga.SetActive(true);
        }

        if (tipoCafe == "curto")
        {
            chavenaCurta.SetActive(true);
        }
    }

    //cafe
    public void hideCafe()
    {
        cafe.SetActive(false);
    }

    public void showCafe()
    {
        cafe.SetActive(true);
    }

    //cafe2
    public void hideCafe2()
    {
        cafe2Longo.SetActive(false);
        cafe2Curto.SetActive(false);
    }

    public void showCafe2()
    {
        if (tipoCafe == "longo")
        {
            cafe2Longo.SetActive(true);
        }

        if (tipoCafe == "curto")
        {
            cafe2Curto.SetActive(true);
        }
    }

    //seta2
    public void hideSeta2()
    {
        seta2.SetActive(false);
    }

    public void showSeta2()
    {
        seta2.SetActive(true);
    }

    //Texto Tipo de Café
    public void hideText()
    {
        PanelBotao.gameObject.SetActive(true);
        PanelTipoCafe.gameObject.SetActive(false);
        textTipoCafe.gameObject.SetActive(false);
    }

    public void showText()
    {
        PanelBotao.gameObject.SetActive(false);
        PanelTipoCafe.gameObject.SetActive(true);
        textTipoCafe.gameObject.SetActive(true);
    }

    public void nextText()
    {
        if (sequencia != 7)
        {
            botao.text = "Seguinte";
            sequencia++;
            if (sequencia == 4)
            {
                if (tipoCafe == "longo")
                {
                    audioDoCard.clip = switchAudios[4];
                }
                if (tipoCafe == "curto")
                {
                    audioDoCard.clip = switchAudios[8];
                }
            }
            else if (sequencia == 8)
            {
                audioDoCard.clip = null;
            }
            else
            {
                audioDoCard.clip = switchAudios[sequencia];
            }
            audioDoCard.Play();
            readFirebaseMaquina();
        }
        else
        {
            Start();
        }
    }

    //define o tipo de café selecionado pelo utilizador
    public void setCafeCurto()
    {
        tipoCafe = "curto";
        nextText();
    }

    public void setCafeLongo()
    {
        tipoCafe = "longo";
        nextText();
    }

    public void readFirebaseMaquina()
    {
        switch (sequencia)
        {
            case 0:
                showGarrafa();
                hideSeta();
                hideCapsula();
                hideAnimaCap();
                hideChavena();
                hideCafe();
                hideCafe2();
                hideSeta2();
                break;
            case 1:
                hideGarrafa();
                showSeta();
                break;
            case 2:
                hideSeta();
                showCapsula();
                showAnimaCap();
                break;
            case 3:
                hideCapsula();
                hideAnimaCap();
                showText();
                break;
            case 4:
                hideText();
                showSeta2();
                showChavena();
                break;
            case 5:
                hideSeta2();
                hideChavena();
                showSeta();
                Debug.Log("***case 5");
                showBotoesTipoCafe();
                break;
            case 6:
                hideSeta();
                showChavena();
                showCafe();
                break;
            case 7:
                hideCafe();
                showCafe2();
                showSeta2();
                break;
            case 8:
                hideCafe2();
                hideSeta2();
                break;
            default:
                showGarrafa();
                hideSeta();
                hideCapsula();
                hideAnimaCap();
                hideChavena();
                hideCafe();
                hideCafe2();
                hideSeta2();
                break;
        }
    }


}
