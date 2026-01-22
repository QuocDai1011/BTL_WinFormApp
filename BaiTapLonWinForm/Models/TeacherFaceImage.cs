using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class TeacherFaceImage
{
    public int ImageId { get; set; }

    public int TeacherId { get; set; }

    public string ImagePath { get; set; } = null!;

    public DateTime? UploadedDate { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
