using System;
using System.Collections.Generic;

namespace TodoList.Models;

public partial class ToDo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool? IsEditing { get; set; }

    public bool? Done { get; set; }
}
