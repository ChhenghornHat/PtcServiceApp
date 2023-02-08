﻿using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int Status { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}