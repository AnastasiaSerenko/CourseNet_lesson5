using System;

namespace ConsoleApp1
{
    class Program
    {
        static bool getCoordinates(string nameVector, ref int[] coordinates)
        {
            Console.WriteLine($"Enter coordinate of {nameVector}:");
            var exp = Console.ReadLine();
            string[] strCoord = exp.Split(' ');

            if (strCoord.Length == 3)
            {
                for (int i = 0; i < strCoord.Length; i++)
                {
                    if (!int.TryParse(strCoord[i], out coordinates[i]))
                        return false;
                }
                return true;
            }
            else
                return false;                
        }

        static void Main(string[] args)
        {
            Vector v1, v2;
            int[] CoordVect1 = { 0, 0, 0 };
            int[] CoordVect2 = { 0, 0, 0 };

             Console.WriteLine("Enter coordinates {x, y, z} of vectors\n" +
                 "using space to separate them,\n" +
                 "for example, 4 5 6:\n");

             if (getCoordinates("vector1", ref CoordVect1) &&
                 getCoordinates("vector2", ref CoordVect2))
             {
                 v1 = new Vector(CoordVect1);
                 v2 = new Vector(CoordVect2);                
             }            
             else 
            {             
                 v1 = new Vector(1, 2, 3);
                 v2 = new Vector(4, 5, 6);
                 Console.WriteLine("INCORRECT input coordinates!\n" +
                     "Coordinates was setting with default value");
             }

             Console.WriteLine($"\nSo, given:\n" +
                 $"vector1 = {v1},\n" +
                 $"vector2 = {v2}\n");

             Console.WriteLine("Length of vectors is");
             Console.WriteLine($"|vector1| = {v1.GetLength()}");
             Console.WriteLine($"|vector2| = {v2.GetLength()}\n");

             Console.WriteLine("Scalar multiplier of vectors is");
             Console.WriteLine($"(vector1, vector2) = {Vector.ScalarMultiplier(v1, v2)}\n");

             Console.WriteLine("Vector multiplier of vectors is");
             Console.WriteLine($"[vector1, vector2] = {(v1 * v2)}\n");

             Console.WriteLine("Cosin of the angle between vectors is");
             Console.WriteLine($"cos(a) = {Vector.GetAngle(v1, v2)}\n");

             Console.WriteLine("Summation of vectors is");
             Console.WriteLine($"vector1 + vector2 = {(v1 + v2)}\n");

             Console.WriteLine("Subtraction of vectors is");
             Console.WriteLine($"vector1 - vector2 = {(v1 - v2)}");

            Console.ReadKey();            
        }
    }
}
