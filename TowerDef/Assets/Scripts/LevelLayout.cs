using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelLayout : MonoBehaviour
{
    GameTile wallTile;
    List<char[,]> Maplist = new List<char[,]>();
    List<string> nameMapList = new List<string>();
    [SerializeField] List<GameObject> imageMap = new List<GameObject>();

    const int ColCount = 16;
    const int RowCount = 10;

    private void Awake()
    {
        Maplist.Add(GreatWallSect79);
        Maplist.Add(NuclearWinter);
        Maplist.Add(HepburnMineField);
        Maplist.Add(heatedSkirmish);
        Maplist.Add(NoMansLand);

        nameMapList.Add(nomGreatWallSect79);
        nameMapList.Add(nomNuclearWinter);
        nameMapList.Add(nomHepburnMineField);
        nameMapList.Add(nomheatedSkirmish);
        nameMapList.Add(nomNoMansLand);


    }

    //methode pour charger les cartes
    public void ChargerCarte(int indexMap, GameObject gameTilePrefab, GameManager gm, ref GameTile spawnTile, ref GameTile endTile, ref GameTile[,] gameTiles, ref string nom)
    {
        nom = nameMapList[indexMap];
        Instantiate(imageMap[indexMap], this.transform.position, Quaternion.identity);

        for (int x = 0; x < ColCount; x++)
        {
            for (int y = 0; y < RowCount; y++)
            {
                //Debug.Log($"index = {indexMap} X = {x} Y = {y}");
                var spawnPosition = new Vector3(x, y, 0);
                var tile = Instantiate(gameTilePrefab, spawnPosition, Quaternion.identity);
                gameTiles[y,x] = tile.GetComponent<GameTile>(); 
                gameTiles[y, x].GM = gm;
                gameTiles[y, x].X = x;
                gameTiles[y, x].Y = y;
                if ((x + y) % 2 == 0)
                {
                    gameTiles[y, x].TurnGrey(0.5f);
                }

                if (Maplist[indexMap][y, x] == 'X')
                {
                    wallTile = gameTiles[y, x];
                    wallTile.SetWall();
                }
                else if (Maplist[indexMap][y, x] == 'S')
                {
                    spawnTile = gameTiles[y, x];
                    spawnTile.SetEnemySpawn();

                }
                else if (Maplist[indexMap][y, x] == 'F')
                {
                    endTile = gameTiles[y, x];
                    endTile.SetExit();
                }
            }
        }
    }

    internal int NextIndexMap(int indexMap)
    {
        indexMap++;
        if(indexMap > Maplist.Count-1)
        {
            indexMap = 0;
        }

        return indexMap;
    }

    #region Carte
    string nomGreatWallSect79 = "GreatWamSect79";
    char[,] GreatWallSect79 = new char[,]
{
    {' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X'}, //1
    {' ', ' ', ' ', ' ', ' ', 'X', 'X', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', 'X'}, //2
    {' ', 'X', ' ', ' ', ' ', 'X', 'X', ' ', 'X', ' ', ' ', 'X', ' ', ' ', ' ', 'X'}, //3
    {' ', ' ', 'X', ' ', ' ', ' ', 'X', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //4
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', 'F'}, //5
    {' ', 'X', ' ', ' ', ' ', ' ', 'X', ' ', ' ', 'X', ' ', ' ', 'X', ' ', ' ', ' '}, //6
    {' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', 'X'}, //7
    {'S', ' ', ' ', ' ', ' ', 'X', 'X', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', 'X'}, //8
    {' ', 'X', ' ', ' ', ' ', 'X', 'X', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', 'X'}, //9
    {' ', ' ', ' ', ' ', ' ', 'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X'}  //10
  //  1    2    3    4    5    6    7   8     9    10   11  12    13   14   15   16
};
    string nomNuclearWinter = "NuclearWinter";
    char[,] NuclearWinter = new char[,]
{
    {'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}, //1
    {' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', ' ', ' '}, //2
    {'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'F'}, //3
    {'X', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', 'X', 'X', ' ', ' ', ' '}, //4
    {'X', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ', ' ', ' ', 'X', 'X'}, //5
    {'X', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ', ' ', ' ', 'X', 'X'}, //6
    {'X', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', 'X', 'X', ' ', 'X', 'X'}, //7
    {'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X'}, //8
    {'X', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ', ' ', ' ', 'X', 'X'}, //9
    {'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}  //10
  //  1    2    3    4    5    6    7   8     9    10   11  12    13   14   15   16
};

    string nomHepburnMineField = "HepburnMineField";
    char[,] HepburnMineField = new char[,]
{
    {'X', 'X', ' ', ' ', ' ', ' ', ' ', 'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //1
    {'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //2
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', 'X', ' ', ' ', ' '}, //3
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', ' ', ' '}, //4
    {'S', ' ', ' ', ' ', 'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'F'}, //5
    {' ', ' ', ' ', ' ', 'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //6
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' '}, //7
    {'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' '}, //8
    {'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //9
    {'X', 'X', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}  //10
  //  1    2    3    4    5    6    7   8     9    10   11  12    13   14   15   16
};
    string nomheatedSkirmish = "heatedSkirmish";
    char[,] heatedSkirmish = new char[,]
{
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' '}, //1
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' '}, //2
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' '}, //3
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', 'X', 'X', ' ', ' ', ' ', ' ', ' '}, //4
    {'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'F'}, //5
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', 'X', 'X', ' ', ' ', ' ', ' ', ' '}, //6
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //7
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //8
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //9
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}  //10
  //  1    2    3    4    5    6    7   8     9    10   11  12    13   14   15   16
};
    string nomNoMansLand = "NoMansLand";
    char[,] NoMansLand = new char[,]
{
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //1
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //2
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //3
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //4
    {'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'F'}, //5
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //6
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //7
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //8
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //9
    {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' '}  //10
  //  1    2    3    4    5    6    7   8     9    10   11  12    13   14   15   16
};
    #endregion
}
