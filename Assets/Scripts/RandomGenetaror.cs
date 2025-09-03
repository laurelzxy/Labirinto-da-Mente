using UnityEngine;

public class RandomGenetaror : MonoBehaviour
{
    private bool hasGeneratedThisScene = false;

    //Area Jogavel
    public int playableWidth = 12; //x
    public int playableHeight = 8; //y

    // Moldura 
    public int WallOffset = 10;

    //Prefabs
    public GameObject floarPrefab;
    public GameObject wallPrefabs;
    public GameObject[] obstaclePrefabs;
    public GameObject portalPrefabs;
    public GameObject playerPrefabs;

    public string nextSceneName = "";

    //Zona de segurança, sem obstaculos

    [Min(0)] public int spawnSafeZoneWidth = 2;
    [Min(1)] public int portalSafeZoneWidhtTop = 2;
    [Min(1)] public int portalSafeZonHeight = 3;


    //Controle dos obstaculos

    //Densidade dos obstaculos
    [Range(0f, 1f)] public float obstacleChance = 0.8f;

    public int obstacleLayerY = 2;
    public int MinObstacleGapX = 2;
    public int maxObstacleGapX = 4;

    public int minNoSpawnX = 1;
    public int maxSpawnX = 2;

    public int width => playableWidth;
    public int height => playableHeight;
    public int offset => WallOffset; 





        
    void Start()
    {
        if (hasGeneratedThisScene) return;

        hasGeneratedThisScene = true;
        //GenerateRoom();

    }

    void GenerateRoom()
    {
        int leftWallX = -WallOffset;
        int rightWallX = playableWidth + WallOffset;

        for( int tileX = leftWallX; tileX <= rightWallX; tileX++ )
        {
             for(int tileY = 0;  tileY < playableHeight; tileY++ )
            {
                Vector2 tileWorldPosition = new Vector2( tileX, tileY );

                if (tileY == 0 && tileX >= 0 && tileX < playableWidth)
                {
                    Instantiate(floarPrefab, tileWorldPosition, Quaternion.identity, transform );
                }

                if(tileX == leftWallX || tileX == rightWallX)
                {
                    Instantiate(wallPrefabs, tileWorldPosition, Quaternion.identity, transform);

                }
            }
        }

        if (obstaclePrefabs != null && obstaclePrefabs.Length > 0)
        {
            int firtObstacleY = 2;

            int lastObstacleY = Mathf.Max(2, playableHeight - 3);

            for(int tileY = firtObstacleY; tileY <= lastObstacleY; tileY+=  Mathf.Max(1, obstacleLayerY))
            {
                //int tileX = 1;

                //while( tileX <= playableWidth - 2)
                //{
                //    if(IsExcluded(tileX, tileY))
                //    {
                //        tileX += 1;
                //        continue;
                //    }
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
