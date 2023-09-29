﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMVVM.Models.Decanat;

internal class Student {
    public string Name { get; set; }
    public string SurName {  get; set; }
    public string Patronymic {  get; set; }
    public DateTime Birthday { get; set; }
    public double Rating {  get; set; }
    public string Description { get; set; }
}

internal class Group {
    public string Name { get; set; }
    public IList<Student> Students { get; set; }
    public string Description { get; set; }
}
