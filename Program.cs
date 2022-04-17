using System.Diagnostics;

namespace Name
{
    struct Point{
        private double x;
        private double y;
        public Point(double x, double y){
            this.x = x;
            this.y = y;
        }
        public double X{
            get => x;
        }
        public double Y{
            get => y;
        }
        public void print(){
            System.Console.WriteLine($"({x}, {y})");
        }
    }
    class Name
    {

        // Graham
        public static void qSort(List<Point> array, int l, int h){
            Point m = array[l + (h - l)/2];
            int i = l;
            int j = h;
            while (i <= j)
            {
                while (rotate(array[0], m, array[i]) < 0)
                {
                    i++;
                }
                while (rotate(array[0], m, array[j]) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Point tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                qSort(array, l, j);
            }
            if (h > i)
            {
                qSort(array, i, h);
            }
        }
        public static void Graham(){

            bool enter = true;
            List<Point> pnts = new List<Point>();
            while(enter){
                double a;
                double b;
                if (double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b))
                {
                    pnts.Add(new Point(a, b));
                } else {
                    enter = false;
                }
            }


            for (int i = 0; i < pnts.Count; i++)
            {
                if (pnts[i].X < pnts[0].X){
                    Point f = pnts[0];
                    pnts[0] = pnts[i];
                    pnts[i] = f;
                        
                    }
            }

            
            
            qSort(pnts, 1, pnts.Count - 1);
            
            List<Point> stack = new List<Point>();
            stack.Add(pnts[0]);
            stack.Add(pnts[1]);
            for (int i = 2; i < pnts.Count; i++)
            {
                while(rotate(stack[stack.Count - 2], stack[stack.Count-1], pnts[i]) < 0){
                    stack.RemoveAt(stack.Count - 1);
                }
                stack.Add(pnts[i]);
            }
            foreach (var item in stack)
            {
                item.print();
            }


        }
        public static double rotate(Point a, Point b, Point c){
            return (b.X - a.X) * (c.Y - b.Y) - (b.Y - a.Y) * (c.X - b.X);
        }
        //


        // Garner

        public static int gcd (int a, int b, ref int x, ref int y) {
	        if (a == 0) {
		        x = 0; y = 1;
		    return b;
	        }
	        int x1 = 0, y1 = 0;
	        int d = gcd (b%a, a, ref x1, ref y1);
	        x = y1 - (b / a) * x1;
	        y = x1;
	        return d;
            }
        public static int[ , ] QQ(int n, int[] p){
            int [ , ] q = new int[n, n];
            int x = 0, y = 0;
            for (int i = 0; i < p.Length-1; i++)
            {
                for (int j = i+1; j < p.Length; j++)
                {
                    int g = gcd (p[i], p[j], ref x, ref y);
            	    q[i, j] = (x % p[j] + p[j]) % p[j];
                }
            }
            return q;
        
        }
        public static int garner(){
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            int[] p = new int[n];
            int[] x = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
                p[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[ , ] r = QQ(n, p);
            for (int i = 0; i < n; i++)
            {
                x[i] = a[i];
                for (int j = 0; j < i; j++)
                {
		            x[i] = (r[j, i] * (x[i] - x[j])) % p[i];
		            if (x[i] < 0)  x[i] += p[i];
	            }
            }
            int res = 0;
            for (int i = 0; i < x.Length; i++)
            {
                int tmp = x[i];
                for (int j = 0; j < i; j++)
                {
                    tmp *= p[j];
                }
                res += tmp;
            }
            return res;
        }

        //


        public static void Main(){
            
            Graham();
            System.Console.WriteLine(garner());
            
            
        }
    }
}