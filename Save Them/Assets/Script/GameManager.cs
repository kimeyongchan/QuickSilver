using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject UserPlayerPrefab;
    public GameObject TilePrefab;

    public int mapSize = 8;

    List <List<Tile>> map = new List<List<Tile>>();
    List<Player> players = new List<Player>();

    int currentPlayerIndex = 0;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        generateMap();
        generatePlayers();
    }
	
	// Update is called once per frame
	void Update () {
       // players[currentPlayerIndex].TurnUpdate();
	}

    public void nextTurn()
    {
        currentPlayerIndex = 0;
    }

    public void moveCurrentPlayer(AIPlayer aiplayer)
    {
        players[currentPlayerIndex].moveDestination = 
            aiplayer.transform.position + aiplayer.sight;
    }

    void generatePlayers()
    {
        
        UserPlayer player;
        float i, j;
        player = ((GameObject)Instantiate(UserPlayerPrefab, 
            new Vector3(
                0, 
            2.5f, 
            0), 
            Quaternion.Euler(new Vector3(0,0,0)))).GetComponent<UserPlayer>();

        players.Add(player);
        /*
        

        Vector3 aivector = new Vector3(4, 1.5f, 0);
        AIPlayer aiplayer = ((GameObject)Instantiate(AIPlayerPrefab,
            aivector,
           Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
        i = aivector.x; j = aivector.y;
        aiplayer.sight = aiplayer.sight_left;
        aiplayer.gridPosition = new Vector2(i, j);
        players.Add(aiplayer);

        aivector = new Vector3(0, 1.5f, 4);
        aiplayer = ((GameObject)Instantiate(AIPlayerPrefab,
            aivector,
           Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
        i = aivector.x; j = aivector.y;
        aiplayer.sight = aiplayer.sight_right;
        aiplayer.gridPosition = new Vector2(i, j);
        players.Add(aiplayer);

        aivector = new Vector3(2, 1.5f, 2);
        aiplayer = ((GameObject)Instantiate(AIPlayerPrefab,
            aivector,
           Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
        i = aivector.x; j = aivector.y;
        aiplayer.sight = aiplayer.sight_down;
        aiplayer.gridPosition = new Vector2(i, j);
        players.Add(aiplayer);

        aivector = new Vector3(-1, 1.5f, 3);
        aiplayer = ((GameObject)Instantiate(AIPlayerPrefab,
            aivector,
           Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
        i = aivector.x; j = aivector.y;
        aiplayer.sight = aiplayer.sight_up;
        aiplayer.gridPosition = new Vector2(i, j);
        players.Add(aiplayer);
        */
    }
    void generateMap()
    {
        map = new List<List<Tile>>();
        for (int i = 0; i < mapSize; i++)
        {
            List<Tile> row = new List<Tile>();
            for (int j = 0; j < mapSize; j++)
            {
                Tile tile = ((GameObject)Instantiate(TilePrefab,
                    new Vector3(i - Mathf.Floor(mapSize / 2), 0,
                        -j + Mathf.Floor(mapSize / 2))*5,
                Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.gridPosition = new Vector2(i, j);
                row.Add(tile);
            }
            map.Add(row);
        }
    }
}
