using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int attack = 20;
    public int defense = 2;
    public int life = 500;

    public Text txtAttack, txtDefense, txtLife;

    // Start is called before the first frame update
    void Start () {
        BinaryFile.SavePlayer (this);
        CarregaDados();

    }
    // Update is called once per frame
    void Update () {

    }

    public void CarregaDados () {
        int[] loadStats = BinaryFile.LoadPlayer ();

        life = loadStats[0];
        attack = loadStats[1];
        defense = loadStats[2];

    }

    public void UpdateDisplay () {
        txtAttack.text = attack.ToString ();
        txtDefense.text = defense.ToString ();
        txtLife.text = life.ToString ();
    }
}