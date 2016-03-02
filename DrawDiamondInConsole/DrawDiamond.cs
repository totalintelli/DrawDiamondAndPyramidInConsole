using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
파일 이름: DrawDiamond.cs
기    능: 다이아몬드 모양으로 별을 출력한다.
작 성 자: 송 용 단
작성 일자: 2016년 2월 26일 
*/

namespace DrawDiamondInConsole
{
    class DrawDiamond
    {
        static void Main(string[] args)
        {
            int number;
            char[,] image;
            int row;
            int column;
            DrawDiamond drawDiamond = new DrawDiamond();

            // 수를 사용자로부터 입력받는다.
            number = drawDiamond.Input();

            if (number > 0)
            {
                //다이아몬드 이미지를 만든다.
                drawDiamond.MakeDiamondImage(number, out image, out row, out column);

            // 속이 빈 다이아몬드 이미지를 만든다
            //drawDiamond.MakeEmptyDiamondImage(number, out image, out row, out column);

                // 이미지를 출력한다.
                drawDiamond.Output(image, row, column);
            }

            if (number > 0)
            {
                // 뒤집힌 피라미드 이미지를 만든다
                //drawDiamond.MakeReversePyramidImage(number, out image, out row, out column);

                // 피라미드 이미지를 만든다.
                //drawDiamond.MakePyramidImage(number, out image, out row, out column);

                // 이미지를 출력한다.
                //drawDiamond.Output(image, row, column);
            }

            else
            {
                Console.Write("0보다 큰 자연수를 입력하세요.");
                Console.ReadKey();
            }
        }




        /*
        함수 이름: Input
        기    능: 수를 입력받는다.
        입    력: 없음
        출    력: 수
        */
        int Input()
        {
            int number; // 수

            // 프로그램 설명을 출력한다.
            Console.Write("Program for displaying pattern of *.\nEnter the maximum number of *: ");
            number = Int32.Parse(Console.ReadLine());
            Console.Write("\n\nHere is the Diamond of Stars\n");

            // 프로그램 설명을 출력한다.
            //Console.Write("마지막에 출력할 별의 수를 입력하세요! 피라미드를 만듭니다.");
            //number = Int32.Parse(Console.ReadLine());

            return number;
        }

        /*
        함수 이름: MakeDiamondImage
        기    능: 다이아몬드 이미지를 만든다.
        입    력: 수
        출    력: 이미지
        */
        void MakeDiamondImage(int number, out char[,] image, out int row, out int column)
        {
            int start = 0;  // 별문자를 넣는 시작점
            int end;    // 별문자를 넣는 끝점
            int i;      // 행과 관련된 반복제어변수
            int j;      // 열과 관련된 반복제어변수

            // 이미지를 만들 준비를 한다.
            row = number * 2 - 1;
            column = row;
            end = column - 1;
            image = new char[row, column];

            // 이미지를 만든다.
            i = number - 1;
            while(i >= 0)
            {
                j = 0;
                while(j < column)
                {
                    if(j >= start && j <= end)
                    {
                        image[i, j] = '*';
                        image[column - i - 1, j] = '*';
                    }
                    else
                    {
                        image[i, j] = ' ';
                        image[column - i - 1, j] = ' ';
                    }
                    j++;

                }
                start++;
                end--;
                i--;
            }
        }



        /*
       함수 이름: MakeEmptyDiamondImage
       기    능: 다이아몬드 이미지를 만든다.
       입    력: 수
       출    력: 이미지
       */
        void MakeEmptyDiamondImage(int number, out char[,] image, out int row, out int column)
        {
            int start = 0;  // 별문자를 넣는 시작점
            int end;    // 별문자를 넣는 끝점
            int i;      // 행과 관련된 반복제어변수
            int j;      // 열과 관련된 반복제어변수

            // 이미지를 만들 준비를 한다.
            row = number * 2 - 1;
            column = row;
            end = column - 1;
            image = new char[row, column];

            // 이미지를 만든다.
            i = number - 1;
            while (i >= 0)
            {
                j = 0;
                while (j < column)
                {
                    if (j == start || j == end)
                    {
                        image[i, j] = '*';
                        image[column - i - 1, j] = '*';
                    }
                    else
                    {
                        image[i, j] = ' ';
                        image[column - i - 1, j] = ' ';
                    }
                    j++;

                }
                start++;
                end--;
                i--;
            }
        }




        /*
       함수 이름: MakeReversePyramidImage
       기    능: 뒤집힌 피라미드 이미지를 만든다.
       입    력: 수
       출    력: 이미지
       */
       void MakeReversePyramidImage(int number, out char[,] image, out int row, out int column)
        {
            int start = 0; // 시작점
            int end;       // 끝점
            int i = 0;     // 줄의 위치
            int j;         // 열의 위치

            // 수가 별의 개수와 다른 경우 수를 별의 개수에 맞춘다.
            if(number % 2 == 0)
            {
                number += 1;
            }

            // 줄의 개수를 구한다.
            row = (number + 1 ) / 2;

            // 열의 개수를 구한다.
            column = number;

            // 끝점을 구한다.
            end = column - 1;

            // 이미지를 초기화한다.
            image = new char[row, column];

            // 이미지를 구한다.
            while(i < row)
            {
                j = 0;
                while(j < column)
                {
                    if(j >= start && j <= end)
                    {
                        image[i, j] = '*';
                    }
                    else
                    {
                        image[i, j] = ' ';
                    }
                    j++;
                }
                start++;
                end--;
                i++;
            }


        }



        /*
        함수 이름: Output
        기    능: 이미지를 콘솔에 출력한다.
        입    력: 이미지
        출    력: 없음
        */
        void Output(char[,] image, int row, int column)
        {
            // 배열을 출력한다.
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(image[i, j]);
                }
                // 다음 줄로 이동한다.
                Console.Write("\n");
            }
            Console.ReadKey();
        }



        /*
        함수 이름: MakePyramidImage
        기    능: 피라미드 이미지를 만든다.
        입    력: 수
        출    력: 이미지
        */
        void MakePyramidImage(int number, out char[,] image, out int row, out int column)
        {
            int start = 0; // 별표가 들어가는 시작 위치(Ordinal number), Ordinal number는 프로그래밍에서 0부터 시작한다. 
            int end;       // 별표가 들어가는 마지막 위치(Ordinal number)
            int i;         // 줄의 위치(Ordinal number) vs row -> 줄의 개수 -> Cardinal number -> 1부터 시작한다.
            int j;         // 열의 위치(Ordinal number) vs column -> 열의 개수 -> Cardinal number

            // 수가 짝수이면 별의 개수에 맞춘다.
            if (number % 2 == 0)
            {
                number++;
            }

            // 줄의 개수를 구한다.
            row = (number + 1) / 2;

            // 열의 개수를 구한다.
            column = number;

            // 마지막 위치를 구한다.
            end = number - 1;

            // 이미지를 구한다.
            image = new char[row, column];
            i = row - 1;
            while(i >= 0)
            {
                j = 0;
                while(j < column)
                {
                    if(j >= start && j <= end)
                    {
                        image[i, j] = '*';
                    }
                    else
                    {
                        image[i, j] = ' ';
                    }
                    j++;
                }
                start++;
                end--;
                i--;
            }
        }
    }
}
