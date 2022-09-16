using System;

namespace GeometryProject
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            PrintInformationAboutTask();
            buildCube();
            
            Console.ReadLine();
        }
        
        static void buildCube()
        {
            var A = new double[3];
            var B = new double[3];
            var C = new double[3];
           

            Console.WriteLine("Введите точку A (вводите по координатам):"); // (x1, y1, z1)
            for (var i = 0; i < 3; i++)
            {
                if (!double.TryParse(Console.ReadLine(), out A[i]))
                {
                    Console.WriteLine("Вы ввели не координаты точек. Попробуйте снова.");
                    Environment.Exit(1);
                }

            }
            Console.WriteLine("Введите точку B (вводите по координатам):"); // (x2, y2, z2)
            for (var i = 0; i < 3; i++)
            {
                if (!double.TryParse(Console.ReadLine(), out B[i]))
                {
                    Console.WriteLine("Вы ввели не координаты точек. Попробуйте снова.");
                    Environment.Exit(1);
                }

            }
            Console.WriteLine("Введите точку C (вводите по координатам):"); // (x3, y3, z3)
            for (var i = 0; i < 3; i++)
            {
                if (!double.TryParse(Console.ReadLine(), out C[i]))
                {
                    Console.WriteLine("Вы ввели не координаты точек. Попробуйте снова.");
                    Environment.Exit(1);
                }

            }
            
            Console.WriteLine($"A: x1 = {A[0]}, y1 = {A[1]}, z1 = {A[2]}");
            Console.WriteLine($"B: x2 = {B[0]}, y2 = {B[1]}, z2 = {B[2]}");
            Console.WriteLine($"C: x3 = {C[0]}, y3 = {C[1]}, z3 = {C[2]}");

            // Проверяем, что точки не лежат на одной прямой.
            // Три точки на плоскости лежат на одной прямой, если площадь треугольника, образованного этими точками, равна нулю.
            // S=1/2((х1-х3)(у2-у3)-(х2-х3)(у1-у3))
            // Три точки в пространстве лежат на одной прямой, если во всех трех проекциях точек на плоскости площади треугольников равны нулю.
            // x1 = A[0] x2 = B[0] x3 = C[0]
            // y1 = A[1] y2 = B[1] y3 = C[1]
            // z1 = A[2] z2 = B[2] z3 = C[2]
            var S1 = 0.5 * ((A[0] - C[0]) * (B[1] - C[1]) - (B[0] - C[0]) * (A[1] - C[1]));
            var S2 = 0.5 * ((A[0] - C[0]) * (B[2] - C[2]) - (B[0] - C[0]) * (A[2] - C[2]));
            var S3 = 0.5 * ((A[2] - C[2]) * (B[1] - C[1]) - (B[2] - C[2]) * (A[1] - C[1]));
            if (S1 == 0 && S2 == 0 && S3 == 0 )
            {
                Console.WriteLine("Точки лежат на одной прямой.");
                return;
            }
            // Примечание: проверить это возможно и следующим способом:
            // Уравнение прямой, проходящей через первые две точки.
            // (x - x1) / (x2 - x1) = (y - y1) / (y2 - y1) = (z - z1) / (z2 - z1)
            // Третья точка также будет лежать на прямой, если подставив ее координаты в уравнения полученной прямой, будут верными три равенства.
            // (x3 - x1) / (x2 - x1) = (y3 - y1) / (y2 - y1) = (z3 - z1) / (z2 - z1)

            // Точки не лежат на одной прямой, а значит задают плоскость в пространстве. AB -- сторона правильного квадрата для куба.
            // Посчитаем длину вектора AB(x2 - x1; y2 - y1; z2 - z1)
            // Она равна sqrt( (x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2
            var edge = Math.Sqrt((B[0] - A[0]) * (B[0] - A[0]) + (B[1] - A[1]) * (B[1] - A[1]) + (B[2] - A[2]) * (B[2] - A[2]));
            Console.WriteLine($"Ребро правильной пирамиды равно: {edge} (Sqrt(({B[0]} - {A[0]}) * ({B[0]} - {A[0]}) + ({B[1]} - {A[1]}) * ({B[1]} - {A[1]}) + ({B[2]} - {A[2]}) * ({B[2]} - {A[2]})))");

            var newC = new double[3];

            // Координаты вектора AB
            var AB = new double[3] {B[0] - A[0], B[1] - A[1], B[2] - A[2]};
            Console.WriteLine($"AB = ({AB[0]}, {AB[1]}, {AB[2]})");

            // Необходимо найти вектор, перпендикулярный вектору AB.
            // https://ru.onlinemschool.com/math/assistance/cartesian_coordinate/plane/
            Console.WriteLine("Вычислите уравнение плоскости по трем точкам A, B, C.");
            Console.WriteLine("Приравняйте скалярное произведение вектора AB и искомого перпендикулярного вектору AB вектора к нулю.");
            // https://matrixcalc.org/slu.html
            Console.WriteLine("Решите систему уравнений.");
            Console.WriteLine("Вы получили координаты вектора*, зависящие от одной переменной (по сути, всевозможные перпендикулярные вектора).");
            Console.WriteLine("Вычисляем длину вектора с помощью формулы sqrt(x^2 + y^2 + z^2).");
            Console.WriteLine("Для получения единичного вектора поделим координаты вектора* на найденную длину, " +
                              "получив пару вариантов единичных перпендикулярных вектору AB векторов");
            Console.WriteLine("Введите их поочередно (по координатам). P1:");
            var P1 = new double[3];
            for (var i = 0; i < 3; i++)
            {
                if (!double.TryParse(Console.ReadLine(), out P1[i]))
                {
                    Console.WriteLine("Вы ввели не координаты точек. Попробуйте снова.");
                    Environment.Exit(1);
                }

            }
            Console.WriteLine("P2:");
            var P2 = new double[3];
            for (var i = 0; i < 3; i++)
            {
                if (!double.TryParse(Console.ReadLine(), out P2[i]))
                {
                    Console.WriteLine("Вы ввели не координаты точек. Попробуйте снова.");
                    Environment.Exit(1);
                }

            }
            Console.WriteLine("Получим координаты точек C\"(1) и C\"(2), сложив координаты единичного перпендикулярного вектора, умноженного на длину ребра, с координатами точки A.");
            var newC1 = new double[3];
            var newC2 = new double[3];
            for (var i = 0; i < 3; i++)
            {
                newC1[i] = P1[i] * edge + A[i];
            }
            for (var i = 0; i < 3; i++)
            {
                newC2[i] = P2[i] * edge + A[i];
            }
            Console.WriteLine($"C\"(1): {newC1[0]}, {newC1[1]}, {newC1[2]}");
            Console.WriteLine($"C\"(2): {newC2[0]}, {newC2[1]}, {newC2[2]}");
            Console.WriteLine("Мы должны выбрать точку в полуплоскости, где лежит точка C. Нас будет устраивать та точка из C\"(1) и C\"(2), которая будет лежать " +
                              "ближе к точке C. Для этого смотрим расстояние между точками в пространстве.");
            // d = sqrt( (x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2
            var distance1 = Math.Sqrt((newC1[0] - C[0]) * (newC1[0] - C[0]) + (newC1[1] - C[1]) * (newC1[1] - C[1]) +
                                      (newC1[2] - C[2]) * (newC1[2] - C[2]));
            var distance2 = Math.Sqrt((newC2[0] - C[0]) * (newC2[0] - C[0]) + (newC2[1] - C[1]) * (newC2[1] - C[1]) +
                                                      (newC2[2] - C[2]) * (newC2[2] - C[2]));
            if (distance1 < distance2)
            {
                for (var i = 0; i < 3; i++)
                {
                    newC[i] = newC1[i];
                }
            }
            else
            {
                for (var i = 0; i < 3; i++)
                {
                    newC[i] = newC2[i];
                }
            }
            Console.WriteLine($"C\": {newC[0]}, {newC[1]}, {newC[2]}");
            // Теперь от точки B необходимо также провести перпендикулярный вектору AB вектор, длина которого равна длине вектора AB.
            // По сути, провести вектор AC" от точки B, а затем получить координаты точки C"" (4 вершины квадрата).
            var newNewC = new double[3];
            for (var i = 0; i < 3; i++)
            {
                newNewC[i] = (newC[i] - A[i]) + B[i];
            }
            
            // Теперь мы хотим получить перпендикулярный вектор к векторам AB и AC". Для этого используем векторное произведение, получив вектор, являющийся еще одной гранью куба.
            // Если два вектора a и b представлены в правом ортонормированном базисе координатами (a_x, a_y, a_z) и (b_x, b_y, b_z), то их векторное произведение имеет
            // координаты (a_y * b_z - a_z * b_y, a_z * b_x - a_x * b_z, a_x * b_y - a_y * b_x).
            // AB x AC"
            var AnewC = new double[3]; // AC"
            for (var i = 0; i < 3; i++)
            {
                AnewC[i] = newC[i] - A[i];
            }

            // Результат векторного произведения AB и AС"
            var AD = new double[3]; 
            AD[0] = AB[1] * AnewC[2] - AB[2] * AnewC[1];
            AD[1] = AB[2] * AnewC[0] - AB[0] * AnewC[2];
            AD[2] = AB[0] * AnewC[1] - AB[1] * AnewC[0];
            
            // Проверим ориентацию тройки векторов, посчитав определитель с координатами этих векторов. Если определитель положителен, то тройка векторов имеет ту же ориентацию, что и система координат (то, что нам и нужно).
            // Иначе, нам необходим противоположный вектор.
            var det = AB[0] * (AnewC[1] * AD[2] - AD[1] * AnewC[2]) - AB[1] * (AnewC[0] * AD[2] - AD[0] * AnewC[2]) +
                      AB[2] * (AnewC[0] * AD[1] - AD[0] * AnewC[1]);
            if (det < 0)
            {
                for (var i = 0; i < 3; i++)
                {
                    AD[i] = -AD[i];
                }
            }
            if (det == 0)
            {
                Console.WriteLine("Векторы являются компланарными."); // Лежат в одной плоскости.
                Environment.Exit(0);
            }
            
            // Превращаем AD в нормированный, а потом умножаем на длину ребра куба  ( edge )
            var HDlen = Math.Sqrt(AD[0] * AD[0] + AD[1] * AD[1] + AD[2] * AD[2]);
            for (var i = 0; i < 3; i++)
            {
                AD[i] = AD[i] / HDlen * edge;
            }
            
            // Получаем координаты точки D.
            var D = new double[3];
            for (var i = 0; i < 3; i++)
            {
                D[i] = AD[i] + A[i];
            }
            
            // Получаем координаты точки D" (над B).
            var newD = new double[3];
            for (var i = 0; i < 3; i++)
            {
                newD[i] = D[i] + AB[i];
            }
            
            // Получаем координаты точки D"" (над C"").
            var newNewD = new double[3];
            for (var i = 0; i < 3; i++)
            {
                newNewD[i] = newD[i] + AnewC[i];
            }
            
            // Получаем координаты точки D""" (над C").
            var newNewNewD = new double[3];
            for (var i = 0; i < 3; i++)
            {
                newNewNewD[i] = D[i] + AnewC[i];
            }
            
            Console.WriteLine();
            Console.WriteLine($"A: x1 = {A[0]}, y1 = {A[1]}, z1 = {A[2]}");
            Console.WriteLine($"B: x2 = {B[0]}, y2 = {B[1]}, z2 = {B[2]}");
            Console.WriteLine($"C\": x3 = {newC[0]}, y3 = {newC[1]}, z3 = {newC[2]}");
            Console.WriteLine($"C\"\": x4 = {newNewC[0]}, y4 = {newNewC[1]}, z4 = {newNewC[2]}");
            Console.WriteLine($"D: x5 = {D[0]}, y5 = {D[1]}, z5 = {D[2]}");
            Console.WriteLine($"D\": x6 = {newD[0]}, y6 = {newD[1]}, z6 = {newD[2]}");
            Console.WriteLine($"D\"\": x7 = {newNewD[0]}, y7 = {newNewD[1]}, z7 = {newNewD[2]}");
            Console.WriteLine($"D\"\"\": x8 = {newNewNewD[0]}, y8 = {newNewNewD[1]}, z8 = {newNewNewD[2]}");
            Console.WriteLine("Теперь берем координаты по х и y, строя проекцию на ось xOy.");
        }
        
        static void PrintInformationAboutTask()
        { 
            // ToDo
        }
    }
}
