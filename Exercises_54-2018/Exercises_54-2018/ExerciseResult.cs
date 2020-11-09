using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises_54_2018
{
    class ExerciseResult
    {

        private static int idd = 0;
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentIndex { get; set; }
        public int Point { get; set; }



        public ExerciseResult(string name, string index, int point)
        {
            Id = idd++;
            StudentName = name;
            StudentIndex = index;
            Point = point;
        }
        public ExerciseResult() { }
        public override string ToString()
       => Id + " " + StudentName + " " + StudentIndex + " " + Point;
    }
}
