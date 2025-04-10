using System;

namespace star
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius: ");
            int radius = int.Parse(Console.ReadLine());
            int size = 2 * (radius + 1);
            //Common Answer
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size * 2; j++)
                {
                    if (i < size && j < size)
                    {
                        //C shape print
                        if ((Math.Abs(size / 2 - i) == radius && IsClose(size / 2, j, radius))
                        || (Math.Abs(size / 2 - j) == radius && IsClose(size / 2, i, radius) && j != size - 1))
                            Console.Write('*');
                        else
                            Console.Write(' ');
                    }
                    else
                    {
                        if (i == (size / 3) || i == (size / 3) * 2
                            || (j - size) == (size / 3) || (j - size) == (size / 3) * 2)
                            Console.Write('*');
                        else
                            Console.Write(' ');
                    }
                }
                Console.Write('\n');
            }
            //TODO: IMPLEMENT CHALLENGE VER.
        }

        // calculate the distance between (x1, y1) and (x2, y2)
        static double SqrDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
        }

        // Checks if two values a and b are within a given distance.
        // |a - b| < distance
        static bool IsClose(double a, double b, double distance)
        {
            return Math.Abs(a - b) < distance;
        }
    }
}


/* example output
Enter the radius: 
>> 5
                *   *   
  *********     *   *   
 *              *   *   
 *              *   *   
 *          ************
 *              *   *   
 *              *   *   
 *              *   *   
 *          ************
 *              *   *   
 *              *   *   
  *********     *   *   

*/

/* example output (CHALLANGE)
Enter the radius: 
>> 5
                *   *  
      *         *   *  
   *     *      *   *  
  *                    
           ************
               *   *   
 *             *   *   
               *   *   
           ************
  *                    
   *     *    *   *    
      *       *   *    

*/