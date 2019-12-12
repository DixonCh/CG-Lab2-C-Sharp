//Implementation of Turn Test, Computation of Area and Test for Intersection between two lines

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalGeometry
{
    //Define the class Point
    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    //Define the class Line
    public class Line
    {
        public Point p1;
        public Point p2;
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }

    //Define the class TurnTest
    public class TurnTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("To perform Turn Test:");
            Console.WriteLine("---------------------");
            string stop = "no";

            while (stop != "yes")
            {
                //Enter x and y coordinates of Point P0
                Console.WriteLine("\n Enter x and y coordinates of Point P0");
                string Input = Console.ReadLine();
                string[] Number = Input.Split(',', ' ');
                Point P0 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                //Enter x and y coordinates of Point P1
                Console.WriteLine("\n Enter x and y coordinates of Point P1");
                Input = Console.ReadLine();
                Number = Input.Split(',', ' ');
                Point P1 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                //Enter the x and y coordinates of Point P2
                Console.WriteLine("\n Enter x and y coordinates of Point P2");
                Input = Console.ReadLine();
                Number = Input.Split(',', ' ');
                Point P2 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                stop = CheckTurn(P0, P1, P2);
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n Checking Intersection between two lines");
            Console.WriteLine("------------------------------------------");
            string stoplineintersection = "no";

            while (stoplineintersection != "yes")
            {
                //Enter the points for first line L1
                Console.WriteLine("\n Enter points for first line L1");

                //Enter the x and y coordinates of Point P0 of Line L1
                Console.WriteLine("\n Enter x and y coordinates of Point P0 of Line L1");
                string Input = Console.ReadLine();
                string[] Number = Input.Split(',', ' ');
                Point lP0 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                //Enter the x and y coordinates of Point P1 of Line L1
                Console.WriteLine("\n Enter x and y coordinates of Point P1 for Line L1:");
                Input = Console.ReadLine();
                Number = Input.Split(',', ' ');
                Point lP1 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                //Enter the points for second line L2
                Console.WriteLine("\n Enter point for second line L2");

                //Enter  x and y coordinates of Point P0 of Line L2
                Console.WriteLine("\n Enter x and y coordinates of Point P0 of Line L2");
                Input = Console.ReadLine();
                Number = Input.Split(',', ' ');
                Point lP2 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                //Enter the x and y coordinates of Point P1 of Line L2
                Console.WriteLine("\n Enter x and y coordinates of Point P1 of Line L2");
                Input = Console.ReadLine();
                Number = Input.Split(',', ' ');
                Point lP3 = new Point(Convert.ToInt32(Number[0]), Convert.ToInt32(Number[1]));

                Line l1 = new Line(lP0, lP1);
                Line l2 = new Line(lP2, lP3);

                //Method of Checking Line Intersesction has been called here
                LineIntersection(l1, l2);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("\n Do you want to exit - Yes/No?");
                Console.WriteLine("---------------------------------");
                stoplineintersection = Console.ReadLine();
            }
        }

        //Checking Turn Test
        public static string CheckTurn(Point p0, Point p1, Point p2)
        {
            double area = ComputeArea(p0, p1, p2);
            Console.WriteLine("\n The area of Triangle is :" + area);
            if (area > 0)
            {
                Console.WriteLine("\n The given point is Left Turn along point P1.");
            }
            else if (area < 0)
            {
                Console.WriteLine("\n The given point is Right Turn along point P1.");
            }
            else
            {
                Console.WriteLine("\n The given points are collinear.");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("\n Do you want to check for line intersection between two points - Yes/No?");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            string check = Console.ReadLine();
            return check;
        }

        //Computing the Area
        public static double ComputeArea(Point p0, Point p1, Point p2)
        {
            double area = 0;
            area = 0.5 * (p0.x * p1.y + p0.y * p2.x + p1.x * p2.y - p0.x * p2.y - p0.y * p1.x - p2.x * p1.y);
            return area;
        }

        //Checking the Intersection between Lines
        public static void LineIntersection(Line l1, Line l2)
        {
            //Area of Triangle pqr
            double pqr = ComputeArea(l1.p1, l1.p2, l2.p1);
            //Area of Triangle pqs
            double pqs = ComputeArea(l1.p1, l1.p2, l2.p2);
            //Area of Triangle rsp
            double rsp = ComputeArea(l2.p1, l2.p2, l1.p1);
            //Area of Triangle rsq
            double rsq = ComputeArea(l2.p1, l2.p2, l1.p2);

            //Checking the area of every triangle 
            if (pqr == 0 || pqs == 0 || rsp == 0 || rsq == 0)
            {
                Console.WriteLine("Lines intersect with each other.");
                Console.WriteLine("--------------------------------");

            }
            else if (((pqr > 0 && pqs < 0) && (rsp > 0 && rsq < 0)) || ((pqr > 0 && pqs < 0) && (rsp < 0 && rsq > 0)) || ((pqr < 0 && pqs > 0) && (rsp < 0 && rsq > 0)) || ((pqr < 0 && pqs > 0) && (rsp > 0 && rsq < 0)))
            {
                Console.WriteLine("There is Pure Intersection of Line.");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Lines do not intersect with each other.");
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
