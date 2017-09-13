using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTrack1
{
public   class Level
    {
        // int levelNum;
        public int q1, q2, a1, a2, a3;
        public int correctAns;
        public string format;

        public Level(int Q1,int Q2, int A1,int A2,int A3, int CorrectAns, string Format)
        {
         // levelNum = LevelNum;
            q1 = Q1;
            q2 = Q2;
            a1 = A1;
            a2 = A2;
            a3 = A3;
            correctAns = CorrectAns;
            format = Format;
        }



    }
}
