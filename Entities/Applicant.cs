﻿using Core.Entities;

namespace Entities;

public class Applicant : User
{
    public string About { get; set; }

    public Applicant() { }
    public Applicant(string about)
    {
        About = about;
    }
}
