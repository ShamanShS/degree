using System;

namespace degree;

class degree
{
    static void Main()
    {
        System.Console.WriteLine("Прямое - 1");
        System.Console.WriteLine("Обратное - 2");
        Int64 t = Convert.ToInt64(Console.ReadLine());
        switch (t)
        {
            case 1:
                System.Console.WriteLine("Введите чисто, степень и MOD");
                Int64 v = Convert.ToInt64(Console.ReadLine());
                Int64 p = Convert.ToInt64(Console.ReadLine());
                Int64 m = Convert.ToInt64(Console.ReadLine());
                System.Console.WriteLine(Power(v, p, m));
            break;

            case 2:
                System.Console.WriteLine("Введите чисто и MOD");
                Int64 v1 = Convert.ToInt64(Console.ReadLine());
                Int64 p1 = Convert.ToInt64(Console.ReadLine());
                Int64 m1 = Convert.ToInt64(Console.ReadLine());
                System.Console.WriteLine(PowerR(v1, p1, m1));
            break;
        }
    }

    static Int64 Power(Int64 value, Int64 pow, Int64 mod)
    {
        Int64 result = 1;
        while (pow > 0)
        {
            if (pow % 2 == 1)
            {
                result = (result*value) % mod;

            }
            value = (value*value) % mod;
            pow /= 2;
        }
        return result;
    }
    
    static Int64 PowerR(Int64 value, Int64 pow, Int64 mod)
    {
        Int64 result = 1;
        for (Int64 i = pow; i > 0; i--)
        {
            result = (result*result) % mod;
            if(i == 1)
            {
                result = (result* value) % mod;
            }
        }
        return result;
    }

}
