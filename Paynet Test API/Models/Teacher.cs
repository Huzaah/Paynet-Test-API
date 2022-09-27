using System;
using System.Collections.Generic;

#nullable disable

namespace Paynet_Test_API
{
    public partial class Teacher
    {
        public Teacher()
        {
            TeacherToSubjectLinks = new HashSet<TeacherToSubjectLink>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLname { get; set; }

        public virtual ICollection<TeacherToSubjectLink> TeacherToSubjectLinks { get; set; }
    }
}
