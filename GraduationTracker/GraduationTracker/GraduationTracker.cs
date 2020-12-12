/* This has main method to find out weather strudent is 
 * graduated or not alog with standing position
 * 
 */

using System;
using System.Linq;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            foreach (int d in diploma.Requirements)
            {
                foreach (Course c in student.Courses)
                {
                    var requirement = Repository.GetRequirement(d);
                    foreach (var _ in requirement.Courses.Where(r => r == c.Id).Select(r => new { }))
                    {
                        average += c.Mark;
                        if (c.Mark > requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                        }
                    }
                }
            }

            average /= student.Courses.Length;

            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude;

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }
    }
}
