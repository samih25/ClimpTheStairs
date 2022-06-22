using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairsSpawner : MonoBehaviour
{
    [SerializeField] GameObject _spawnStairs;
    [SerializeField] GameObject _spawner;
    [SerializeField] static public int _money;
    [SerializeField]  public Text _paraMiktarText;

    private void Update()
    {
        _paraMiktarText.text = (" " + _money + " ");
    }
    public void Stairs()
    {

        Instantiate(_spawnStairs, _spawner.transform.position, _spawner.transform.rotation);
        _money++;

    }







}
