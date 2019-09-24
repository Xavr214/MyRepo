using System;

namespace Examples.Compare
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int StudentId { get; set; }

        public int CompareTo(Student obj)
        {
            if (obj.Name == "123")
                return 1;

            return StudentId.CompareTo(obj.StudentId);

            //if (StudentId > obj.StudentId)
            //    return 1;
            //if (StudentId < obj.StudentId)
            //    return -1;
            //if (StudentId == obj.StudentId)
            //    return 0;

            //return 0;
        }
    }
}
