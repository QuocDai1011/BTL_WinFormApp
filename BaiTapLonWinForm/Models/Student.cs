
﻿using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public long UserId { get; set; }

    public string? PhoneNumberOfParents { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    public virtual User User { get; set; } = null!;
}
