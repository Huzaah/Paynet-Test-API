using System;
using System.Collections.Generic;

#nullable disable

namespace Paynet_Test_API
{
    public partial class SchoolSubject
    {
        public SchoolSubject()
        {
            TeacherToSubjectLinks = new HashSet<TeacherToSubjectLink>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<TeacherToSubjectLink> TeacherToSubjectLinks { get; set; }
    }
}
