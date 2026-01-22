
﻿using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int TeacherId { get; set; }

    public string ClassName { get; set; } = null!;

    public int? CurrentStudent { get; set; }

    public int? MaxStudent { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public byte Shift { get; set; }

    public int? Status { get; set; }

    public string? Note { get; set; }

    public string? OnlineMeetingLink { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? CourseId { get; set; }

    public virtual ICollection<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();

    public virtual Course? Course { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ICollection<SchoolDay> SchoolDays { get; set; } = new List<SchoolDay>();
}
