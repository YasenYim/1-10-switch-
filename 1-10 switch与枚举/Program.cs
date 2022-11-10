using System;
/*1. 写一个玩家与电脑对战的剪刀石头布游戏，玩家输入手势，电脑随机出一个手势。游戏反复进行10次，结束后显示玩家胜利了几次。
  2. 写一个交通模拟程序，程序持续运行，交通灯规则为：
  --绿灯3秒
  --黄灯0.4秒
  --红灯3秒
*/
namespace _1_10_switch与枚举
{
    enum 手势
    {
        无 = 0,
        石头 = 1,
        剪刀 = 2,
        布 = 3,
    }

    enum 结果
    {
        平 = 0,
        胜 = 1,
        负 = 2,
        无 = 3,
    }


    class Program
    {
        static Random random = new Random();

        // 玩家输入函数
        static 手势 PlayerInput()
        {
            Console.WriteLine("请玩家输入 1 石头  2 剪刀  3 布");
            string input = Console.ReadLine();
            手势 s1 = 手势.无;

            while (s1 == 手势.无)
            {
                switch (input)
                {
                    case "1":
                        s1 = 手势.石头;
                        break;
                    case "2":
                        s1 = 手势.剪刀;
                        break;
                    case "3":
                        s1 = 手势.布;
                        break;
                    default:
                        s1 = 手势.无;
                        break;
                }
                if (s1 == 手势.无)
                { Console.WriteLine("请重新输入~ 1 石头   2 剪刀   3 布"); }
                break;
            }
            return s1;
        }

        // PK 函数
        static 结果 PK(手势 s1, 手势 s2)
        {
            if (s1 == s2)
            { return 结果.平; }

            if (s1 == 手势.石头)
            {
                if (s2 == 手势.剪刀)
                {
                    return 结果.胜;
                }
                if (s2 == 手势.布)
                {
                    return 结果.负;
                }
            }

            else if (s1 == 手势.剪刀)
            {
                if (s2 == 手势.石头)
                {
                    return 结果.负;
                }
                if (s2 == 手势.布)
                {
                    return 结果.胜;
                }
            }

            else if (s1 == 手势.布)
            {
                if (s2 == 手势.石头)
                {
                   return 结果.胜;
                }
                if (s2 == 手势.剪刀)
                {
                    return 结果.负;
                }
            }
            return 结果.无;
        
        }



        static void Main(string[] args)
        {
            const int total = 5;  // 加入const代表total值不能改，加入const代表是常量
            int round = 0;
            int win = 0;
            int lose = 0;
            int draw = 0;

            while (round < total)
            {
                Console.WriteLine($"--------- 第 {round+1} 局 ----------");
                // 用户输入的数字，如果输入是错误的话，会出不去，直到你输入正确为止
                手势 s1 = PlayerInput();

                // 电脑随机一个手势
                int b = random.Next(1, 4);
                手势 s2 = (手势)b;   // 将数字转化为枚举值
                Console.WriteLine("对方出" + s2);

                结果 result = PK(s1, s2);
                switch (result)
                {
                    case 结果.胜:
                        win++;
                        Console.WriteLine("赢了");
                        break;
                    case 结果.平:
                        draw++;
                        Console.WriteLine("平局");
                        break;
                    case 结果.负:
                        lose++;
                        Console.WriteLine("输了");
                        break;
                    case 结果.无:
                        Console.WriteLine("此次输入无效");
                        break;
                }
                round++;
            }

            Console.WriteLine($"共进行了{total}局游戏");
            Console.WriteLine($"胜：{win}次     平：{draw}次   负：{lose}次");

            Console.ReadKey();
        }
    }
}
