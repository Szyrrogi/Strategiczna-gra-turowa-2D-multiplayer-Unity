using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Ratusz : MonoBehaviour
{
    public GameObject budynek;

    private bool dodaj=false;
    public int nr_jednostki;
    public int druzyna;
    public int poziom = 0;

    public GameObject pole;

    public GameObject zbieracz;
    public GameObject poszukiwacz;
    public GameObject budowlaniec;
    public GameObject adept;

    public Sprite[] budynki;
    public string[] teksty;

    public Sprite loock;

    public Image ramka;


    void Start()
    {
        druzyna = budynek.GetComponent<Budynek>().druzyna;
        budynek.GetComponent<Budynek>().poZniszczeniu = 1;
        StartCoroutine(przyporzadkuj());
    }

    public void jednostkaMulti(string nazwa, ref GameObject nowyZbieracz)
    {
        nowyZbieracz = PhotonNetwork.Instantiate(nazwa, new Vector3(0, 0, 1), Quaternion.identity);
        nowyZbieracz.transform.position = pole.transform.position;
        nowyZbieracz.GetComponent<Jednostka>().druzyna = budynek.GetComponent<Budynek>().druzyna;
        nowyZbieracz.GetComponent<Jednostka>().sojusz = budynek.GetComponent<Budynek>().sojusz;
        nowyZbieracz.transform.position = new Vector3(nowyZbieracz.transform.position.x, nowyZbieracz.transform.position.y, -2f);
        nowyZbieracz.GetComponent<Jednostka>().Aktualizuj();
        nowyZbieracz.GetComponent<Jednostka>().AktualizujPol();    
    }

    void Update()
    {
        ramka.enabled = budynek.GetComponent<Budynek>().strzalka.enabled;
        if(budynek == Jednostka.Select)
        {
            pole = budynek.GetComponent<BudynekRuch>().pole;
            if(Przycisk.budynek[0]==true && Menu.zloto[Menu.tura]>=zbieracz.GetComponent<Jednostka>().cena && Menu.maxludnosc[druzyna] > Menu.ludnosc[druzyna])
            {
                Przycisk.budynek[0]=false;
               if(!pole.GetComponent<Pole>().Zajete && !pole.GetComponent<Pole>().ZajeteLot)
                {
                    Menu.zloto[Menu.tura] -= zbieracz.GetComponent<Jednostka>().cena;
                    GameObject nowyZbieracz = null;
                    if(MenuGlowne.multi)
                    {
                        jednostkaMulti("zbieracz",ref nowyZbieracz);
                    }
                    else
                        nowyZbieracz = Instantiate(zbieracz, pole.transform.position, Quaternion.identity); 
                    Vector3 newPosition = nowyZbieracz.transform.position;
                    newPosition.z = -2f; // Zmiana pozycji w trzecim wymiarze (Z)
                    nowyZbieracz.transform.position = newPosition;
                    nowyZbieracz.GetComponent<Jednostka>().druzyna = druzyna;
                    pole.GetComponent<Pole>().Zajete=true;
                    pole.GetComponent<Pole>().postac=nowyZbieracz;
                }
            }
            if(Przycisk.budynek[1]==true && Menu.zloto[Menu.tura]>=poszukiwacz.GetComponent<Jednostka>().cena && Menu.maxludnosc[druzyna] > Menu.ludnosc[druzyna])
            {
                Przycisk.budynek[1]=false;
               if(!pole.GetComponent<Pole>().Zajete && !pole.GetComponent<Pole>().ZajeteLot)
                {
                    Menu.zloto[Menu.tura] -= poszukiwacz.GetComponent<Jednostka>().cena;
                    GameObject nowyZbieracz = null;
                    if(MenuGlowne.multi)
                    {
                        jednostkaMulti("poszukiwacz",ref nowyZbieracz);
                    }
                    else
                    nowyZbieracz = Instantiate(poszukiwacz, pole.transform.position, Quaternion.identity); 
                    Vector3 newPosition = nowyZbieracz.transform.position;
                    newPosition.z = -2f; // Zmiana pozycji w trzecim wymiarze (Z)
                    nowyZbieracz.transform.position = newPosition;
                    nowyZbieracz.GetComponent<Jednostka>().druzyna = druzyna;
                    pole.GetComponent<Pole>().Zajete=true;
                    pole.GetComponent<Pole>().postac=nowyZbieracz;
                }
            }
            if(Przycisk.budynek[2]==true && Menu.zloto[Menu.tura]>=budowlaniec.GetComponent<Jednostka>().cena  && Menu.maxludnosc[druzyna] > Menu.ludnosc[druzyna])
            {
                Przycisk.budynek[2]=false;
               if(!pole.GetComponent<Pole>().Zajete && !pole.GetComponent<Pole>().ZajeteLot)
                {
                    Menu.zloto[Menu.tura] -= budowlaniec.GetComponent<Jednostka>().cena;
                    GameObject nowyZbieracz = null;
                    if(MenuGlowne.multi)
                    {
                        jednostkaMulti("budowlaniec",ref nowyZbieracz);
                    }
                    else
                    nowyZbieracz = Instantiate(budowlaniec, pole.transform.position, Quaternion.identity); 
                    Vector3 newPosition = nowyZbieracz.transform.position;
                    newPosition.z = -2f; // Zmiana pozycji w trzecim wymiarze (Z)
                    nowyZbieracz.transform.position = newPosition;
                    nowyZbieracz.GetComponent<Jednostka>().druzyna = druzyna;
                    pole.GetComponent<Pole>().Zajete=true;
                    pole.GetComponent<Pole>().postac=nowyZbieracz;
                }
            }
            if(Przycisk.budynek[3]==true && Menu.zloto[Menu.tura]>=adept.GetComponent<Jednostka>().cena  && Menu.maxludnosc[druzyna] > Menu.ludnosc[druzyna])
            {
                Przycisk.budynek[3]=false;
               if(!pole.GetComponent<Pole>().Zajete && !pole.GetComponent<Pole>().ZajeteLot)
                {
                    Menu.zloto[Menu.tura] -= adept.GetComponent<Jednostka>().cena;
                    GameObject nowyZbieracz = null;
                    if(MenuGlowne.multi)
                    {
                        jednostkaMulti("adept",ref nowyZbieracz);
                    }
                    else
                    nowyZbieracz = Instantiate(adept, pole.transform.position, Quaternion.identity); 
                    Vector3 newPosition = nowyZbieracz.transform.position;
                    newPosition.z = -2f; // Zmiana pozycji w trzecim wymiarze (Z)
                    nowyZbieracz.transform.position = newPosition;
                    nowyZbieracz.GetComponent<Jednostka>().druzyna = druzyna;
                    pole.GetComponent<Pole>().Zajete=true;
                    pole.GetComponent<Pole>().postac=nowyZbieracz;
                }
            }
            if(Budowlaniec.punktyBudowyBonus[druzyna] > Menu.ratuszPoziom[druzyna])
            {
                InterfaceBuild.przyciski[4].GetComponent<Image>().sprite = loock;
            }
            if(Przycisk.budynek[4]==true && Menu.zloto[Menu.tura]>=4 + 2 * Menu.ratuszPoziom[druzyna] && Budowlaniec.punktyBudowyBonus[druzyna] <= Menu.ratuszPoziom[druzyna])
            {
                Przycisk.budynek[4]=false;
                Menu.zloto[Menu.tura] -= 4 + 2 * Budowlaniec.punktyBudowyBonus[druzyna];
                Budowlaniec.punktyBudowyBonus[druzyna]++;
                OnMouseDown();
            }
            if(Menu.ratuszPoziom[druzyna] < poziom && budynek.GetComponent<Budynek>().punktyBudowy >= budynek.GetComponent<Budynek>().punktyBudowyMax)
                Menu.ratuszPoziom[druzyna] = poziom;
            if(Przycisk.budynek[5]==true && Menu.drewno[Menu.tura]>=15 + poziom * 5 && Menu.zloto[Menu.tura]>=6 + poziom * 2)
            {
                Przycisk.budynek[5]=false;
                Menu.drewno[Menu.tura] -= 15 + poziom * 5;
                Menu.zloto[Menu.tura] -= 6 + poziom * 2;
                budynek.GetComponent<Budynek>().punktyBudowy = 0;
                budynek.GetComponent<Budynek>().punktyBudowyMax += 3;
                poziom++;
                OnMouseDown();
            }
        }

        if(budynek.GetComponent<Budynek>().punktyBudowy >= budynek.GetComponent<Budynek>().punktyBudowyMax && !dodaj)
        {
            dodaj = true;
            Menu.maxludnosc[druzyna] += 6;
        }
        if(budynek.GetComponent<Budynek>().poZniszczeniu == 2)
        {
            Menu.maxludnosc[druzyna] -= 6;
            Menu.kafelki[(int)budynek.transform.position.x][(int)budynek.transform.position.y].GetComponent<Pole>().Zajete = false;
            while(Menu.bazy[druzyna,nr_jednostki+1] != null)
            {
                Menu.bazy[druzyna,nr_jednostki] = Menu.bazy[druzyna,nr_jednostki+1];
                Menu.bazy[druzyna,nr_jednostki].GetComponent<Ratusz>().nr_jednostki -= 1;
                nr_jednostki++;
            }
            Menu.bazy[druzyna,nr_jednostki] = null;
            Menu.bazyIlosc[druzyna]--;
            Destroy(budynek);

        }
    }

    IEnumerator przyporzadkuj()
    {
        yield return new WaitForSeconds(0.2f);
        Menu.bazy[druzyna , Menu.bazyIlosc[druzyna]] = budynek;
        nr_jednostki = Menu.bazyIlosc[druzyna];
        Menu.bazyIlosc[druzyna]++;
    }


    static public IEnumerator ruchPlynnyCamery(int druzynaBaza)
        {
            float x=Menu.bazy[druzynaBaza,0].transform.position.x + 1f;
            float y=Menu.bazy[druzynaBaza,0].transform.position.y;
            if(y < Menu.kamera.GetComponent<Camera>().orthographicSize * 1.0f - 0.5f)
            {
                y = Menu.kamera.GetComponent<Camera>().orthographicSize * 1.0f - 0.5f;
            }        
            if(x < Menu.kamera.GetComponent<Camera>().orthographicSize * 1.8f - 0.6f)
            {
                x = Menu.kamera.GetComponent<Camera>().orthographicSize * 1.8f - 0.6f;
            }
            if(y > Menu.BoardSizeY - Menu.kamera.GetComponent<Camera>().orthographicSize * 1f + Menu.kamera.GetComponent<Camera>().orthographicSize * 0.2f - 0.5f)
            {
                y = Menu.BoardSizeY - Menu.kamera.GetComponent<Camera>().orthographicSize * 1f + Menu.kamera.GetComponent<Camera>().orthographicSize * 0.2f - 0.5f;
            }
            if(x > Menu.BoardSizeX - Menu.kamera.GetComponent<Camera>().orthographicSize * 1.75f + Menu.kamera.GetComponent<Camera>().orthographicSize * 0.6f - 0.5f)
            {
                x = Menu.BoardSizeX - Menu.kamera.GetComponent<Camera>().orthographicSize * 1.75f + Menu.kamera.GetComponent<Camera>().orthographicSize * 0.6f - 0.5f;
            }
            float a = Menu.kamera.transform.position.x;
            float b = Menu.kamera.transform.position.y;

            float x1 = (x-a)/60;
            float y1 = (y-b)/60;
           for(int i=0; i<60; i++)
            {
                a+=x1;
                b+=y1;
                Vector3 newPosition = new Vector3(a, b, -10f);
                Menu.kamera.transform.position = newPosition;
                yield return new WaitForSeconds(0.001f);
            } 
        }

     public void OnMouseDown()
    {
        if(budynek == Jednostka.Select)
        {
            InterfaceBuild.Czyszczenie(); 
            
            PrzyciskInter Guzikk = InterfaceBuild.przyciski[0].GetComponent<PrzyciskInter>();
            Guzikk.CenaMagic.text = zbieracz.GetComponent<Jednostka>().cena.ToString();
            Guzikk = InterfaceBuild.przyciski[1].GetComponent<PrzyciskInter>();
            Guzikk.CenaMagic.text = poszukiwacz.GetComponent<Jednostka>().cena.ToString();
            Guzikk = InterfaceBuild.przyciski[2].GetComponent<PrzyciskInter>();
            Guzikk.CenaMagic.text = budowlaniec.GetComponent<Jednostka>().cena.ToString();
            Guzikk = InterfaceBuild.przyciski[3].GetComponent<PrzyciskInter>();
            Guzikk.CenaMagic.text = adept.GetComponent<Jednostka>().cena.ToString();
            Guzikk = InterfaceBuild.przyciski[4].GetComponent<PrzyciskInter>();
            Guzikk.CenaMagic.text = (4 + 2 * Budowlaniec.punktyBudowyBonus[druzyna]).ToString();
            Guzikk = InterfaceBuild.przyciski[5].GetComponent<PrzyciskInter>();
            Guzikk.CenaZloto.text = (6+2*poziom).ToString(); Guzikk.CenaDrewno.text = (15+5*poziom).ToString(); 
          
            
            for(int i = 0 ; i < 6 ; i++)
            {
                InterfaceBuild.przyciski[i].GetComponent<Image>().sprite = budynki[i];
                PrzyciskInter Guzik = InterfaceBuild.przyciski[i].GetComponent<PrzyciskInter>();
                Guzik.IconMagic.enabled = true;
                Guzik.Opis.text = teksty[i];  
            }       
            Guzikk = InterfaceBuild.przyciski[5].GetComponent<PrzyciskInter>();
            Guzikk.IconZloto.enabled = true;
            Guzikk.IconDrewno.enabled = true;
            Guzikk.IconMagic.enabled = false;
            
        }
    }
}
