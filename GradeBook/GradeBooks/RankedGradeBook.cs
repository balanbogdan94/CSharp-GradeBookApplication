using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            int trashold = (int)Math.Round(Students.Count * (0.2));
            var sortedStudentList = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            if ((sortedStudentList[trashold - 1]) <= averageGrade)
                return 'A';
            else if ((sortedStudentList[(trashold * 2) - 1]) <= averageGrade)
                return 'B';
            else if ((sortedStudentList[(trashold * 3) - 1]) <= averageGrade)
                return 'C';
            else if ((sortedStudentList[(trashold * 4) - 1]) <= averageGrade)
                return 'D';
            return 'F';
        }

    }
}
