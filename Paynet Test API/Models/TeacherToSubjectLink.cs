using System;
using System.Collections.Generic;

#nullable disable

namespace Paynet_Test_API
{
    public partial class TeacherToSubjectLink
    {
        public int LinkId { get; set; }
        public int? TeacherId { get; set; }
        public int? SubjectId { get; set; }

        public virtual SchoolSubject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
