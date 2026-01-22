
﻿using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseCode { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public int NumberSessions { get; set; }

    public decimal Tuition { get; set; }

    public string Level { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
