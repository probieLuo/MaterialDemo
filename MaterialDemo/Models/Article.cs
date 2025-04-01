using System;
using System.Collections.Generic;

namespace MaterialDemo.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Excerpt { get; set; }

    public int UserId { get; set; }

    public int? CategoryId { get; set; }

    public string? Status { get; set; }

    public string? Keywords { get; set; }

    public int? Views { get; set; }

    public int? Likes { get; set; }

    public int? CreatedAt { get; set; }

    public int? UpdatedAt { get; set; }

    public int? PublishedAt { get; set; }
}
