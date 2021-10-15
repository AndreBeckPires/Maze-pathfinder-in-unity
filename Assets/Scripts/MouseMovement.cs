using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public GameObject mazeG;
    public GameObject rato;

    public int[,] array = new int[19, 22];
    bool U = false, D = false, L = false, R = false, pathencontrado = false;
    int initX = 1;
    int initY = 0;
    int numOfR = 0;
    int temp;
    int marcador;
    // Start is called before the first frame update
    void Start()
    {

        array = mazeG.GetComponent<MazeGenerator>().maze;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            if(!pathencontrado)
            findPath();
        }
        move();
       
    }
    void findPath()
    {

        do
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    if (i == initY && j == initX)
                    {
                        temp = array[i, j];
                        array[i, j] = 2;
                    }
                }
            }

            if (array[initY + 1, initX] == 0)
            {
                D = true;
                numOfR++;
            }
            if (array[initY, initX + 1] == 0)
            {
                R = true;
                numOfR++;
            }
            if (initY >= 2 && array[initY - 1, initX] == 0)
            {
                U = true;
                numOfR++;
            }
            if (array[initY, initX - 1] == 0)
            {
                L = true;
                numOfR++;
            }

            if (numOfR >= 2)
                array[initY, initX] = 3;
  
            if (D == true)
            {
                initY++;
            }
            else if (U == true)
            {
                initY--;
            }
            else if (R == true)
            {
                initX++;
            }
            else if (L == true)
            {
                initX--;
            }


            if (numOfR == 0)
            {
                for (int i = 0; i < 19; i++)
                {
                    for (int j = 0; j < 22; j++)
                    {
                        if (array[i, j] == 3)
                        {
                            initY = i;
                            initX = j;
                        }
                    }
                }
                for (int i = initY; i < 19; i++)
                {
                    for (int j = initX; j < 22; j++)
                    {
                        if (array[i,j] == 2)
                        {
                            array[i,j] = 5;
                        }
                    }
                }
            }
            D = false;
            R = false;
            U = false;
            L = false;
            numOfR = 0;

        } while (initX != 21 && initY != 18);
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                if (array[i, j] == 2 || array[i, j] == 3)
                {

                    array[i, j] = 4;
                }
            }
        }

        //for (int i = 0; i < 19; i++) //z
        //{
        //    for (int j = 0; j < 22; j++) //x
        //    {
        //        UnityEngine.Debug.Log(array[i, j]);

        //    }
        //}
        initX = 1;
        initY = 0;
        UnityEngine.Debug.Log("Path encontrado");
        pathencontrado = true;
    }
    void move()
    {


        //UnityEngine.Debug.Log(initX);
        //UnityEngine.Debug.Log(initY);




        if (Input.GetKeyDown("s"))
        {
            //UnityEngine.Debug.Log(initX);
            //UnityEngine.Debug.Log(initY);

            if (array[initY + 1, initX] == 4)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
                array[initY + 1, initX] = 0;
                initY = initY + 1;
            }
            else if (array[initY - 1, initX] == 4)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
                array[initY - 1, initX] = 0;
                initY = initY - 1;
            }
            else if (array[initY, initX - 1] == 4)
            {
                transform.position = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
                array[initY, initX - 1] = 0;
                initX = initX - 1;

            }
            else if (array[initY, initX + 1] == 4)
            {
                transform.position = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
                array[initY, initX + 1] = 0;
                initX = initX + 1;
            }



        }
    }
}

