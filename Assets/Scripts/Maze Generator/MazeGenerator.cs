//Generates the maze walls

using System.Collections;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject floor;
    public GameObject floorClone;
    public GameObject coin;
    public int rows = 4;
    public int columns = 4;
    public GameObject player1, player2, player3, player4, player5;
    public GameObject chest;

    public GameObject pauseButton;

    public int currentLevel = 1;

    private Cells[,] mazeGrid;
    private int currRow = 0;
    private int currCol = 0;
    private bool scan = false;

    void Start()
    {
        generateMaze();
    }
    void Update()
    {
        chest.transform.Rotate(new Vector3(0f, 75f, 0f) * Time.deltaTime);
        //coin.transform.Rotate(new Vector3(0f, 75f, 0f) * Time.deltaTime);
    }
    
    private void initialize()
    {
       int name = PlayerPrefs.GetInt(("Player"));
       mazeGrid = new Cells[rows, columns];
       float wallSize = wall.transform.localScale.x;
       floorClone = Instantiate(floor, new Vector3(rows * 2 - 1.5f, 0.5f, -(columns * 2) +1.5f), Quaternion.identity);


        //correct
        //makes the water a bit bigger than the maze
        if (rows % 2 == 0)
        {
            floor.transform.localScale = new Vector3((rows / 2) + .5f, 0.0001f, (columns / 2) + .5f);
            //floor.transform.localScale = new Vector3((rows + wallSize ) * rows, 0.0001f, (columns + wallSize) * columns);
        }
        else
        {
            floor.transform.localScale = new Vector3((rows / 2) + 1.5f, 0.0001f, (columns / 2) + 1.5f);
           //floor.transform.localScale = new Vector3((rows * wallSize) * rows, 0.0001f, (columns * wallSize) * columns);
        }

        //spawn boat the player choose
        if (name == 2)
        {
            player2.transform.localScale = new Vector3(.0019f, 0.003f, .0019f);
            player2 = Instantiate(player2, new Vector3(-0.5f, -1000f, 0), Quaternion.Euler(0, -90, 0));
            player2.transform.position = new Vector3(0, .9f, 0);
            player2.GetComponent<Movement>().enabled = true;
            player2.GetComponent<ChestCollision>().enabled = true;
            //player2.GetComponent<BoatFloater>().enabled = true;
            currentLevel = player2.GetComponent<ChestCollision>().levelCounter;
            player2.transform.parent = floorClone.transform;
        }
        else if (name == 3)
        {
            player3.transform.localScale = new Vector3(.0009f, 0.001f, .0009f);
            player3 = Instantiate(player3, new Vector3(-0.5f, -1000f, 0), Quaternion.Euler(0, -90, 0));
            player3.transform.position = new Vector3(0, .5f, 0);
            player3.GetComponent<Movement>().enabled = true;
            player3.GetComponent<ChestCollision>().enabled = true;
            //player3.GetComponent<BoatFloater>().enabled = true;
            currentLevel = player3.GetComponent<ChestCollision>().levelCounter;
            player3.transform.parent = floorClone.transform;
        }
        else if (name == 4)
        {
            player4.transform.localScale = new Vector3(.0009f, 0.001f, .0009f);
            player4 = Instantiate(player4, new Vector3(-0.5f, -1000f, 0), Quaternion.Euler(0, -90, 0));
            player4.transform.position = new Vector3(0, .5f, 0);
            player4.GetComponent<Movement>().enabled = true;
            player4.GetComponent<ChestCollision>().enabled = true;
           // player4.GetComponent<BoatFloater>().enabled = true;
            currentLevel = player4.GetComponent<ChestCollision>().levelCounter;
            player4.transform.parent = floorClone.transform;
        }
        else if (name == 5)
        {
            player5.transform.localScale = new Vector3(.0009f, 0.001f, .0009f);
            player5 = Instantiate(player5, new Vector3(-0.5f, -1000f, 0), Quaternion.Euler(0, -90, 0));
            player5.transform.position = new Vector3(0, .5f, 0);
            player5.GetComponent<Movement>().enabled = true;
            player5.GetComponent<ChestCollision>().enabled = true;
            //player5.GetComponent<BoatFloater>().enabled = true;
            currentLevel = player5.GetComponent<ChestCollision>().levelCounter;
            player5.transform.parent = floorClone.transform;
        }
        else
        {
            player1.transform.localScale = new Vector3(.0009f, 0.001f, .0009f);
            player1 = Instantiate(player1, new Vector3(-0.5f, -1000f, 0), Quaternion.Euler(0, -90, 0));
            player1.transform.position = new Vector3(0, .5f, 0);
            player1.GetComponent<Movement>().enabled = true;
            player1.GetComponent<ChestCollision>().enabled = true;
            //player1.GetComponent<BoatFloater>().enabled = true;
            currentLevel = player1.GetComponent<ChestCollision>().levelCounter;
            player1.transform.parent = floorClone.transform;
        }
        //spawn chest
        if (rows == columns)
        {
            chest = Instantiate(chest, new Vector3((rows - 1) * wallSize, 1.75f, (-columns + 1) * wallSize), Quaternion.identity);
        } else
        {
            chest = Instantiate(chest, new Vector3((rows - 2) * wallSize, 1.75f, (-columns) * wallSize), Quaternion.identity);
        }

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {

                //Initializes each cell with a cell object, each cell containing four wall game objects
                mazeGrid[i, j] = new Cells();

                //spawns coins
                coin = Instantiate(coin, new Vector3(j * wallSize, 1.75f, -i * wallSize), Quaternion.identity);
                coin.GetComponent<CoinCollision>().enabled = true;
                coin.GetComponent<AudioSource>().enabled = true;
                //coin.GetComponent<Coinglow>().enabled = true;
                coin.transform.parent = transform;

                //Creates the upper wall of the maze walls
                //GameObject northWall = Instantiate(wall, new Vector3(j*wallSize, 1.75f, -i*wallSize + 2.25f), Quaternion.identity);
                GameObject northWall = Instantiate(wall, new Vector3(j * wallSize, 1.75f, -i * wallSize + 2.25f), Quaternion.identity);
                northWall.name = "North Wall Row: " + i + " Column: " + j;
                 
                //Creates the lower wall of the maze walls
                GameObject southWall = Instantiate(wall, new Vector3(j*wallSize, 1.75f, -i*wallSize - 2.25f), Quaternion.identity);
                southWall.name = "South Wall Row: " + i + " Column: " + j;

                //Creates the left wall of the maze walls
                GameObject westWall = Instantiate(wall, new Vector3(j*wallSize - 2.145f, 1.75f, -i*wallSize), Quaternion.Euler(0,90,0));
                westWall.name = "West Wall Row: " + i + " Column: " + j;

                //Creates the right wall of the maze walls
                GameObject eastWall = Instantiate(wall, new Vector3(j*wallSize+1.25f+ .48861f, 1.75f, -i*wallSize), Quaternion.Euler(0, 90, 0));
                eastWall.name = "East Wall Row: " + i + " Column: " + j;

                //Sets references to each wall in the Cells object
                mazeGrid[i, j].northWall = northWall;
                mazeGrid[i, j].southWall = southWall;
                mazeGrid[i, j].westWall = westWall;
                mazeGrid[i, j].eastWall = eastWall;

                //Hierarchy stuff

                northWall.transform.parent = transform;
                southWall.transform.parent = transform;
                westWall.transform.parent = transform;
                eastWall.transform.parent = transform;

                /*
                if(i == 0 && j == 0)
                {
                    Destroy(westWall);
                }
                 
                if (i == rows-1 && j == columns-1)
                {
                    Destroy(eastWall);
                }
               */
            }
        }
        //Destroy(coin);
        //destroyWalls();
    }

    //First step in destroying the walls of the hunt and kill algorithm.
    void destroyWalls()
    {
        mazeGrid[currRow, currCol].visited = true;
        //Scan is a boolean variable that will remain false until all cells are properly scanned and checked.
        while (!scan)
        {
            walk();
            hunt();
        }
    }

    //Carves the path for the maze.
    void walk()
    {
        mazeGrid[currRow, currCol].visited = true;
        while (checkUnvisitedNeighbors())
        {
            int direction = Random.Range(0, 4);
            if (direction == 0)
            {
                if (currRow > 0 && !mazeGrid[currRow - 1, currCol].visited)
                {
                    if (mazeGrid[currRow, currCol].northWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].northWall);
                    }

                    currRow--;
                    mazeGrid[currRow, currCol].visited = true;

                    if (mazeGrid[currRow, currCol].southWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].southWall);
                    }
                }
            }
            else if (direction == 1)
            {
                if (currRow < rows - 1 && !mazeGrid[currRow + 1, currCol].visited)
                {
                    if (mazeGrid[currRow, currCol].southWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].southWall);
                    }

                    currRow++;
                    mazeGrid[currRow, currCol].visited = true;

                    if (mazeGrid[currRow, currCol].northWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].northWall);
                    }
                }
            }
            else if (direction == 2)
            {
                if (currCol > 0 && !mazeGrid[currRow, currCol - 1].visited)
                {
                    if (mazeGrid[currRow, currCol].westWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].westWall);
                    }

                    currCol--;
                    mazeGrid[currRow, currCol].visited = true;

                    if (mazeGrid[currRow, currCol].eastWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].eastWall);
                    }
                }
            }
            else if (direction == 3)
            {
                if (currCol < columns - 1 && !mazeGrid[currRow, currCol + 1].visited)
                {
                    if (mazeGrid[currRow, currCol].eastWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].eastWall);
                    }

                    currCol++;
                    mazeGrid[currRow, currCol].visited = true;

                    if (mazeGrid[currRow, currCol].westWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].westWall);
                    }
                }
            }
        }
    }
    
    void hunt()
    {
        scan = true;

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if(!mazeGrid[i,j].visited && checkVisitedNeighbors(i, j))
                {
                    scan = false;
                    currRow = i;
                    currCol = j;
                    mazeGrid[currRow, currCol].visited = true;
                    DestroyAdjacentWalls();
                    return;
                }
            }
        }
    }

    void DestroyAdjacentWalls()
    {
        bool destroyedWall = false;
        
        while(!destroyedWall)
        {
            int direction = Random.Range(0, 4);
            if (direction == 0)
            {
                if (currRow > 0 && mazeGrid[currRow - 1, currCol].visited)
                {
                    if (mazeGrid[currRow, currCol].northWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].northWall);
                    }

                    if (mazeGrid[currRow-1, currCol].southWall)
                    {
                        Destroy(mazeGrid[currRow-1, currCol].southWall);
                    }
                    destroyedWall = true;
                }
            }
            else if (direction == 1)
            {
                if (currRow < rows - 1 && mazeGrid[currRow + 1, currCol].visited)
                {
                    if (mazeGrid[currRow, currCol].southWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].southWall);
                    }

                    if (mazeGrid[currRow+1, currCol].northWall)
                    {
                        Destroy(mazeGrid[currRow+1, currCol].northWall);
                    }
                    destroyedWall = true;
                }
            }
            else if (direction == 2)
            {
                if (currCol > 0 && mazeGrid[currRow, currCol - 1].visited)
                {
                    if (mazeGrid[currRow, currCol].westWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].westWall);
                    }

                    if (mazeGrid[currRow, currCol-1].eastWall)
                    {
                        Destroy(mazeGrid[currRow, currCol-1].eastWall);
                    }
                    destroyedWall = true;
                }
            }
            else if (direction == 3)
            {
                if (currCol < columns - 1 && mazeGrid[currRow, currCol + 1].visited)
                {
                    if (mazeGrid[currRow, currCol].eastWall)
                    {
                        Destroy(mazeGrid[currRow, currCol].eastWall);
                    }

                    if (mazeGrid[currRow, currCol+1].westWall)
                    {
                        Destroy(mazeGrid[currRow, currCol+1].westWall);
                    }
                    destroyedWall = true;
                }
            }
        }
    }

    //Checks to see if there are any unvisited neighbors, checks all 4 directions of each cell.
    bool checkUnvisitedNeighbors()
    {
        if (neighborHelper(currRow - 1, currCol))
        {
            return true;
        }
        if (neighborHelper(currRow + 1, currCol))
        {
            return true;
        }
        if (neighborHelper(currRow, currCol + 1))
        {
            return true;
        }
        if (neighborHelper(currRow, currCol - 1))
        {
            return true;
        }
        return false;
    }

    //Checks to see if the cell itself has been visited or not.
    bool neighborHelper(int r, int c)
    {
        if (r >= 0 && r < rows && c >= 0 && c < columns && !mazeGrid[r, c].visited)
        {
            return true;
        }
        return false;
    }

    //Checks to see if there are any visited neighbors already, checks all 4 directions of each cell.
    bool checkVisitedNeighbors(int r, int c)
    {
        if (r > 0 && mazeGrid[r - 1, c].visited)
        {
            return true;
        }
        if (r < rows - 1 && mazeGrid[r + 1, c].visited)
        {
            return true;
        }
        if (c > 0 && mazeGrid[r, c - 1].visited)
        {
            return true;
        }
        if (c < columns - 1 && mazeGrid[r, c + 1].visited)
        {
            return true;
        }
        return false;
    }

    //Call this method to regenerate the maze.
    public void generateMaze()
    {
        foreach(Transform transform in transform)
        {
            Destroy(transform.gameObject);
            //Debug.Log(transform.gameObject.name);
        }
        initialize();
        //centerCamera();
        currCol = 0;
        currRow = 0;
        scan = false;
        destroyWalls();

    }

    
    //This method will set the camera to view the entire maze.
    public void centerCamera()
    {
        float size = wall.transform.localScale.x;

        Vector3 cameraPosition = Camera.main.transform.position;

        cameraPosition.x = Mathf.Round(columns / 2) * size;
        cameraPosition.y = Mathf.Max(13, Mathf.Max(rows, columns) * 3.5f);
        cameraPosition.z = -Mathf.Round(rows / 2) * size;

        Camera.main.transform.position = cameraPosition;
    }
} 
