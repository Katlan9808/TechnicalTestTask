using System;
using System.Collections.Generic;

namespace Task.Domain.Entities;

public partial class TASK
{
    public int ID { get; set; }

    public string TITLE { get; set; } = null!;

    public string DESCRIPTION { get; set; } = null!;

    public string STATUS { get; set; } = null!;

    public string DEVELOPER { get; set; } = null!;

    public DateTime DATE_LIMIT { get; set; }
    public DateTime DATE_CREATED { get; set; }

    public DateTime? DATE_UPDATED { get; set; }
}
